// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests
{
  using Types;

  public abstract record SendVenue<TChatId>(
    TChatId ChatId,
    double Latitude,
    double Longitude,
    string Title,
    string Address) : IRequest<LocationMessage>, IChatTargetable<TChatId>,
    INotifiable, IProtectable, IReplyable, IMarkupable
  {
    public string? FoursquareId { get; init; }

    public string? FoursquareType { get; init; }

    public string? GooglePlaceId { get; init; }

    public string? GooglePlaceType { get; init; }

    public bool? DisableNotification { get; init; }

    public bool? ProtectContent { get; init; }

    public int? ReplyToMessageId { get; init; }

    public bool? AllowSendingWithoutReply { get; init; }

    public ReplyMarkup? ReplyMarkup { get; init; }

    public string Method => "sendVenue";
  }

  public sealed record SendVenue(
    long ChatId,
    double Latitude,
    double Longitude,
    string Title,
    string Address) :
    SendVenue<long>(ChatId, Latitude, Longitude, Title, Address);

  namespace Usernames
  {
    public sealed record SendVenue(
      string ChatId,
      double Latitude,
      double Longitude,
      string Title,
      string Address) :
      SendVenue<string>(ChatId, Latitude, Longitude, Title, Address);
  }
}
