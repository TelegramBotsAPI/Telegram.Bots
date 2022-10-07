// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Types.Stickers;

public sealed record MaskPosition
{
  public MaskPositionPoint Point { get; init; }

  public float XShift { get; init; }

  public float YShift { get; init; }

  public float Scale { get; init; }
}
