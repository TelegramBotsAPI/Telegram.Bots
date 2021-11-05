// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2021 Aman Agnihotri

namespace Telegram.Bots.Requests.Admins
{
  public abstract record DeclineChatJoinRequest<TChatId> : IRequest<bool>,
    IChatMemberTargetable<TChatId>
  {
    public TChatId ChatId { get; }

    public long UserId { get; }

    public string Method { get; } = "declineChatJoinRequest";

    protected DeclineChatJoinRequest(TChatId chatId, long userId)
    {
      ChatId = chatId;
      UserId = userId;
    }
  }

  public sealed record DeclineChatJoinRequest : DeclineChatJoinRequest<long>
  {
    public DeclineChatJoinRequest(long chatId, long userId) :
      base(chatId, userId) { }
  }

  namespace Usernames
  {
    public sealed record DeclineChatJoinRequest : DeclineChatJoinRequest<string>
    {
      public DeclineChatJoinRequest(string username, long userId) :
        base(username, userId) { }
    }
  }
}
