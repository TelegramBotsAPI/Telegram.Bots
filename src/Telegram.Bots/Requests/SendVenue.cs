// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public abstract class SendVenue<TChatId> : IRequest<LocationMessage>,
    IChatTargetable<TChatId>, INotifiable, IReplyable, IMarkupable
  {
    public TChatId ChatId { get; }

    public double Latitude { get; }

    public double Longitude { get; }

    public string Title { get; }

    public string Address { get; }

    public string? FoursquareId { get; set; }

    public string? FoursquareType { get; set; }

    public string? GooglePlaceId { get; set; }

    public string? GooglePlaceType { get; set; }

    public bool? DisableNotification { get; set; }

    public int? ReplyToMessageId { get; set; }

    public bool? AllowSendingWithoutReply { get; set; }

    public ReplyMarkup? ReplyMarkup { get; set; }

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

  public sealed class SendVenue : SendVenue<long>
  {
    public SendVenue(long chatId, double latitude, double longitude, string title, string address) :
      base(chatId, latitude, longitude, title, address) { }
  }

  namespace Usernames
  {
    public sealed class SendVenue : SendVenue<string>
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
