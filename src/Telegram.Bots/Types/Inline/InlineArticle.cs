// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Types.Inline;

using System;

public sealed record InlineArticle : ReplaceableResult, IThumbable
{
  public override ResultType Type { get; } = ResultType.Article;

  public string Title { get; }

  public Uri? Url { get; init; }

  public bool? HideUrl { get; init; }

  public string? Description { get; init; }

  public Uri? Thumb { get; init; }

  public int? ThumbWidth { get; init; }

  public int? ThumbHeight { get; init; }

  public InlineArticle(string id, string title) : base(id)
  {
    Title = title;
  }
}
