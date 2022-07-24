// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Types;

public abstract record File
{
  public string Id { get; init; } = null!;

  public string UniqueId { get; init; } = null!;

  public int? Size { get; init; }
}

public sealed record FileInfo : File
{
  public string? Path { get; init; }
}
