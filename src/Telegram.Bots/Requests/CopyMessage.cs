// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

using System.Collections.Generic;
using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public abstract record CopyMessage<TChatId, TFromChatId> : IRequest<MessageId>,
    IChatMessageTargetable<TChatId>, ICaptionable, INotifiable, IProtectable, IReplyable,
    IMarkupable
  {
    public TChatId ChatId { get; }

    public TFromChatId FromChatId { get; }

    public int MessageId { get; }

    public string? Caption { get; init; }

    public ParseMode? ParseMode { get; init; }

    public IEnumerable<MessageEntity>? CaptionEntities { get; init; }

    public bool? DisableNotification { get; init; }
    
    public bool? ProtectContent { get; init; }

    public int? ReplyToMessageId { get; init; }

    public bool? AllowSendingWithoutReply { get; init; }

    public ReplyMarkup? ReplyMarkup { get; init; }

    public string Method { get; } = "copyMessage";

    protected CopyMessage(TChatId chatId, TFromChatId fromChatId, int messageId)
    {
      ChatId = chatId;
      FromChatId = fromChatId;
      MessageId = messageId;
    }
  }

  public sealed record CopyMessage : CopyMessage<long, long>
  {
    public CopyMessage(long chatId, long fromChatId, int messageId) :
      base(chatId, fromChatId, messageId) { }
  }

  public sealed record CopyMessageViaUsername : CopyMessage<string, long>
  {
    public CopyMessageViaUsername(string username, long fromChatId, int messageId) :
      base(username, fromChatId, messageId) { }
  }

  namespace Usernames
  {
    public sealed record CopyMessage : CopyMessage<string, string>
    {
      public CopyMessage(string username, string fromUsername, int messageId) :
        base(username, fromUsername, messageId) { }
    }

    public sealed record CopyMessageViaId : CopyMessage<long, string>
    {
      public CopyMessageViaId(long chatId, string fromUsername, int messageId) :
        base(chatId, fromUsername, messageId) { }
    }
  }
}
