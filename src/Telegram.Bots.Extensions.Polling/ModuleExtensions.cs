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
    public static IServices AddPolling(this IServices services, IConfiguration? config = null)
    {
      var pollingConfig = config is null
        ? new PollingConfig()
        : config.GetSection("Polling").Get<PollingConfig>();

      return services.AddPolling(pollingConfig);
    }

    public static IServices AddPolling(this IServices services, PollingConfig config) =>
      services.AddSingleton(config).AddHostedService<PollingService>();
  }
}
