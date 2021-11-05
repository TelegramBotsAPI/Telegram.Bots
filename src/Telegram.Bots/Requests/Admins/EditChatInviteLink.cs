// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2021 Aman Agnihotri

using System;
using Telegram.Bots.Types;

namespace Telegram.Bots.Requests.Admins
{
  public abstract record EditChatInviteLink<TChatId> : IRequest<ChatInviteLink>,
    IChatTargetable<TChatId>
  {
    public TChatId ChatId { get; }

    public string InviteLink { get; }
    
    public string? Name { get; init; }

    public DateTime? ExpireDate { get; init; }

    public int? MemberLimit { get; init; }
    
    public bool? CreatesJoinRequest { get; init; }

    public string Method { get; } = "editChatInviteLink";

    protected EditChatInviteLink(TChatId chatId, string inviteLink)
    {
      ChatId = chatId;
      InviteLink = inviteLink;
    }
  }

  public sealed record EditChatInviteLink : EditChatInviteLink<long>
  {
    public EditChatInviteLink(long chatId, string inviteLink) : base(chatId, inviteLink) { }
  }

  namespace Usernames
  {
    public sealed record EditChatInviteLink : EditChatInviteLink<string>
    {
      public EditChatInviteLink(string username, string inviteLink) : base(username, inviteLink) { }
    }
  }
}
