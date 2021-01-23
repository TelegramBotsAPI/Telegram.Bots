// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2021 Aman Agnihotri

using System;
using System.Collections.Generic;

namespace Telegram.Bots.Configs
{
  public sealed record BotConfig : IBotConfig
  {
    public Uri BaseAddress { get; init; } = new("https://api.telegram.org/");

    public string Token { get; init; } = null!;

    public int Timeout { get; init; } = 90;

    public int HandlerLifetime { get; init; } = 600;

    public IEnumerable<int> WaitsBeforeRetry { get; init; } = new[] { 1, 2, 5 };

    public int EventsAllowedBeforeBreaking { get; init; } = 3;

    public int BreakDuration { get; init; } = 30;
  }
}
