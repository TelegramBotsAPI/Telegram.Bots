// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Requests.Stickers
{
  public sealed class SetStickerPositionInSet : IRequest<bool>
  {
    public string Sticker { get; }

    public uint Position { get; }

    public string Method { get; } = "setStickerPositionInSet";

    public SetStickerPositionInSet(string sticker, uint position)
    {
      Sticker = sticker;
      Position = position;
    }
  }
}
