// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System;
using System.Collections.Generic;

namespace Telegram.Bots.Types.Inline
{
  public abstract record InlineAudio<TAudio> : ReplaceableResult, ICaptionable
  {
    public override ResultType Type { get; } = ResultType.Audio;

    public TAudio Audio { get; }

    public string? Caption { get; init; }

    public ParseMode? ParseMode { get; init; }

    public IEnumerable<MessageEntity>? CaptionEntities { get; init; }

    protected InlineAudio(string id, TAudio audio) : base(id) => Audio = audio;
  }

  public sealed record InlineAudio : InlineAudio<Uri>
  {
    public string Title { get; }

    public string? Performer { get; init; }

    public int? Duration { get; init; }

    public InlineAudio(string id, string title, Uri audio) : base(id, audio) => Title = title;
  }

  public sealed record InlineCachedAudio : InlineAudio<string>
  {
    public InlineCachedAudio(string id, string audio) : base(id, audio) { }
  }
}
