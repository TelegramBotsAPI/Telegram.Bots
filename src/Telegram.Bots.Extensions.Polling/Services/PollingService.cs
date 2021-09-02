// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2021 Aman Agnihotri

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Telegram.Bots.Extensions.Polling.Configs;
using Telegram.Bots.Requests;

namespace Telegram.Bots.Extensions.Polling.Services
{
  public sealed class PollingService : BackgroundService
  {
    private readonly PollingConfig _config;
    private readonly IUpdateHandler _handler;
    private readonly IServiceProvider _provider;

    public PollingService(
      PollingConfig config,
      IUpdateHandler handler,
      IServiceProvider provider)
    {
      _config = config;
      _handler = handler;
      _provider = provider;
    }

    protected override async Task ExecuteAsync(CancellationToken token)
    {
      if (!await IsValid(token).ConfigureAwait(false))
        throw new ArgumentException("Invalid Bot Token");

      var offset = 0;

      while (!token.IsCancellationRequested)
      {
        var bot = GetBotClient();

        var response = await bot.HandleAsync(new GetUpdates
          {
            Offset = offset,
            Limit = _config.Limit,
            Timeout = _config.Timeout,
            AllowedUpdates = _config.AllowedUpdates
          }, token)
          .ConfigureAwait(false);

        if (!response.Ok || response.Result.Count <= 0) continue;

        foreach (var update in response.Result)
          await _handler.HandleAsync(bot, update, token);

        offset = response.Result[^1].Id + 1;
      }
    }

    private async Task<bool> IsValid(CancellationToken token)
    {
      var bot = GetBotClient();

      var response =
        await bot.HandleAsync(new GetMe(), token).ConfigureAwait(false);

      return response.Ok;
    }

    private IBotClient GetBotClient()
    {
      using var scope = _provider.CreateScope();

      return scope.ServiceProvider.GetRequiredService<IBotClient>();
    }
  }
}
