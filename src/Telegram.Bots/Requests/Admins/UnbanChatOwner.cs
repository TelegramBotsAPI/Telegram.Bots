// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2022 Aman Agnihotri

namespace Telegram.Bots.Requests.Admins
{
  public abstract record UnbanChatOwner<TChatId>(
    TChatId ChatId,
    long SenderChatId) : IRequest<bool>, IChatOwnerTargetable<TChatId>
  {
    public string Method => "unbanChatSenderChat";
  }

  public sealed record UnbanChatOwner(
    long ChatId,
    long SenderChatId) : UnbanChatOwner<long>(ChatId, SenderChatId);

  namespace Usernames
  {
    public sealed record UnbanChatOwner(
      string ChatId,
      long SenderChatId) : UnbanChatOwner<string>(ChatId, SenderChatId);
  }
}
