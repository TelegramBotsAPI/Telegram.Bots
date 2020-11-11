// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Types
{
  public sealed record Video : File
  {
    public int Width { get; init; }

    public int Height { get; init; }

    public int Duration { get; init; }

    public Photo? Thumb { get; init; }

    public string? Name { get; init; }

    public string? MimeType { get; init; }
  }
}
