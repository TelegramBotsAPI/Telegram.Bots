// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public abstract record ForwardMessage<TChatId, TFromChatId> : IRequest<Message>,
    IChatMessageTargetable<TChatId>, INotifiable, IProtectable
  {
    public TChatId ChatId { get; }

    public TFromChatId FromChatId { get; }

    public int MessageId { get; }

    public bool? DisableNotification { get; init; }
    
    public bool? ProtectContent { get; init; }

    public string Method { get; } = "forwardMessage";

    protected ForwardMessage(TChatId chatId, TFromChatId fromChatId, int messageId)
    {
      ChatId = chatId;
      FromChatId = fromChatId;
      MessageId = messageId;
    }
  }

  public sealed record ForwardMessage : ForwardMessage<long, long>
  {
    public ForwardMessage(long chatId, long fromChatId, int messageId) :
      base(chatId, fromChatId, messageId) { }
  }

  public sealed record ForwardMessageViaUsername : ForwardMessage<string, long>
  {
    public ForwardMessageViaUsername(string username, long fromChatId, int messageId) :
      base(username, fromChatId, messageId) { }
  }

  namespace Usernames
  {
    public sealed record ForwardMessage : ForwardMessage<string, string>
    {
      public ForwardMessage(string username, string fromUsername, int messageId) :
        base(username, fromUsername, messageId) { }
    }

    public sealed record ForwardMessageViaId : ForwardMessage<long, string>
    {
      public ForwardMessageViaId(long chatId, string fromUsername, int messageId) :
        base(chatId, fromUsername, messageId) { }
    }
  }
}
