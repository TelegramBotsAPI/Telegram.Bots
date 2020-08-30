// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Types.Games
{
  public sealed class GameHighScore
  {
    public int Position { get; set; }

    public User User { get; set; } = null!;

    public int Score { get; set; }
  }
}
