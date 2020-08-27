using System.Collections.Generic;

namespace Telegram.Bots.Types
{
  public interface IInputMedia
  {
    InputMediaType Type { get; }
  }

  public interface IGroupableMedia : IInputMedia { }

  public interface IUploadableMedia : IInputMedia
  {
    IEnumerable<InputFile?> GetFiles();
  }

  public abstract class InputMedia<TMedia> : IInputMedia
  {
    public abstract InputMediaType Type { get; }

    public TMedia Media { get; }

    public string? Caption { get; set; }

    public ParseMode? ParseMode { get; set; }

    protected InputMedia(TMedia media) => Media = media;
  }
}
