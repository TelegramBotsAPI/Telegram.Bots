// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System.Collections.Generic;
using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public abstract class EditCaptionBase<TResult> : IRequest<TResult>, ICaptionable,
    IInlineMarkupable
  {
    public string? Caption { get; set; }

    public ParseMode? ParseMode { get; set; }

    public IEnumerable<MessageEntity>? CaptionEntities { get; set; }

    public InlineKeyboardMarkup? ReplyMarkup { get; set; }

    public string Method { get; } = "editMessageCaption";
  }

  public abstract class EditCaption<TChatId> : EditCaptionBase<CaptionableMessage>,
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

  public sealed class EditCaption : EditCaption<long>
  {
    public EditCaption(long chatId, int messageId) : base(chatId, messageId) { }
  }

  namespace Usernames
  {
    public sealed class EditCaption : EditCaption<string>
    {
      public EditCaption(string username, int messageId) : base(username, messageId) { }
    }
  }

  namespace Inline
  {
    public sealed class EditCaption : EditCaptionBase<bool>, IInlineMessageTargetable
    {
      public string MessageId { get; }

      public EditCaption(string messageId) => MessageId = messageId;
    }
  }
}
