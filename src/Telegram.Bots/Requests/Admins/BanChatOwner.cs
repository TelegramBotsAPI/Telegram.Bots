// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2022 Aman Agnihotri

namespace Telegram.Bots.Requests.Admins
{
  public abstract record BanChatOwner<TChatId>(
    TChatId ChatId,
    long SenderChatId) : IRequest<bool>, IChatOwnerTargetable<TChatId>
  {
    public string Method => "banChatSenderChat";
  }

  public sealed record BanChatOwner(
    long ChatId,
    long SenderChatId) : BanChatOwner<long>(ChatId, SenderChatId);

  namespace Usernames
  {
    public sealed record BanChatOwner(
      string ChatId,
      long SenderChatId) : BanChatOwner<string>(ChatId, SenderChatId);
  }
}
