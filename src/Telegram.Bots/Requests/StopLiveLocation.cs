// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests
{
  using Types;

  public abstract record StopLiveLocationBase<TResult> : IRequest<TResult>,
    IInlineMarkupable
  {
    public InlineKeyboardMarkup? ReplyMarkup { get; init; }

    public string Method => "stopMessageLiveLocation";
  }

  public abstract record StopLiveLocation<TChatId>(
    TChatId ChatId,
    int MessageId) : StopLiveLocationBase<LocationMessage>,
    IChatMessageTargetable<TChatId>;

  public sealed record StopLiveLocation(
    long ChatId,
    int MessageId) : StopLiveLocation<long>(ChatId, MessageId);

  namespace Usernames
  {
    public sealed record StopLiveLocation(
      string ChatId,
      int MessageId) : StopLiveLocation<string>(ChatId, MessageId);
  }

  namespace Inline
  {
    public sealed record StopLiveLocation(
      string MessageId) : StopLiveLocationBase<bool>, IInlineMessageTargetable;
  }
}
