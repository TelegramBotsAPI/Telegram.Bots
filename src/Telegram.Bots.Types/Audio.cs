namespace Telegram.Bots.Types
{
  public sealed class Audio : File
  {
    public int Duration { get; set; }

    public string? Performer { get; set; }

    public string? Title { get; set; }

    public string? MimeType { get; set; }

    public Photo? Thumb { get; set; }
  }
}
