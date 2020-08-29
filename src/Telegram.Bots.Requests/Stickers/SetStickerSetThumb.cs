using System;
using System.Collections.Generic;
using Telegram.Bots.Types;

namespace Telegram.Bots.Requests.Stickers
{
  public abstract class SetStickerSetThumb<TThumb> : IRequest<bool>
  {
    public string Name { get; }

    public TThumb Thumb { get; }

    public string Method { get; } = "setStickerSetThumb";

    protected SetStickerSetThumb(string name, TThumb thumb)
    {
      Name = name;
      Thumb = thumb;
    }
  }

  public sealed class SetStickerSetThumbViaUrl : SetStickerSetThumb<Uri?>
  {
    public SetStickerSetThumbViaUrl(string name, Uri? thumb = default) : base(name, thumb) { }
  }

  public sealed class SetStickerSetThumbViaCache : SetStickerSetThumb<string?>
  {
    public SetStickerSetThumbViaCache(string name, string? thumb = default) : base(name, thumb) { }
  }

  public sealed class SetStickerSetThumbViaFile : SetStickerSetThumb<InputFile?>, IUploadable
  {
    public SetStickerSetThumbViaFile(string name, InputFile? thumb = default) :
      base(name, thumb) { }

    public IEnumerable<InputFile?> GetFiles() => new[] { Thumb };
  }
}
