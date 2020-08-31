// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Types.Inline
{
  public abstract class InlineResult
  {
    public abstract ResultType Type { get; }

    public string Id { get; }

    public InlineKeyboardMarkup? ReplyMarkup { get; set; }

    protected InlineResult(string id) => Id = id;
  }

  public abstract class ReplaceableResult : InlineResult
  {
    public InputContent? Content { get; set; }

    protected ReplaceableResult(string id) : base(id) { }
  }
}
