// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Types
{
  public sealed class BotCommand
  {
    public string Command { get; set; } = null!;

    public string Description { get; set; } = null!;
  }
}
