// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Types
{
  public sealed record PollOption
  {
    public string Text { get; init; } = null!;

    public uint VoterCount { get; init; }
  }
}
