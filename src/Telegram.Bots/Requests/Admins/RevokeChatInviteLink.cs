// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2021 Aman Agnihotri

using Telegram.Bots.Types;

namespace Telegram.Bots.Requests.Admins
{
  public abstract record RevokeChatInviteLink<TChatId> : IRequest<ChatInviteLink>,
    IChatTargetable<TChatId>
  {
    public TChatId ChatId { get; }

    public string InviteLink { get; }

    public string Method { get; } = "revokeChatInviteLink";

    protected RevokeChatInviteLink(TChatId chatId, string inviteLink)
    {
      ChatId = chatId;
      InviteLink = inviteLink;
    }
  }

  public sealed record RevokeChatInviteLink : RevokeChatInviteLink<long>
  {
    public RevokeChatInviteLink(long chatId, string inviteLink) : base(chatId, inviteLink) { }
  }

  namespace Usernames
  {
    public sealed record RevokeChatInviteLink : RevokeChatInviteLink<string>
    {
      public RevokeChatInviteLink(string username, string inviteLink) :
        base(username, inviteLink) { }
    }
  }
}
