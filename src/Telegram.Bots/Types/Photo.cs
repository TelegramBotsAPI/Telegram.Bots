// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Types
{
  public sealed class Photo : File
  {
    public int Width { get; set; }

    public int Height { get; set; }
  }
}
