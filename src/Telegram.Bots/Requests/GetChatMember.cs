// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public abstract record GetChatMember<TChatId> : IRequest<ChatMember>,
    IChatMemberTargetable<TChatId>
  {
    public TChatId ChatId { get; }

    public long UserId { get; }

    public string Method { get; } = "getChatMember";

    protected GetChatMember(TChatId chatId, long userId)
    {
      ChatId = chatId;
      UserId = userId;
    }
  }

  public sealed record GetChatMember : GetChatMember<long>
  {
    public GetChatMember(long chatId, long userId) : base(chatId, userId) { }
  }

  namespace Usernames
  {
    public sealed record GetChatMember : GetChatMember<string>
    {
      public GetChatMember(string username, long userId) : base(username, userId) { }
    }
  }
}
