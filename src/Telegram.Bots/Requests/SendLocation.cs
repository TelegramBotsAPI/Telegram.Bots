// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public abstract class SendLocation<TChatId> : IRequest<LocationMessage>,
    IChatTargetable<TChatId>, INotifiable, IReplyable, IMarkupable
  {
    public TChatId ChatId { get; }

    public double Latitude { get; }

    public double Longitude { get; }

    public double? HorizontalAccuracy { get; set; }

    public int? LivePeriod { get; set; }

    public uint? Heading { get; set; }

    public uint? ProximityAlertRadius { get; set; }

    public bool? DisableNotification { get; set; }

    public int? ReplyToMessageId { get; set; }

    public bool? AllowSendingWithoutReply { get; set; }

    public ReplyMarkup? ReplyMarkup { get; set; }

    public string Method { get; } = "sendLocation";

    protected SendLocation(TChatId chatId, double latitude, double longitude)
    {
      ChatId = chatId;
      Latitude = latitude;
      Longitude = longitude;
    }
  }

  public sealed class SendLocation : SendLocation<long>
  {
    public SendLocation(long chatId, double latitude, double longitude) :
      base(chatId, latitude, longitude) { }
  }

  namespace Usernames
  {
    public sealed class SendLocation : SendLocation<string>
    {
      public SendLocation(string username, double latitude, double longitude) :
        base(username, latitude, longitude) { }
    }
  }
}
