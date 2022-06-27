// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2021-2022 Aman Agnihotri

namespace Telegram.Bots.Requests.Admins
{
  public abstract record DeclineChatJoinRequest<TChatId>(
    TChatId ChatId,
    long UserId) : IRequest<bool>, IChatMemberTargetable<TChatId>
  {
    public string Method => "declineChatJoinRequest";
  }

  public sealed record DeclineChatJoinRequest(
    long ChatId,
    long UserId) : DeclineChatJoinRequest<long>(ChatId, UserId);

  namespace Usernames
  {
    public sealed record DeclineChatJoinRequest(
      string ChatId,
      long UserId) : DeclineChatJoinRequest<string>(ChatId, UserId);
  }
}
