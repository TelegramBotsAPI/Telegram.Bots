// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

using static System.Text.Encoding;
using static System.Net.Http.HttpCompletionOption;
using static System.UriKind;

namespace Telegram.Bots.Http;

using Configs;
using Requests;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Types;
using FileInfo = Types.FileInfo;

public sealed class BotClient : IBotClient
{
  private readonly HttpClient _client;
  private readonly IBotConfig _config;
  private readonly ISerializer _serializer;

  public BotClient(HttpClient client, IBotConfig config, ISerializer serializer)
  {
    _client = client;
    _config = config;
    _serializer = serializer;
  }

  public async Task<Response<T>> HandleAsync<T>(
    IRequest<T> request,
    CancellationToken token)
  {
    if (request is null)
    {
      throw new ArgumentNullException(nameof(request));
    }

    HttpRequestMessage? httpRequest = null;

    try
    {
      httpRequest = new()
      {
        Method = HttpMethod.Post,
        RequestUri = new($"/bot{_config.Token}/{request.Method}", Relative),
        Content = request switch
        {
          IUploadable data when data.HasFiles() => GetMultipartCreator()(data),
          _ => new StringContent(_serializer.Serialize(request), UTF8, Json)
        }
      };

      using HttpResponseMessage httpResponse = await _client
        .SendAsync(httpRequest, ResponseHeadersRead, token)
        .ConfigureAwait(false);

      Stream httpContent = await httpResponse.Content.ReadAsStreamAsync(token)
        .ConfigureAwait(false);

      return httpResponse.IsSuccessStatusCode
        ? new(_serializer.Deserialize<Success<T>>(httpContent).Result)
        : new(_serializer.Deserialize<Failure>(httpContent));
    }
    catch (TaskCanceledException e) when (e.InnerException is TimeoutException)
    {
      return new(TimedOut);
    }
    catch (OperationCanceledException)
    {
      return token.IsCancellationRequested ? new(Canceled) : new(TimedOut);
    }
    finally
    {
      httpRequest?.Dispose();
    }

    Func<IUploadable, HttpContent> GetMultipartCreator() => data =>
    {
      MultipartFormDataContent content = new();

      foreach (DataProperty property in _serializer.GetProperties(data))
      {
        content.Add(new StringContent(property.Value), property.Name);
      }

      foreach (InputFile? file in data.GetFiles().Where(file => file != null))
      {
        content.Add(new StreamContent(file!.Data)
        {
          Headers =
          {
            ContentType = Stream
          }
        }, file.Id, file.Id);
      }

      return content;
    };
  }

  public async Task<Response<FileInfo>> HandleAsync(
    string fileId,
    Stream destination,
    CancellationToken token)
  {
    Response<FileInfo> response = await HandleAsync(new GetFile(fileId), token)
      .ConfigureAwait(false);

    if (!response.Ok)
    {
      return response;
    }

    string? path = response.Result.Path;

    if (string.IsNullOrEmpty(path))
    {
      return NotFound;
    }

    HttpRequestMessage? httpRequest = null;

    try
    {
      httpRequest = new()
      {
        Method = HttpMethod.Get,
        RequestUri = new($"/file/bot{_config.Token}/{path}", Relative)
      };

      using HttpResponseMessage httpResponse = await _client
        .SendAsync(httpRequest, ResponseHeadersRead, token)
        .ConfigureAwait(false);

      await using Stream httpContent = await httpResponse.Content
        .ReadAsStreamAsync(token)
        .ConfigureAwait(false);

      if (!httpResponse.IsSuccessStatusCode)
      {
        return new(_serializer.Deserialize<Failure>(httpContent));
      }

      await httpContent.CopyToAsync(destination, token).ConfigureAwait(false);
    }
    finally
    {
      httpRequest?.Dispose();
    }

    return response;
  }

  private const string Json = "application/json";

  private static readonly MediaTypeHeaderValue Stream =
    MediaTypeHeaderValue.Parse("application/octet-stream");

  private static readonly Failure TimedOut =
    new()
    {
      Description = "Timed Out", ErrorCode = 408
    };

  private static readonly Failure Canceled =
    new()
    {
      Description = "Canceled", ErrorCode = 408
    };

  private static readonly Response<FileInfo> NotFound =
    new(new Failure
    {
      Description = "Not Found", ErrorCode = 404
    });
}
