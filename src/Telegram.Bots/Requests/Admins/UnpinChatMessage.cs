// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests.Admins
{
  public abstract record UnpinChatMessage<TChatId>(
    TChatId ChatId) : IRequest<bool>, IChatTargetable<TChatId>
  {
    public int? MessageId { get; init; }

    public string Method => "unpinChatMessage";
  }

  public sealed record UnpinChatMessage(
    long ChatId) : UnpinChatMessage<long>(ChatId);

  namespace Usernames
  {
    public sealed record UnpinChatMessage(
      string ChatId) : UnpinChatMessage<string>(ChatId);
  }
}
