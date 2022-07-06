// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests
{
  using Types;

  public abstract record SendChatAction<TChatId>(
    TChatId ChatId,
    ChatAction Action) : IRequest<bool>, IChatTargetable<TChatId>
  {
    public string Method => "sendChatAction";
  }

  public sealed record SendChatAction(
    long ChatId,
    ChatAction Action) : SendChatAction<long>(ChatId, Action);

  namespace Usernames
  {
    public sealed record SendChatAction(
      string ChatId,
      ChatAction Action) : SendChatAction<string>(ChatId, Action);
  }
}
