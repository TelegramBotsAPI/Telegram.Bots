// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public abstract class EditReplyMarkupBase<TResult> : IRequest<TResult>, IInlineMarkupable
  {
    public InlineKeyboardMarkup? ReplyMarkup { get; set; }

    public string Method { get; } = "editMessageReplyMarkup";
  }

  public abstract class EditReplyMarkup<TChatId> : EditReplyMarkupBase<Message>,
    IChatMessageTargetable<TChatId>
  {
    public TChatId ChatId { get; }

    public int MessageId { get; }

    protected EditReplyMarkup(TChatId chatId, int messageId)
    {
      ChatId = chatId;
      MessageId = messageId;
    }
  }

  public sealed class EditReplyMarkup : EditReplyMarkup<long>
  {
    public EditReplyMarkup(long chatId, int messageId) : base(chatId, messageId) { }
  }

  namespace Usernames
  {
    public sealed class EditReplyMarkup : EditReplyMarkup<string>
    {
      public EditReplyMarkup(string username, int messageId) : base(username, messageId) { }
    }
  }

  namespace Inline
  {
    public sealed class EditReplyMarkup : EditReplyMarkupBase<bool>, IInlineMessageTargetable
    {
      public string MessageId { get; }

      public EditReplyMarkup(string messageId) => MessageId = messageId;
    }
  }
}
