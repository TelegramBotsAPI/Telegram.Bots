// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Types;

public sealed record Audio : File
{
  public int Duration { get; init; }

  public string? Performer { get; init; }

  public string? Title { get; init; }

  public string? Name { get; init; }

  public string? MimeType { get; init; }

  public Photo? Thumb { get; init; }
}
