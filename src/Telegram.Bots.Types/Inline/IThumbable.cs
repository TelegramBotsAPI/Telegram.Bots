using System;

namespace Telegram.Bots.Types.Inline
{
  public interface IThumbable
  {
    public Uri? Thumb { get; set; }

    public int? ThumbWidth { get; set; }

    public int? ThumbHeight { get; set; }
  }
}
