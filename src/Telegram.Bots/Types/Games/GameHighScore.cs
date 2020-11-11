// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Types.Games
{
  public sealed record GameHighScore
  {
    public int Position { get; init; }

    public User User { get; init; } = null!;

    public int Score { get; init; }
  }
}
