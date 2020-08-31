// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Types
{
  public sealed class PollOption
  {
    public string Text { get; set; } = null!;

    public uint VoterCount { get; set; }
  }
}
