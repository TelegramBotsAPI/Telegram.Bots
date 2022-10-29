// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Tests.Units.Http;

using Bots.Types;
using Microsoft.Extensions.DependencyInjection;
using Requests;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

public sealed class BotClientTests
{
  [Fact(DisplayName = "BotClient returns Result Response on Success")]
  public async Task BotClientReturnsResultResponseOnSuccess()
  {
    DelegatingHandler? handler = null;

    try
    {
      handler =
        new MockResponseHandler(HttpStatusCode.OK, @"{""result"":true}");

      IBotClient bot = CreateClient(handler);

      Response<bool> response =
        await bot.HandleAsync(new Test()).ConfigureAwait(false);

      Assert.True(response.Ok);
      Assert.True(response.Result);
      Assert.Equal(default, response.Failure);
    }
    finally
    {
      handler?.Dispose();
    }
  }

  [Fact(DisplayName = "BotClient returns Timed Out Response on Timeout")]
  public async Task BotClientReturnsTimedOutResponseOnTimeout()
  {
    DelegatingHandler? handler = null;

    try
    {
      handler =
        new MockActionHandler(_ => throw new OperationCanceledException());

      IBotClient bot = CreateClient(handler);

      Response<bool> response =
        await bot.HandleAsync(new Test()).ConfigureAwait(false);

      Assert.False(response.Ok);
      Assert.NotNull(response.Failure);
      Assert.Equal(408, response.Failure.ErrorCode);
      Assert.Equal("Timed Out", response.Failure.Description);
      Assert.Equal(default, response.Failure.Parameters);
      Assert.Equal(default, response.Result);
    }
    finally
    {
      handler?.Dispose();
    }
  }

  [Fact(DisplayName =
    "BotClient returns Canceled Response on Token Cancellation")]
  public async Task BotClientReturnsCanceledResponseOnTokenCancellation()
  {
    CancellationTokenSource? source = null;

    try
    {
      IBotClient bot = CreateClient();

      source = new CancellationTokenSource();

      source.Cancel();

      Response<bool> response = await bot.HandleAsync(new Test(), source.Token)
        .ConfigureAwait(false);

      Assert.False(response.Ok);
      Assert.NotNull(response.Failure);
      Assert.Equal(408, response.Failure.ErrorCode);
      Assert.Equal("Canceled", response.Failure.Description);
      Assert.Equal(default, response.Failure.Parameters);
      Assert.Equal(default, response.Result);
    }
    finally
    {
      source?.Dispose();
    }
  }

  [Fact(DisplayName = "BotClient throws on any other Exception")]
  public async Task BotClientThrowsOnAnyOtherException()
  {
    DelegatingHandler? handler = null;

    try
    {
      handler = new MockActionHandler(_ => throw new Exception());

      IBotClient bot = CreateClient(handler);

      await Assert.ThrowsAsync<Exception>(async () =>
          await bot.HandleAsync(new GetMe()).ConfigureAwait(false))
        .ConfigureAwait(false);
    }
    finally
    {
      handler?.Dispose();
    }
  }

  private static IBotClient CreateClient(DelegatingHandler? handler = null)
  {
    ServiceCollection services = new();

    IHttpClientBuilder builder = services.AddBotClient("token");

    if (handler != null)
    {
      builder.AddHttpMessageHandler(() => handler);
    }

    return services.BuildServiceProvider().GetRequiredService<IBotClient>();
  }

  private sealed record Test : IRequest<bool>
  {
    public string Method => "test";
  }
}
