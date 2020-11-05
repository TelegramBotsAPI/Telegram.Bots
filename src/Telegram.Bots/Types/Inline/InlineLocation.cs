// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System;

namespace Telegram.Bots.Types.Inline
{
  public sealed class InlineLocation : ReplaceableResult, IThumbable
  {
    public override ResultType Type { get; } = ResultType.Location;

    public string Title { get; }

    public double Latitude { get; }

    public double Longitude { get; }

    public double? HorizontalAccuracy { get; set; }

    public int? LivePeriod { get; set; }

    public uint? Heading { get; set; }

    public uint? ProximityAlertRadius { get; set; }

    public Uri? Thumb { get; set; }

    public int? ThumbWidth { get; set; }

    public int? ThumbHeight { get; set; }

    public InlineLocation(string id, string title, double latitude, double longitude) : base(id)
    {
      Title = title;
      Latitude = latitude;
      Longitude = longitude;
    }
  }
}
