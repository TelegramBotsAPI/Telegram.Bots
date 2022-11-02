// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Types.Stickers;

public sealed record Sticker : File
{
  public int Width { get; init; }

  public int Height { get; init; }

  public bool IsAnimated { get; init; }

  public bool IsVideo { get; init; }

  public Photo? Thumb { get; init; }

  public string? Emoji { get; init; }

  public string? SetName { get; init; }

  public File? PremiumAnimation { get; init; }

  public MaskPosition? MaskPosition { get; init; }
}
