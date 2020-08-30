using System;

namespace Telegram.Bots.Types.Inline
{
  public abstract class InlineGif<TGif> : ReplaceableResult
  {
    public override ResultType Type { get; } = ResultType.Gif;

    public TGif Gif { get; }

    public string? Title { get; set; }

    public string? Caption { get; set; }

    public ParseMode? ParseMode { get; set; }

    protected InlineGif(string id, TGif gif) : base(id) => Gif = gif;
  }

  public sealed class InlineGif : InlineGif<Uri>
  {
    public int? Width { get; set; }

    public int? Height { get; set; }

    public int? Duration { get; set; }

    public Uri Thumb { get; }

    public ThumbMimeType? ThumbMimeType { get; set; }

    public InlineGif(string id, Uri gif, Uri thumb) : base(id, gif) => Thumb = thumb;
  }

  public sealed class InlineCachedGif : InlineGif<string>
  {
    public InlineCachedGif(string id, string gif) : base(id, gif) { }
  }
}