// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Types
{
  public sealed class Animation : File
  {
    public int Width { get; set; }

    public int Height { get; set; }

    public int Duration { get; set; }

    public Photo? Thumb { get; set; }

    public string? Name { get; set; }

    public string? MimeType { get; set; }
  }
}
