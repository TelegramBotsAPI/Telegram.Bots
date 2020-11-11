// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Requests
{
  public abstract record GetChatMembersCount<TChatId> : IRequest<uint>, IChatTargetable<TChatId>
  {
    public TChatId ChatId { get; }

    public string Method { get; } = "getChatMembersCount";

    protected GetChatMembersCount(TChatId chatId) => ChatId = chatId;
  }

  public sealed record GetChatMembersCount : GetChatMembersCount<long>
  {
    public GetChatMembersCount(long chatId) : base(chatId) { }
  }

  namespace Usernames
  {
    public sealed record GetChatMembersCount : GetChatMembersCount<string>
    {
      public GetChatMembersCount(string username) : base(username) { }
    }
  }
}
