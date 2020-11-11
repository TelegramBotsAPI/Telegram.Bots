// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System.Collections.Generic;
using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public abstract record EditTextBase<TResult> : IRequest<TResult>, IInlineMarkupable
  {
    public string Text { get; }

    public ParseMode? ParseMode { get; init; }

    public IEnumerable<MessageEntity>? Entities { get; init; }

    public bool? DisableWebPagePreview { get; init; }

    public InlineKeyboardMarkup? ReplyMarkup { get; init; }

    public string Method { get; } = "editMessageText";

    protected EditTextBase(string text) => Text = text;
  }

  public abstract record EditText<TChatId> : EditTextBase<TextMessage>,
    IChatMessageTargetable<TChatId>
  {
    public TChatId ChatId { get; }

    public int MessageId { get; }

    protected EditText(TChatId chatId, int messageId, string text) : base(text)
    {
      ChatId = chatId;
      MessageId = messageId;
    }
  }

  public sealed record EditText : EditText<long>
  {
    public EditText(long chatId, int messageId, string text) : base(chatId, messageId, text) { }
  }

  namespace Usernames
  {
    public sealed record EditText : EditText<string>
    {
      public EditText(string username, int messageId, string text) :
        base(username, messageId, text) { }
    }
  }

  namespace Inline
  {
    public sealed record EditText : EditTextBase<bool>, IInlineMessageTargetable
    {
      public string MessageId { get; }

      public EditText(string messageId, string text) : base(text) => MessageId = messageId;
    }
  }
}
