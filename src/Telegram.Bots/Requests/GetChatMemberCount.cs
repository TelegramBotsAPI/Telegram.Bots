// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2021 Aman Agnihotri

namespace Telegram.Bots.Requests
{
  public abstract record GetChatMemberCount<TChatId> : IRequest<uint>, IChatTargetable<TChatId>
  {
    public TChatId ChatId { get; }

    public string Method { get; } = "getChatMemberCount";

    protected GetChatMemberCount(TChatId chatId) => ChatId = chatId;
  }

  public sealed record GetChatMemberCount : GetChatMemberCount<long>
  {
    public GetChatMemberCount(long chatId) : base(chatId) { }
  }

  namespace Usernames
  {
    public sealed record GetChatMemberCount : GetChatMemberCount<string>
    {
      public GetChatMemberCount(string username) : base(username) { }
    }
  }
}
