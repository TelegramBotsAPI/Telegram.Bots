// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests.Admins
{
  public abstract record SetChatTitle<TChatId>(
    TChatId ChatId,
    string Title) : IRequest<bool>, IChatTargetable<TChatId>
  {
    public string Method => "setChatTitle";
  }

  public sealed record SetChatTitle(
    long ChatId,
    string Title) : SetChatTitle<long>(ChatId, Title);

  namespace Usernames
  {
    public sealed record SetChatTitle(
      string ChatId,
      string Title) : SetChatTitle<string>(ChatId, Title);
  }
}
