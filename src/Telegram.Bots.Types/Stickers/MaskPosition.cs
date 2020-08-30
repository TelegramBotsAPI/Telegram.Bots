// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Types.Stickers
{
  public sealed class MaskPosition
  {
    public MaskPositionPoint Point { get; set; }

    public float XShift { get; set; }

    public float YShift { get; set; }

    public float Scale { get; set; }
  }
}
