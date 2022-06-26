// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2021-2022 Aman Agnihotri

namespace Telegram.Bots.Requests.Admins
{
  public abstract record ApproveChatJoinRequest<TChatId>(
    TChatId ChatId,
    long UserId) : IRequest<bool>, IChatMemberTargetable<TChatId>
  {
    public string Method => "approveChatJoinRequest";
  }

  public sealed record ApproveChatJoinRequest(
    long ChatId,
    long UserId) : ApproveChatJoinRequest<long>(ChatId, UserId);

  namespace Usernames
  {
    public sealed record ApproveChatJoinRequest(
      string ChatId,
      long UserId) : ApproveChatJoinRequest<string>(ChatId, UserId);
  }
}
