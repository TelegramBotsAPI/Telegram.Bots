using System;
using System.Collections.Generic;

namespace Telegram.Bots.Configs
{
  public sealed class BotConfig : IBotConfig
  {
    public Uri BaseAddress { get; set; } = new Uri("https://api.telegram.org/");

    public string Token { get; set; } = null!;

    public int Timeout { get; set; } = 90;

    public int HandlerLifetime { get; set; } = 600;

    public IEnumerable<int> WaitsBeforeRetry { get; set; } = new[] { 1, 2, 5 };

    public int EventsAllowedBeforeBreaking { get; set; } = 3;

    public int BreakDuration { get; set; } = 30;
  }
}
