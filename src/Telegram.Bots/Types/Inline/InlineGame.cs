// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Types.Inline;

public sealed record InlineGame : InlineResult
{
  public override ResultType Type { get; } = ResultType.Game;

  public string ShortName { get; }

  public InlineGame(string id, string shortName) : base(id)
  {
    ShortName = shortName;
  }
}
