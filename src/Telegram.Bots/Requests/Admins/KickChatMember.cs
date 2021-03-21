// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2021 Aman Agnihotri

using System;

namespace Telegram.Bots.Requests.Admins
{
  public abstract record KickChatMember<TChatId> : IRequest<bool>, IChatMemberTargetable<TChatId>
  {
    public TChatId ChatId { get; }

    public long UserId { get; }

    public DateTime? UntilDate { get; init; }

    public bool? RevokeMessages { get; init; }

    public string Method { get; } = "kickChatMember";

    protected KickChatMember(TChatId chatId, long userId)
    {
      ChatId = chatId;
      UserId = userId;
    }
  }

  public sealed record KickChatMember : KickChatMember<long>
  {
    public KickChatMember(long chatId, long userId) : base(chatId, userId) { }
  }

  namespace Usernames
  {
    public sealed record KickChatMember : KickChatMember<string>
    {
      public KickChatMember(string username, long userId) : base(username, userId) { }
    }
  }
}
