// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests
{
  using Types;

  public abstract record SendLocation<TChatId>(
    TChatId ChatId,
    double Latitude,
    double Longitude) : IRequest<LocationMessage>, IChatTargetable<TChatId>,
    INotifiable, IProtectable, IReplyable, IMarkupable
  {
    public double? HorizontalAccuracy { get; init; }

    public int? LivePeriod { get; init; }

    public uint? Heading { get; init; }

    public uint? ProximityAlertRadius { get; init; }

    public bool? DisableNotification { get; init; }

    public bool? ProtectContent { get; init; }

    public int? ReplyToMessageId { get; init; }

    public bool? AllowSendingWithoutReply { get; init; }

    public ReplyMarkup? ReplyMarkup { get; init; }

    public string Method => "sendLocation";
  }

  public sealed record SendLocation(
    long ChatId,
    double Latitude,
    double Longitude) : SendLocation<long>(ChatId, Latitude, Longitude);

  namespace Usernames
  {
    public sealed record SendLocation(
      string ChatId,
      double Latitude,
      double Longitude) : SendLocation<string>(ChatId, Latitude, Longitude);
  }
}
