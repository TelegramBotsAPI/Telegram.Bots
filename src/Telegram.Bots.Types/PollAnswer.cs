// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System.Collections.Generic;

namespace Telegram.Bots.Types
{
  public sealed class PollAnswer
  {
    public string PollId { get; set; } = null!;

    public User User { get; set; } = null!;

    public IReadOnlyList<uint> OptionIds { get; set; } = null!;
  }
}
