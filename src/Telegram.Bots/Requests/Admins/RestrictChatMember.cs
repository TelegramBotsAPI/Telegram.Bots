// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests.Admins
{
  using System;
  using Types;

  public abstract record RestrictChatMember<TChatId>(
    TChatId ChatId,
    long UserId,
    ChatPermissions Permissions) : IRequest<bool>,
    IChatMemberTargetable<TChatId>
  {
    public DateTime? UntilDate { get; init; }

    public string Method => "restrictChatMember";
  }

  public sealed record RestrictChatMember(
    long ChatId,
    long UserId,
    ChatPermissions Permissions) :
    RestrictChatMember<long>(ChatId, UserId, Permissions);

  namespace Usernames
  {
    public sealed record RestrictChatMember(
      string ChatId,
      long UserId,
      ChatPermissions Permissions) :
      RestrictChatMember<string>(ChatId, UserId, Permissions);
  }
}
