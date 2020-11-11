// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Types
{
  public sealed record BotCommand
  {
    public string Command { get; init; } = null!;

    public string Description { get; init; } = null!;
  }
}
