// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2022 Aman Agnihotri

namespace Telegram.Bots.Requests.Admins
{
  public abstract record UnbanChatOwner<TChatId> : IRequest<bool>, IChatOwnerTargetable<TChatId>
  {
    public TChatId ChatId { get; }

    public long SenderChatId { get; }

    public string Method { get; } = "unbanChatSenderChat";

    protected UnbanChatOwner(TChatId chatId, long senderChatId)
    {
      ChatId = chatId;
      SenderChatId = senderChatId;
    }
  }

  public sealed record UnbanChatOwner : UnbanChatOwner<long>
  {
    public UnbanChatOwner(long chatId, long senderChatId) : base(chatId, senderChatId) { }
  }

  namespace Usernames
  {
    public sealed record UnbanChatOwner : UnbanChatOwner<string>
    {
      public UnbanChatOwner(string username, long senderChatId) :
        base(username, senderChatId) { }
    }
  }
}
