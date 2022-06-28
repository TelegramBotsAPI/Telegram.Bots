// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests.Admins
{
  public abstract record SetChatDescription<TChatId>(
    TChatId ChatId,
    string Description) : IRequest<bool>, IChatTargetable<TChatId>
  {
    public string Method => "setChatDescription";
  }

  public sealed record SetChatDescription(
    long ChatId,
    string Description) : SetChatDescription<long>(ChatId, Description);

  namespace Usernames
  {
    public sealed record SetChatDescription(
      string ChatId,
      string Description) : SetChatDescription<string>(ChatId, Description);
  }
}
