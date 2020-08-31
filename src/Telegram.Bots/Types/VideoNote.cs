// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Types
{
  public sealed class VideoNote : File
  {
    public int Length { get; set; }

    public int Duration { get; set; }

    public Photo? Thumb { get; set; }
  }
}
