// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System.Collections.Generic;
using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public abstract record EditCaptionBase<TResult> : IRequest<TResult>, ICaptionable,
    IInlineMarkupable
  {
    public string? Caption { get; init; }

    public ParseMode? ParseMode { get; init; }

    public IEnumerable<MessageEntity>? CaptionEntities { get; init; }

    public InlineKeyboardMarkup? ReplyMarkup { get; init; }

    public string Method { get; } = "editMessageCaption";
  }

  public abstract record EditCaption<TChatId> : EditCaptionBase<CaptionableMessage>,
    IChatMessageTargetable<TChatId>
  {
    public TChatId ChatId { get; }

    public int MessageId { get; }

    protected EditCaption(TChatId chatId, int messageId)
    {
      ChatId = chatId;
      MessageId = messageId;
    }
  }

  public sealed record EditCaption : EditCaption<long>
  {
    public EditCaption(long chatId, int messageId) : base(chatId, messageId) { }
  }

  namespace Usernames
  {
    public sealed record EditCaption : EditCaption<string>
    {
      public EditCaption(string username, int messageId) : base(username, messageId) { }
    }
  }

  namespace Inline
  {
    public sealed record EditCaption : EditCaptionBase<bool>, IInlineMessageTargetable
    {
      public string MessageId { get; }

      public EditCaption(string messageId) => MessageId = messageId;
    }
  }
}
