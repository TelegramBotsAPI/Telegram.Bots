namespace Telegram.Bots.Types
{
  public sealed class Document : File
  {
    public Photo? Thumb { get; set; }

    public string? Name { get; set; }

    public string? MimeType { get; set; }
  }
}
