// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System.Collections.Generic;
using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public abstract class EditTextBase<TResult> : IRequest<TResult>, IInlineMarkupable
  {
    public string Text { get; }

    public ParseMode? ParseMode { get; set; }

    public IEnumerable<MessageEntity>? Entities { get; set; }

    public bool? DisableWebPagePreview { get; set; }

    public InlineKeyboardMarkup? ReplyMarkup { get; set; }

    public string Method { get; } = "editMessageText";

    protected EditTextBase(string text) => Text = text;
  }

  public abstract class EditText<TChatId> : EditTextBase<TextMessage>,
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

  public sealed class EditText : EditText<long>
  {
    public EditText(long chatId, int messageId, string text) : base(chatId, messageId, text) { }
  }

  namespace Usernames
  {
    public sealed class EditText : EditText<string>
    {
      public EditText(string username, int messageId, string text) :
        base(username, messageId, text) { }
    }
  }

  namespace Inline
  {
    public sealed class EditText : EditTextBase<bool>, IInlineMessageTargetable
    {
      public string MessageId { get; }

      public EditText(string messageId, string text) : base(text) => MessageId = messageId;
    }
  }
}
