// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2022 Aman Agnihotri

namespace Telegram.Bots.Requests.Admins
{
  public abstract record BanChatOwner<TChatId> : IRequest<bool>, IChatOwnerTargetable<TChatId>
  {
    public TChatId ChatId { get; }

    public long SenderChatId { get; }

    public string Method { get; } = "banChatSenderChat";

    protected BanChatOwner(TChatId chatId, long senderChatId)
    {
      ChatId = chatId;
      SenderChatId = senderChatId;
    }
  }

  public sealed record BanChatOwner : BanChatOwner<long>
  {
    public BanChatOwner(long chatId, long senderChatId) : base(chatId, senderChatId) { }
  }

  namespace Usernames
  {
    public sealed record BanChatOwner : BanChatOwner<string>
    {
      public BanChatOwner(string username, long senderChatId) :
        base(username, senderChatId) { }
    }
  }
}
