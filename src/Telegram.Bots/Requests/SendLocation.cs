// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public abstract record SendLocation<TChatId> : IRequest<LocationMessage>,
    IChatTargetable<TChatId>, INotifiable, IProtectable, IReplyable, IMarkupable
  {
    public TChatId ChatId { get; }

    public double Latitude { get; }

    public double Longitude { get; }

    public double? HorizontalAccuracy { get; init; }

    public int? LivePeriod { get; init; }

    public uint? Heading { get; init; }

    public uint? ProximityAlertRadius { get; init; }

    public bool? DisableNotification { get; init; }
    
    public bool? ProtectContent { get; init; }

    public int? ReplyToMessageId { get; init; }

    public bool? AllowSendingWithoutReply { get; init; }

    public ReplyMarkup? ReplyMarkup { get; init; }

    public string Method { get; } = "sendLocation";

    protected SendLocation(TChatId chatId, double latitude, double longitude)
    {
      ChatId = chatId;
      Latitude = latitude;
      Longitude = longitude;
    }
  }

  public sealed record SendLocation : SendLocation<long>
  {
    public SendLocation(long chatId, double latitude, double longitude) :
      base(chatId, latitude, longitude) { }
  }

  namespace Usernames
  {
    public sealed record SendLocation : SendLocation<string>
    {
      public SendLocation(string username, double latitude, double longitude) :
        base(username, latitude, longitude) { }
    }
  }
}
