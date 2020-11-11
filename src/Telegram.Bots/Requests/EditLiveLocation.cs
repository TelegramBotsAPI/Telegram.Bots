// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public abstract record EditLiveLocationBase<TResult> : IRequest<TResult>, IInlineMarkupable
  {
    public double Latitude { get; }

    public double Longitude { get; }

    public double? HorizontalAccuracy { get; init; }

    public uint? Heading { get; init; }

    public uint? ProximityAlertRadius { get; init; }

    public InlineKeyboardMarkup? ReplyMarkup { get; init; }

    public string Method { get; } = "editMessageLiveLocation";

    protected EditLiveLocationBase(double latitude, double longitude)
    {
      Latitude = latitude;
      Longitude = longitude;
    }
  }

  public abstract record EditLiveLocation<TChatId> : EditLiveLocationBase<LocationMessage>,
    IChatMessageTargetable<TChatId>
  {
    public TChatId ChatId { get; }

    public int MessageId { get; }

    protected EditLiveLocation(TChatId chatId, int messageId, double latitude, double longitude) :
      base(latitude, longitude)
    {
      ChatId = chatId;
      MessageId = messageId;
    }
  }

  public sealed record EditLiveLocation : EditLiveLocation<long>
  {
    public EditLiveLocation(long chatId, int messageId, double latitude, double longitude) :
      base(chatId, messageId, latitude, longitude) { }
  }

  namespace Usernames
  {
    public sealed record EditLiveLocation : EditLiveLocation<string>
    {
      public EditLiveLocation(string username, int messageId, double latitude, double longitude) :
        base(username, messageId, latitude, longitude) { }
    }
  }

  namespace Inline
  {
    public sealed record EditLiveLocation : EditLiveLocationBase<bool>, IInlineMessageTargetable
    {
      public string MessageId { get; }

      public EditLiveLocation(string messageId, double latitude, double longitude) :
        base(latitude, longitude) => MessageId = messageId;
    }
  }
}
