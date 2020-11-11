// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Types
{
  public sealed record Location
  {
    public double Latitude { get; init; }

    public double Longitude { get; init; }

    public double? HorizontalAccuracy { get; init; }

    public int? LivePeriod { get; init; }

    public uint? Heading { get; init; }

    public uint? ProximityAlertRadius { get; init; }
  }
}
