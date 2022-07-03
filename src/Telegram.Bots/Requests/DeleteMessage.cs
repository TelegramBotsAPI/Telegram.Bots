// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests
{
  public abstract record DeleteMessage<TChatId>(
    TChatId ChatId,
    int MessageId) : IRequest<bool>, IChatMessageTargetable<TChatId>
  {
    public string Method => "deleteMessage";
  }

  public sealed record DeleteMessage(
    long ChatId,
    int MessageId) : DeleteMessage<long>(ChatId, MessageId);

  namespace Usernames
  {
    public sealed record DeleteMessage(
      string ChatId,
      int MessageId) : DeleteMessage<string>(ChatId, MessageId);
  }
}
