// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Types.Inline
{
  public abstract class InlineSticker<TSticker> : ReplaceableResult
  {
    public override ResultType Type { get; } = ResultType.Sticker;

    public TSticker Sticker { get; }

    protected InlineSticker(string id, TSticker sticker) : base(id) => Sticker = sticker;
  }

  public sealed class InlineCachedSticker : InlineSticker<string>
  {
    public InlineCachedSticker(string id, string sticker) : base(id, sticker) { }
  }
}
