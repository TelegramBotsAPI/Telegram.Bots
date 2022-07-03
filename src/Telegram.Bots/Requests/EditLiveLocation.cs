// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests
{
  using Types;

  public abstract record EditLiveLocationBase<TResult>(
    double Latitude,
    double Longitude) : IRequest<TResult>, IInlineMarkupable
  {
    public double? HorizontalAccuracy { get; init; }

    public uint? Heading { get; init; }

    public uint? ProximityAlertRadius { get; init; }

    public InlineKeyboardMarkup? ReplyMarkup { get; init; }

    public string Method => "editMessageLiveLocation";
  }

  public abstract record EditLiveLocation<TChatId>(
    TChatId ChatId,
    int MessageId,
    double Latitude,
    double Longitude) :
    EditLiveLocationBase<LocationMessage>(Latitude, Longitude),
    IChatMessageTargetable<TChatId>;

  public sealed record EditLiveLocation(
    long ChatId,
    int MessageId,
    double Latitude,
    double Longitude) :
    EditLiveLocation<long>(ChatId, MessageId, Latitude, Longitude);

  namespace Usernames
  {
    public sealed record EditLiveLocation(
      string ChatId,
      int MessageId,
      double Latitude,
      double Longitude) :
      EditLiveLocation<string>(ChatId, MessageId, Latitude, Longitude);
  }

  namespace Inline
  {
    public sealed record EditLiveLocation(
      string MessageId,
      double Latitude,
      double Longitude) : EditLiveLocationBase<bool>(Latitude, Longitude),
      IInlineMessageTargetable;
  }
}
