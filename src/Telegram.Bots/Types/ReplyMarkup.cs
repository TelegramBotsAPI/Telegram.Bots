// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System.Collections.Generic;

namespace Telegram.Bots.Types
{
  using Keyboard = IEnumerable<Button[]>;
  using InlineKeyboard = IEnumerable<InlineButton[]>;

  public abstract record ReplyMarkup { }

  public sealed record KeyboardMarkup : ReplyMarkup
  {
    public Keyboard Keyboard { get; }

    public bool? Resize { get; init; }

    public bool? OneTime { get; init; }

    public bool? Selective { get; init; }

    public KeyboardMarkup(Keyboard keyboard) => Keyboard = keyboard;
  }

  public sealed record InlineKeyboardMarkup : ReplyMarkup
  {
    public InlineKeyboard Keyboard { get; }

    public InlineKeyboardMarkup(InlineKeyboard keyboard) => Keyboard = keyboard;
  }

  public sealed record ForceReplyMarkup : ReplyMarkup
  {
    public bool ForceReply { get; } = true;

    public bool? Selective { get; init; }
  }

  public sealed record RemoveMarkup : ReplyMarkup
  {
    public bool RemoveKeyboard { get; } = true;

    public bool? Selective { get; init; }
  }
}
