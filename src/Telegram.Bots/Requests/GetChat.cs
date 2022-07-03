// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests
{
  using Types;

  public abstract record GetChat<TChatId>(
    TChatId ChatId) : IRequest<ChatInfo>, IChatTargetable<TChatId>
  {
    public string Method => "getChat";
  }

  public sealed record GetChat(long ChatId) : GetChat<long>(ChatId);

  namespace Usernames
  {
    public sealed record GetChat(string ChatId) : GetChat<string>(ChatId);
  }
}
