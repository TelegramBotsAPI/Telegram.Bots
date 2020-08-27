using System;
using System.Linq;
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

    public PollingService(PollingConfig config, IUpdateHandler handler, IServiceProvider provider)
    {
      _config = config;
      _handler = handler;
      _provider = provider;
    }

    protected override async Task ExecuteAsync(CancellationToken token)
    {
      var offset = 0;
      while (!token.IsCancellationRequested)
      {
        var wait = true;
        IServiceScope? scope = null;
        try
        {
          scope = _provider.CreateScope();
          {
            var bot = scope.ServiceProvider.GetRequiredService<IBotClient>();

            var response = await bot.HandleAsync(new GetUpdates
              {
                Offset = offset,
                Limit = _config.Limit,
                Timeout = _config.Timeout,
                AllowedUpdates = _config.AllowedUpdates
              }, token)
              .ConfigureAwait(false);

            if (response.Ok && response.Result.Count > 0)
            {
              var updates = response.Result;

              var tasks = updates.Select(update => _handler.HandleAsync(bot, update, token));

              await Task.WhenAll(tasks).ConfigureAwait(false);

              offset = updates[^1].Id + 1;
              wait = false;
            }
          }
        }
        finally
        {
          scope?.Dispose();
        }

        if (!wait) continue;

        await Task.Delay(TimeSpan.FromSeconds(_config.Interval), token).ConfigureAwait(false);
      }
    }
  }
}
