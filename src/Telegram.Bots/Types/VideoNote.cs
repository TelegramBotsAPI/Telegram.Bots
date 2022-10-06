// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Types;

public sealed record VideoNote : File
{
  public int Length { get; init; }

  public int Duration { get; init; }

  public Photo? Thumb { get; init; }
}
