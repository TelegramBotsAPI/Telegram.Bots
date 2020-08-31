// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System;

namespace Telegram.Bots.Types.Inline
{
  public sealed class InlineArticle : ReplaceableResult, IThumbable
  {
    public override ResultType Type { get; } = ResultType.Article;

    public string Title { get; }

    public Uri? Url { get; set; }

    public bool? HideUrl { get; set; }

    public string? Description { get; set; }

    public Uri? Thumb { get; set; }

    public int? ThumbWidth { get; set; }

    public int? ThumbHeight { get; set; }

    public InlineArticle(string id, string title) : base(id) => Title = title;
  }
}
