// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2021 Aman Agnihotri

using System;
using Telegram.Bots.Types;

namespace Telegram.Bots.Requests.Admins
{
  public abstract record CreateChatInviteLink<TChatId> : IRequest<ChatInviteLink>,
    IChatTargetable<TChatId>
  {
    public TChatId ChatId { get; }

    public DateTime? ExpireDate { get; init; }

    public int? MemberLimit { get; init; }

    public string Method { get; } = "createChatInviteLink";

    protected CreateChatInviteLink(TChatId chatId) => ChatId = chatId;
  }

  public sealed record CreateChatInviteLink : CreateChatInviteLink<long>
  {
    public CreateChatInviteLink(long chatId) : base(chatId) { }
  }

  namespace Usernames
  {
    public sealed record CreateChatInviteLink : CreateChatInviteLink<string>
    {
      public CreateChatInviteLink(string username) : base(username) { }
    }
  }
}
