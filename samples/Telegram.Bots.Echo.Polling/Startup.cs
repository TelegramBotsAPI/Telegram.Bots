// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Telegram.Bots.Echo.Polling.Services;
using Telegram.Bots.Extensions.Polling;

namespace Telegram.Bots.Echo.Polling
{
  public class Startup
  {
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration) => _configuration = configuration;

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddBotClient(_configuration.GetValue<string>("Bot:Token"));
      services.AddPolling<EchoService>(_configuration);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

      app.UseRouting();

      var name = _configuration.GetValue("Bot:Name", "MyBot");

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapGet("/", async context =>
        {
          await context.Response.WriteAsync($"Hello from {name}!").ConfigureAwait(false);
        });
      });
    }
  }
}
