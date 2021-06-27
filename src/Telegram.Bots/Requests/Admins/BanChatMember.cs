// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2021 Aman Agnihotri

using System;

namespace Telegram.Bots.Requests.Admins
{
  public abstract record BanChatMember<TChatId> : IRequest<bool>, IChatMemberTargetable<TChatId>
  {
    public TChatId ChatId { get; }

    public long UserId { get; }

    public DateTime? UntilDate { get; init; }

    public bool? RevokeMessages { get; init; }

    public string Method { get; } = "banChatMember";

    protected BanChatMember(TChatId chatId, long userId)
    {
      ChatId = chatId;
      UserId = userId;
    }
  }

  public sealed record BanChatMember : BanChatMember<long>
  {
    public BanChatMember(long chatId, long userId) : base(chatId, userId) { }
  }

  namespace Usernames
  {
    public sealed record BanChatMember : BanChatMember<string>
    {
      public BanChatMember(string username, long userId) : base(username, userId) { }
    }
  }
}
