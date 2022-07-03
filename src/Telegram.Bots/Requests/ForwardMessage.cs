// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests
{
  using Types;

  public abstract record ForwardMessage<TChatId, TFromChatId>(
    TChatId ChatId,
    TFromChatId FromChatId,
    int MessageId) : IRequest<Message>, IChatMessageTargetable<TChatId>,
    INotifiable, IProtectable
  {
    public bool? DisableNotification { get; init; }

    public bool? ProtectContent { get; init; }

    public string Method => "forwardMessage";
  }

  public sealed record ForwardMessage(
    long ChatId,
    long FromChatId,
    int MessageId) : ForwardMessage<long, long>(ChatId, FromChatId, MessageId);

  public sealed record ForwardMessageViaUsername(
    string ChatId,
    long FromChatId,
    int MessageId) :
    ForwardMessage<string, long>(ChatId, FromChatId, MessageId);

  namespace Usernames
  {
    public sealed record ForwardMessage(
      string ChatId,
      string FromChatId,
      int MessageId) :
      ForwardMessage<string, string>(ChatId, FromChatId, MessageId);

    public sealed record ForwardMessageViaId(
      long ChatId,
      string FromChatId,
      int MessageId) :
      ForwardMessage<long, string>(ChatId, FromChatId, MessageId);
  }
}
