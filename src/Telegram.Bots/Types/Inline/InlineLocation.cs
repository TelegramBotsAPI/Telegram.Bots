// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Types.Inline;

using System;

public sealed record InlineLocation : ReplaceableResult, IThumbable
{
  public override ResultType Type { get; } = ResultType.Location;

  public string Title { get; }

  public double Latitude { get; }

  public double Longitude { get; }

  public double? HorizontalAccuracy { get; init; }

  public int? LivePeriod { get; init; }

  public uint? Heading { get; init; }

  public uint? ProximityAlertRadius { get; init; }

  public Uri? Thumb { get; init; }

  public int? ThumbWidth { get; init; }

  public int? ThumbHeight { get; init; }

  public InlineLocation(
    string id,
    string title,
    double latitude,
    double longitude) : base(id)
  {
    Title = title;
    Latitude = latitude;
    Longitude = longitude;
  }
}
