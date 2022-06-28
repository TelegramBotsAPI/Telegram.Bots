// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests.Admins
{
  public abstract record UnbanChatMember<TChatId>(
    TChatId ChatId,
    long UserId) : IRequest<bool>, IChatMemberTargetable<TChatId>
  {
    public bool? OnlyIfBanned { get; init; }

    public string Method => "unbanChatMember";
  }

  public sealed record UnbanChatMember(
    long ChatId,
    long UserId) : UnbanChatMember<long>(ChatId, UserId);

  namespace Usernames
  {
    public sealed record UnbanChatMember(
      string ChatId,
      long UserId) : UnbanChatMember<string>(ChatId, UserId);
  }
}
