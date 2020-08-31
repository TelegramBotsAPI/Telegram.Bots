// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System;

namespace Telegram.Bots.Types.Inline
{
  public abstract class InlineAudio<TAudio> : ReplaceableResult
  {
    public override ResultType Type { get; } = ResultType.Audio;

    public TAudio Audio { get; }

    public string? Caption { get; set; }

    public ParseMode? ParseMode { get; set; }

    protected InlineAudio(string id, TAudio audio) : base(id) => Audio = audio;
  }

  public sealed class InlineAudio : InlineAudio<Uri>
  {
    public string Title { get; }

    public string? Performer { get; set; }

    public int? Duration { get; set; }

    public InlineAudio(string id, string title, Uri audio) : base(id, audio) => Title = title;
  }

  public sealed class InlineCachedAudio : InlineAudio<string>
  {
    public InlineCachedAudio(string id, string audio) : base(id, audio) { }
  }
}
