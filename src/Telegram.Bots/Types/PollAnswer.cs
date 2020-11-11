// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System.Collections.Generic;

namespace Telegram.Bots.Types
{
  public sealed record PollAnswer
  {
    public string PollId { get; init; } = null!;

    public User User { get; init; } = null!;

    public IReadOnlyList<uint> OptionIds { get; init; } = null!;
  }
}
