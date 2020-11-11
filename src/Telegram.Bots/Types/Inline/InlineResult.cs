// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Types.Inline
{
  public abstract record InlineResult
  {
    public abstract ResultType Type { get; }

    public string Id { get; }

    public InlineKeyboardMarkup? ReplyMarkup { get; init; }

    protected InlineResult(string id) => Id = id;
  }

  public abstract record ReplaceableResult : InlineResult
  {
    public InputContent? Content { get; init; }

    protected ReplaceableResult(string id) : base(id) { }
  }
}
