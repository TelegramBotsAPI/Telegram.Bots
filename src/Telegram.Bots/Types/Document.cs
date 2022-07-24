// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Types;

public sealed record Document : File
{
  public Photo? Thumb { get; init; }

  public string? Name { get; init; }

  public string? MimeType { get; init; }
}
