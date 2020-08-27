using System;
using System.Collections.Generic;

namespace Telegram.Bots.Types
{
  public abstract class AnimationMedia<TMedia> : InputMedia<TMedia>
  {
    public override InputMediaType Type { get; } = InputMediaType.Animation;

    protected AnimationMedia(TMedia media) : base(media) { }
  }

  public sealed class CachedAnimation : AnimationMedia<string>
  {
    public CachedAnimation(string fileId) : base(fileId) { }
  }

  public sealed class AnimationUrl : AnimationMedia<Uri>
  {
    public AnimationUrl(Uri url) : base(url) { }
  }

  public sealed class AnimationFile : AnimationMedia<InputFile>, IUploadableMedia
  {
    public int? Duration { get; set; }

    public int? Width { get; set; }

    public int? Height { get; set; }

    public InputFile? Thumb { get; set; }

    public AnimationFile(InputFile file) : base(file) { }

    public IEnumerable<InputFile?> GetFiles() => new[] { Media, Thumb };
  }
}
