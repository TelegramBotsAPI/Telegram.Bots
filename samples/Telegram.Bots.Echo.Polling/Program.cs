// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Telegram.Bots.Echo.Polling
{
  public static class Program
  {
    public static Task Main(string[] args) =>
      CreateHostBuilder(args).Build().RunAsync();

    private static IHostBuilder CreateHostBuilder(string[] args) => Host
      .CreateDefaultBuilder(args)
      .ConfigureWebHostDefaults(builder => builder.UseStartup<Startup>());
  }
}
