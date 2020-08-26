namespace Telegram.Bots.Types
{
  public sealed class Video : File
  {
    public int Width { get; set; }

    public int Height { get; set; }

    public int Duration { get; set; }

    public Photo? Thumb { get; set; }

    public string? MimeType { get; set; }
  }
}
