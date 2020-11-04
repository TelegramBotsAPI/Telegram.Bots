// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Types
{
  public sealed class Audio : File
  {
    public int Duration { get; set; }

    public string? Performer { get; set; }

    public string? Title { get; set; }

    public string? Name { get; set; }

    public string? MimeType { get; set; }

    public Photo? Thumb { get; set; }
  }
}
