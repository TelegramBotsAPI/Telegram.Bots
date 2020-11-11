// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public abstract record SendVenue<TChatId> : IRequest<LocationMessage>,
    IChatTargetable<TChatId>, INotifiable, IReplyable, IMarkupable
  {
    public TChatId ChatId { get; }

    public double Latitude { get; }

    public double Longitude { get; }

    public string Title { get; }

    public string Address { get; }

    public string? FoursquareId { get; init; }

    public string? FoursquareType { get; init; }

    public string? GooglePlaceId { get; init; }

    public string? GooglePlaceType { get; init; }

    public bool? DisableNotification { get; init; }

    public int? ReplyToMessageId { get; init; }

    public bool? AllowSendingWithoutReply { get; init; }

    public ReplyMarkup? ReplyMarkup { get; init; }

    public string Method { get; } = "sendVenue";

    protected SendVenue(
      TChatId chatId,
      double latitude,
      double longitude,
      string title,
      string address)
    {
      ChatId = chatId;
      Latitude = latitude;
      Longitude = longitude;
      Title = title;
      Address = address;
    }
  }

  public sealed record SendVenue : SendVenue<long>
  {
    public SendVenue(long chatId, double latitude, double longitude, string title, string address) :
      base(chatId, latitude, longitude, title, address) { }
  }

  namespace Usernames
  {
    public sealed record SendVenue : SendVenue<string>
    {
      public SendVenue(
        string username,
        double latitude,
        double longitude,
        string title,
        string address) : base(username, latitude, longitude, title, address) { }
    }
  }
}
