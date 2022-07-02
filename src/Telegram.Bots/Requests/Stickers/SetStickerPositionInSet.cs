// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests.Stickers;

public sealed record SetStickerPositionInSet(
  string Sticker,
  uint Position) : IRequest<bool>
{
  public string Method => "setStickerPositionInSet";
}
