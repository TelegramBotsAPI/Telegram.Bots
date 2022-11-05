// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Types.Stickers;

using System.Collections.Generic;

public sealed record StickerSet
{
  public string Name { get; init; } = null!;

  public string Title { get; init; } = null!;

  public StickerType StickerType { get; init; }

  public bool IsAnimated { get; init; }

  public bool IsVideo { get; init; }

  [System.Obsolete("Use StickerType.")]
  public bool ContainsMasks { get; init; }

  public IReadOnlyList<Sticker> Stickers { get; init; } = null!;

  public Photo? Thumb { get; init; }
}
