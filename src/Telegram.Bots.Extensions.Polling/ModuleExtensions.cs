// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bots.Extensions.Polling.Configs;
using Telegram.Bots.Extensions.Polling.Services;

namespace Telegram.Bots.Extensions.Polling
{
  using IServices = IServiceCollection;

  public static class ModuleExtensions
  {
    public static IServices AddPolling<T>(this IServices services, IConfiguration? config = null)
      where T : class, IUpdateHandler
    {
      var pollingConfig = config is null
        ? new PollingConfig()
        : config.GetSection("Polling").Get<PollingConfig>();

      return services.AddPolling<T>(pollingConfig);
    }

    public static IServices AddPolling<T>(this IServices services, PollingConfig config)
      where T : class, IUpdateHandler => services
      .AddSingleton(config)
      .AddSingleton<IUpdateHandler, T>()
      .AddHostedService<PollingService>();
  }
}
