// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Types;

using System.Collections.Generic;

public sealed record PollAnswer
{
  public string PollId { get; init; } = null!;

  public User User { get; init; } = null!;

  public IReadOnlyList<uint> OptionIds { get; init; } = null!;
}
