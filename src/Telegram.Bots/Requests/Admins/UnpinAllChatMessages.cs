// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests.Admins
{
  public abstract record UnpinAllChatMessages<TChatId>(
    TChatId ChatId) : IRequest<bool>, IChatTargetable<TChatId>
  {
    public string Method => "unpinAllChatMessages";
  }

  public sealed record UnpinAllChatMessages(
    long ChatId) : UnpinAllChatMessages<long>(ChatId);

  namespace Usernames
  {
    public sealed record UnpinAllChatMessages(
      string ChatId) : UnpinAllChatMessages<string>(ChatId);
  }
}
