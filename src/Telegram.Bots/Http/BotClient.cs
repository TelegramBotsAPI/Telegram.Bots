// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bots.Configs;
using Telegram.Bots.Requests;
using Telegram.Bots.Types;
using static System.Text.Encoding;
using static System.Net.Http.HttpCompletionOption;
using FileInfo = Telegram.Bots.Types.FileInfo;

namespace Telegram.Bots.Http
{
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

    public async Task<Response<T>> HandleAsync<T>(IRequest<T> request, CancellationToken token)
    {
      if (request is null) throw new ArgumentNullException(nameof(request));

      HttpRequestMessage? httpRequest = null;
      try
      {
        httpRequest = new HttpRequestMessage
        {
          Method = HttpMethod.Post,
          RequestUri = new Uri($"/bot{_config.Token}/{request.Method}", UriKind.Relative),
          Content = request switch
          {
            IUploadable data when data.HasFiles() => GetMultipartCreator()(data),
            _ => new StringContent(_serializer.Serialize(request), UTF8, "application/json")
          }
        };

        using var httpResponse = await _client.SendAsync(httpRequest, ResponseHeadersRead, token)
          .ConfigureAwait(false);

        var httpContent = await httpResponse.Content.ReadAsStreamAsync(token).ConfigureAwait(false);

        return httpResponse.IsSuccessStatusCode
          ? new Response<T>(_serializer.Deserialize<Success<T>>(httpContent).Result)
          : new Response<T>(_serializer.Deserialize<Failure>(httpContent));
      }
      catch (TaskCanceledException)
      {
        return new Response<T>(Canceled);
      }
      catch (OperationCanceledException)
      {
        return token.IsCancellationRequested
          ? new Response<T>(Canceled)
          : new Response<T>(TimedOut);
      }
      finally
      {
        httpRequest?.Dispose();
      }

      Func<IUploadable, HttpContent> GetMultipartCreator() => data =>
      {
        var content = new MultipartFormDataContent();

        foreach (var property in _serializer.GetProperties(data))
        {
          content.Add(new StringContent(property.Value), property.Name);
        }

        foreach (var file in data.GetFiles().Where(file => file != null))
        {
          content.Add(new StreamContent(file!.Data)
            { Headers = { ContentType = Stream } }, file.Id, file.Id);
        }

        return content;
      };
    }

    public async Task<Response<FileInfo>> HandleAsync(
      string fileId,
      Stream destination,
      CancellationToken token)
    {
      var response = await HandleAsync(new GetFile(fileId), token).ConfigureAwait(false);

      if (!response.Ok) return response;

      var path = response.Result.Path;

      if (string.IsNullOrEmpty(path)) return NotFound;

      HttpRequestMessage? httpRequest = null;
      try
      {
        httpRequest = new HttpRequestMessage
        {
          Method = HttpMethod.Get,
          RequestUri = new Uri($"/file/bot{_config.Token}/{path}", UriKind.Relative)
        };

        using var httpResponse = await _client.SendAsync(httpRequest, ResponseHeadersRead, token)
          .ConfigureAwait(false);

        await using var httpContent = await httpResponse.Content.ReadAsStreamAsync(token)
          .ConfigureAwait(false);

        if (!httpResponse.IsSuccessStatusCode)
          return new Response<FileInfo>(_serializer.Deserialize<Failure>(httpContent));

        await httpContent.CopyToAsync(destination, token).ConfigureAwait(false);
      }
      finally
      {
        httpRequest?.Dispose();
      }

      return response;
    }

    private static readonly MediaTypeHeaderValue Stream =
      MediaTypeHeaderValue.Parse("application/octet-stream");

    private static readonly Failure TimedOut =
      new Failure { Description = "Timed Out", ErrorCode = 408 };

    private static readonly Failure Canceled =
      new Failure { Description = "Canceled", ErrorCode = 408 };

    private static readonly Response<FileInfo> NotFound =
      new Response<FileInfo>(new Failure { Description = "Not Found", ErrorCode = 404 });
  }
}
