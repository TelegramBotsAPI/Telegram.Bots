// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests
{
  using Types;

  public abstract record EditReplyMarkupBase<TResult> : IRequest<TResult>,
    IInlineMarkupable
  {
    public InlineKeyboardMarkup? ReplyMarkup { get; init; }

    public string Method => "editMessageReplyMarkup";
  }

  public abstract record EditReplyMarkup<TChatId>(
    TChatId ChatId,
    int MessageId) : EditReplyMarkupBase<Message>,
    IChatMessageTargetable<TChatId>;

  public sealed record EditReplyMarkup(
    long ChatId,
    int MessageId) : EditReplyMarkup<long>(ChatId, MessageId);

  namespace Usernames
  {
    public sealed record EditReplyMarkup(
      string ChatId,
      int MessageId) : EditReplyMarkup<string>(ChatId, MessageId);
  }

  namespace Inline
  {
    public sealed record EditReplyMarkup(
      string MessageId) : EditReplyMarkupBase<bool>, IInlineMessageTargetable;
  }
}
