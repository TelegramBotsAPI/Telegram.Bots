using System;
using System.Collections.Generic;

namespace Telegram.Bots.Types
{
  public abstract class VideoMedia<TMedia> : InputMedia<TMedia>, IGroupableMedia
  {
    public override InputMediaType Type { get; } = InputMediaType.Video;

    protected VideoMedia(TMedia media) : base(media) { }
  }

  public sealed class CachedVideo : VideoMedia<string>
  {
    public CachedVideo(string fileId) : base(fileId) { }
  }

  public sealed class VideoUrl : VideoMedia<Uri>
  {
    public VideoUrl(Uri url) : base(url) { }
  }

  public sealed class VideoFile : VideoMedia<InputFile>, IUploadableMedia
  {
    public bool? SupportsStreaming { get; set; }

    public int? Width { get; set; }

    public int? Height { get; set; }

    public int? Duration { get; set; }

    public InputFile? Thumb { get; set; }

    public VideoFile(InputFile file) : base(file) { }

    public IEnumerable<InputFile?> GetFiles() => new[] { Media, Thumb };
  }
}
