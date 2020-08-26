namespace Telegram.Bots.Types
{
  public sealed class VideoNote : File
  {
    public int Length { get; set; }

    public int Duration { get; set; }

    public Photo? Thumb { get; set; }
  }
}
