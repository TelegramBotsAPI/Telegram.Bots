// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests
{
  using System.Collections.Generic;
  using Types;

  public abstract record CopyMessage<TChatId, TFromChatId>(
    TChatId ChatId,
    TFromChatId FromChatId,
    int MessageId) : IRequest<MessageId>, IChatMessageTargetable<TChatId>,
    ICaptionable, INotifiable, IProtectable, IReplyable, IMarkupable
  {
    public string? Caption { get; init; }

    public ParseMode? ParseMode { get; init; }

    public IEnumerable<MessageEntity>? CaptionEntities { get; init; }

    public bool? DisableNotification { get; init; }

    public bool? ProtectContent { get; init; }

    public int? ReplyToMessageId { get; init; }

    public bool? AllowSendingWithoutReply { get; init; }

    public ReplyMarkup? ReplyMarkup { get; init; }

    public string Method => "copyMessage";
  }

  public sealed record CopyMessage(
    long ChatId,
    long FromChatId,
    int MessageId) : CopyMessage<long, long>(ChatId, FromChatId, MessageId);

  public sealed record CopyMessageViaUsername(
    string ChatId,
    long FromChatId,
    int MessageId) : CopyMessage<string, long>(ChatId, FromChatId, MessageId);

  namespace Usernames
  {
    public sealed record CopyMessage(
      string ChatId,
      string FromChatId,
      int MessageId) :
      CopyMessage<string, string>(ChatId, FromChatId, MessageId);

    public sealed record CopyMessageViaId(
      long ChatId,
      string FromChatId,
      int MessageId) : CopyMessage<long, string>(ChatId, FromChatId, MessageId);
  }
}
