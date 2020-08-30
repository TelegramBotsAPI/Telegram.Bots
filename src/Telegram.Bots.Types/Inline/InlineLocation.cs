using System;

namespace Telegram.Bots.Types.Inline
{
  public sealed class InlineLocation : ReplaceableResult, IThumbable
  {
    public override ResultType Type { get; } = ResultType.Location;

    public string Title { get; }

    public double Latitude { get; }

    public double Longitude { get; }

    public int? LivePeriod { get; set; }

    public Uri? Thumb { get; set; }

    public int? ThumbWidth { get; set; }

    public int? ThumbHeight { get; set; }

    public InlineLocation(string id, string title, double latitude, double longitude) : base(id)
    {
      Title = title;
      Latitude = latitude;
      Longitude = longitude;
    }
  }
}
