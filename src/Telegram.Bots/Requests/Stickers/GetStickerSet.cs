// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests.Stickers;

using Types.Stickers;

public sealed record GetStickerSet(string Name) : IRequest<StickerSet>
{
  public string Method => "getStickerSet";
}
