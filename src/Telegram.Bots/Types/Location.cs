// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Types;

public sealed record Location(double Latitude, double Longitude)
{
  public double? HorizontalAccuracy { get; init; }

  public int? LivePeriod { get; init; }

  public uint? Heading { get; init; }

  public uint? ProximityAlertRadius { get; init; }
}
