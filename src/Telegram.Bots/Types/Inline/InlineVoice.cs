// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Types.Inline;

using System;
using System.Collections.Generic;

public abstract record InlineVoice<TVoice> : ReplaceableResult, ICaptionable
{
  public override ResultType Type { get; } = ResultType.Voice;

  public string Title { get; }

  public TVoice Voice { get; }

  public string? Caption { get; init; }

  public ParseMode? ParseMode { get; init; }

  public IEnumerable<MessageEntity>? CaptionEntities { get; init; }

  protected InlineVoice(string id, string title, TVoice voice) : base(id)
  {
    Title = title;
    Voice = voice;
  }
}

public sealed record InlineVoice : InlineVoice<Uri>
{
  public int? Duration { get; init; }

  public InlineVoice(string id, string title, Uri voice) : base(id, title,
    voice) { }
}

public sealed record InlineCachedVoice : InlineVoice<string>
{
  public InlineCachedVoice(string id, string title, string voice) : base(id,
    title, voice) { }
}
