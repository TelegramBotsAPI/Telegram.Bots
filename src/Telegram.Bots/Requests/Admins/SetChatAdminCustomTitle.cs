// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests.Admins
{
  public abstract record SetChatAdminCustomTitle<TChatId>(
    TChatId ChatId,
    long UserId,
    string CustomTitle) : IRequest<bool>, IChatMemberTargetable<TChatId>
  {
    public string Method => "setChatAdministratorCustomTitle";
  }

  public sealed record SetChatAdminCustomTitle(
    long ChatId,
    long UserId,
    string CustomTitle) :
    SetChatAdminCustomTitle<long>(ChatId, UserId, CustomTitle);

  namespace Usernames
  {
    public sealed record SetChatAdminCustomTitle(
      string ChatId,
      long UserId,
      string CustomTitle) :
      SetChatAdminCustomTitle<string>(ChatId, UserId, CustomTitle);
  }
}
