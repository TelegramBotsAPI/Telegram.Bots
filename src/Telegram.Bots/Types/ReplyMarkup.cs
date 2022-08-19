// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Types;

using Keyboard = System.Collections.Generic.IEnumerable<Button[]>;
using InlineKeyboard = System.Collections.Generic.IEnumerable<InlineButton[]>;

public abstract record ReplyMarkup;

public sealed record KeyboardMarkup(Keyboard Keyboard) : ReplyMarkup
{
  public bool? Resize { get; init; }

  public bool? OneTime { get; init; }

  public string? InputFieldPlaceholder { get; init; }

  public bool? Selective { get; init; }
}

public sealed record InlineKeyboardMarkup(
  InlineKeyboard Keyboard) : ReplyMarkup;

public sealed record ForceReplyMarkup : ReplyMarkup
{
  public bool ForceReply => true;

  public string? InputFieldPlaceholder { get; init; }

  public bool? Selective { get; init; }
}

public sealed record RemoveMarkup : ReplyMarkup
{
  public bool RemoveKeyboard => true;

  public bool? Selective { get; init; }
}
