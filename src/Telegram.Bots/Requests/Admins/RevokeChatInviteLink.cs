// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2021-2022 Aman Agnihotri

namespace Telegram.Bots.Requests.Admins
{
  using Types;

  public abstract record RevokeChatInviteLink<TChatId>(
    TChatId ChatId,
    string InviteLink) : IRequest<ChatInviteLink>, IChatTargetable<TChatId>
  {
    public string Method => "revokeChatInviteLink";
  }

  public sealed record RevokeChatInviteLink(
    long ChatId,
    string InviteLink) : RevokeChatInviteLink<long>(ChatId, InviteLink);

  namespace Usernames
  {
    public sealed record RevokeChatInviteLink(
      string ChatId,
      string InviteLink) : RevokeChatInviteLink<string>(ChatId, InviteLink);
  }
}
