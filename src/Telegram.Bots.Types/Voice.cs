namespace Telegram.Bots.Types
{
  public sealed class Voice : File
  {
    public int Duration { get; set; }

    public string? MimeType { get; set; }
  }
}
