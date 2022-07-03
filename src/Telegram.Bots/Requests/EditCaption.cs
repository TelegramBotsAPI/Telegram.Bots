// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests
{
  using System.Collections.Generic;
  using Types;

  public abstract record EditCaptionBase<TResult> : IRequest<TResult>,
    ICaptionable, IInlineMarkupable
  {
    public string? Caption { get; init; }

    public ParseMode? ParseMode { get; init; }

    public IEnumerable<MessageEntity>? CaptionEntities { get; init; }

    public InlineKeyboardMarkup? ReplyMarkup { get; init; }

    public string Method => "editMessageCaption";
  }

  public abstract record EditCaption<TChatId>(
    TChatId ChatId,
    int MessageId) : EditCaptionBase<CaptionableMessage>,
    IChatMessageTargetable<TChatId>;

  public sealed record EditCaption(
    long ChatId,
    int MessageId) : EditCaption<long>(ChatId, MessageId);

  namespace Usernames
  {
    public sealed record EditCaption(
      string ChatId,
      int MessageId) : EditCaption<string>(ChatId, MessageId);
  }

  namespace Inline
  {
    public sealed record EditCaption(
      string MessageId) : EditCaptionBase<bool>, IInlineMessageTargetable;
  }
}
