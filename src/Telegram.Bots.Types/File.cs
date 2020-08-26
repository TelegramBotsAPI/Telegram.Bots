namespace Telegram.Bots.Types
{
  public abstract class File
  {
    public string Id { get; set; } = null!;

    public string UniqueId { get; set; } = null!;

    public int? Size { get; set; }
  }

  public sealed class FileInfo : File
  {
    public string? Path { get; set; }
  }
}
