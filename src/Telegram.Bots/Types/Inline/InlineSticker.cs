// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Types.Inline;

public abstract record InlineSticker<TSticker> : ReplaceableResult
{
  public override ResultType Type { get; } = ResultType.Sticker;

  public TSticker Sticker { get; }

  protected InlineSticker(string id, TSticker sticker) : base(id)
  {
    Sticker = sticker;
  }
}

public sealed record InlineCachedSticker : InlineSticker<string>
{
  public InlineCachedSticker(string id, string sticker) : base(id, sticker) { }
}
