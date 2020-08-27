using System;
using System.Collections.Generic;

namespace Telegram.Bots.Types
{
  public abstract class DocumentMedia<TMedia> : InputMedia<TMedia>
  {
    public override InputMediaType Type { get; } = InputMediaType.Document;

    protected DocumentMedia(TMedia media) : base(media) { }
  }

  public sealed class CachedDocument : DocumentMedia<string>
  {
    public CachedDocument(string fileId) : base(fileId) { }
  }

  public sealed class DocumentUrl : DocumentMedia<Uri>
  {
    public DocumentUrl(Uri url) : base(url) { }
  }

  public sealed class DocumentFile : DocumentMedia<InputFile>, IUploadableMedia
  {
    public InputFile? Thumb { get; set; }

    public DocumentFile(InputFile file) : base(file) { }

    public IEnumerable<InputFile?> GetFiles() => new[] { Media, Thumb };
  }
}
