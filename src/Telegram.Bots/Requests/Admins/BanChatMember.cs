// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests.Admins
{
  using System;

  public abstract record BanChatMember<TChatId>(
    TChatId ChatId,
    long UserId) : IRequest<bool>, IChatMemberTargetable<TChatId>
  {
    public DateTime? UntilDate { get; init; }

    public bool? RevokeMessages { get; init; }

    public string Method => "banChatMember";
  }

  public sealed record BanChatMember(
    long ChatId,
    long UserId) : BanChatMember<long>(ChatId, UserId);

  namespace Usernames
  {
    public sealed record BanChatMember(
      string ChatId,
      long UserId) : BanChatMember<string>(ChatId, UserId);
  }
}
