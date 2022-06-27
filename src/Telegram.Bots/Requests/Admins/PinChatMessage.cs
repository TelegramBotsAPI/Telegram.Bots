// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests.Admins
{
  public abstract record PinChatMessage<TChatId>(
    TChatId ChatId,
    int MessageId) : IRequest<bool>, IChatMessageTargetable<TChatId>,
    INotifiable
  {
    public bool? DisableNotification { get; init; }

    public string Method => "pinChatMessage";
  }

  public sealed record PinChatMessage(
    long ChatId,
    int MessageId) : PinChatMessage<long>(ChatId, MessageId);

  namespace Usernames
  {
    public sealed record PinChatMessage(
      string ChatId,
      int MessageId) : PinChatMessage<string>(ChatId, MessageId);
  }
}
