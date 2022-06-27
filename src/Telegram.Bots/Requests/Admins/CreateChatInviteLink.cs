// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2021-2022 Aman Agnihotri

namespace Telegram.Bots.Requests.Admins
{
  using System;
  using Types;

  public abstract record CreateChatInviteLink<TChatId>(
    TChatId ChatId) : IRequest<ChatInviteLink>, IChatTargetable<TChatId>
  {
    public string? Name { get; init; }

    public DateTime? ExpireDate { get; init; }

    public int? MemberLimit { get; init; }

    public bool? CreatesJoinRequest { get; init; }

    public string Method => "createChatInviteLink";
  }

  public sealed record CreateChatInviteLink(
    long ChatId) : CreateChatInviteLink<long>(ChatId);

  namespace Usernames
  {
    public sealed record CreateChatInviteLink(
      string ChatId) : CreateChatInviteLink<string>(ChatId);
  }
}
