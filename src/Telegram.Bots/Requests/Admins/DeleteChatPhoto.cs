// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests.Admins
{
  public abstract record DeleteChatPhoto<TChatId>(
    TChatId ChatId) : IRequest<bool>, IChatTargetable<TChatId>
  {
    public string Method => "deleteChatPhoto";
  }

  public sealed record DeleteChatPhoto(
    long ChatId) : DeleteChatPhoto<long>(ChatId);

  namespace Usernames
  {
    public sealed record DeleteChatPhoto(
      string ChatId) : DeleteChatPhoto<string>(ChatId);
  }
}
