// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System.Collections.Generic;
using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public abstract class CopyMessage<TChatId, TFromChatId> : IRequest<Message>,
    IChatMessageTargetable<TChatId>, ICaptionable, INotifiable, IReplyable, IMarkupable
  {
    public TChatId ChatId { get; }

    public TFromChatId FromChatId { get; }

    public int MessageId { get; }

    public string? Caption { get; set; }

    public ParseMode? ParseMode { get; set; }

    public IEnumerable<MessageEntity>? CaptionEntities { get; set; }

    public bool? DisableNotification { get; set; }

    public int? ReplyToMessageId { get; set; }

    public bool? AllowSendingWithoutReply { get; set; }

    public ReplyMarkup? ReplyMarkup { get; set; }

    public string Method { get; } = "copyMessage";

    protected CopyMessage(TChatId chatId, TFromChatId fromChatId, int messageId)
    {
      ChatId = chatId;
      FromChatId = fromChatId;
      MessageId = messageId;
    }
  }

  public sealed class CopyMessage : CopyMessage<long, long>
  {
    public CopyMessage(long chatId, long fromChatId, int messageId) :
      base(chatId, fromChatId, messageId) { }
  }

  public sealed class CopyMessageViaUsername : CopyMessage<string, long>
  {
    public CopyMessageViaUsername(string username, long fromChatId, int messageId) :
      base(username, fromChatId, messageId) { }
  }

  namespace Usernames
  {
    public sealed class CopyMessage : CopyMessage<string, string>
    {
      public CopyMessage(string username, string fromUsername, int messageId) :
        base(username, fromUsername, messageId) { }
    }

    public sealed class CopyMessageViaId : CopyMessage<long, string>
    {
      public CopyMessageViaId(long chatId, string fromUsername, int messageId) :
        base(chatId, fromUsername, messageId) { }
    }
  }
}
