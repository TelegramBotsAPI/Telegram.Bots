// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using Telegram.Bots.Types.Stickers;

namespace Telegram.Bots.Requests.Stickers
{
  public sealed class GetStickerSet : IRequest<StickerSet>
  {
    public string Name { get; }

    public string Method { get; } = "getStickerSet";

    public GetStickerSet(string name) => Name = name;
  }
}
