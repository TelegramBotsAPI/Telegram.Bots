// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Configs;

using System;
using System.Collections.Generic;

public sealed record BotConfig(string Token) : IBotConfig
{
  public Uri BaseAddress { get; init; } = new("https://api.telegram.org/");

  public TimeSpan Timeout { get; init; } = TimeSpan.FromSeconds(90);

  public int HandlerLifetime { get; init; } = 600;

  public IEnumerable<int> WaitsBeforeRetry { get; init; } = new[]
  {
    1, 2, 5
  };

  public int EventsAllowedBeforeBreaking { get; init; } = 3;

  public int BreakDuration { get; init; } = 30;
}
