// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2022 Aman Agnihotri

namespace Telegram.Bots.Requests.Stickers;

using System.Collections.Generic;
using Types.Stickers;

public sealed record GetCustomEmojiStickers(
  IEnumerable<string> CustomEmojiIds) : IRequest<IReadOnlyList<Sticker>>
{
  public string Method => "getCustomEmojiStickers";
}
