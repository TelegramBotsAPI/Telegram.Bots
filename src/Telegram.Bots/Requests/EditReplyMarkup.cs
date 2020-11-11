// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public abstract record EditReplyMarkupBase<TResult> : IRequest<TResult>, IInlineMarkupable
  {
    public InlineKeyboardMarkup? ReplyMarkup { get; init; }

    public string Method { get; } = "editMessageReplyMarkup";
  }

  public abstract record EditReplyMarkup<TChatId> : EditReplyMarkupBase<Message>,
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

  public sealed record EditReplyMarkup : EditReplyMarkup<long>
  {
    public EditReplyMarkup(long chatId, int messageId) : base(chatId, messageId) { }
  }

  namespace Usernames
  {
    public sealed record EditReplyMarkup : EditReplyMarkup<string>
    {
      public EditReplyMarkup(string username, int messageId) : base(username, messageId) { }
    }
  }

  namespace Inline
  {
    public sealed record EditReplyMarkup : EditReplyMarkupBase<bool>, IInlineMessageTargetable
    {
      public string MessageId { get; }

      public EditReplyMarkup(string messageId) => MessageId = messageId;
    }
  }
}
