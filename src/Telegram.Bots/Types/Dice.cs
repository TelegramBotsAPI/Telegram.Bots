// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Types
{
  public sealed class Dice
  {
    public Emoji Emoji { get; set; }

    public uint Value { get; set; }
  }
}
