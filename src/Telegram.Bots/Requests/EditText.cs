// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests
{
  using System.Collections.Generic;
  using Types;

  public abstract record EditTextBase<TResult>(
    string Text) : IRequest<TResult>, IInlineMarkupable
  {
    public ParseMode? ParseMode { get; init; }

    public IEnumerable<MessageEntity>? Entities { get; init; }

    public bool? DisableWebPagePreview { get; init; }

    public InlineKeyboardMarkup? ReplyMarkup { get; init; }

    public string Method => "editMessageText";
  }

  public abstract record EditText<TChatId>(
    TChatId ChatId,
    int MessageId,
    string Text) : EditTextBase<TextMessage>(Text),
    IChatMessageTargetable<TChatId>;

  public sealed record EditText(
    long ChatId,
    int MessageId,
    string Text) : EditText<long>(ChatId, MessageId, Text);

  namespace Usernames
  {
    public sealed record EditText(
      string ChatId,
      int MessageId,
      string Text) : EditText<string>(ChatId, MessageId, Text);
  }

  namespace Inline
  {
    public sealed record EditText(
      string MessageId,
      string Text) : EditTextBase<bool>(Text), IInlineMessageTargetable;
  }
}
