// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2021 Aman Agnihotri

namespace Telegram.Bots.Requests.Admins
{
  public abstract record ApproveChatJoinRequest<TChatId> : IRequest<bool>,
    IChatMemberTargetable<TChatId>
  {
    public TChatId ChatId { get; }

    public long UserId { get; }

    public string Method { get; } = "approveChatJoinRequest";

    protected ApproveChatJoinRequest(TChatId chatId, long userId)
    {
      ChatId = chatId;
      UserId = userId;
    }
  }

  public sealed record ApproveChatJoinRequest : ApproveChatJoinRequest<long>
  {
    public ApproveChatJoinRequest(long chatId, long userId) :
      base(chatId, userId) { }
  }

  namespace Usernames
  {
    public sealed record ApproveChatJoinRequest : ApproveChatJoinRequest<string>
    {
      public ApproveChatJoinRequest(string username, long userId) :
        base(username, userId) { }
    }
  }
}
