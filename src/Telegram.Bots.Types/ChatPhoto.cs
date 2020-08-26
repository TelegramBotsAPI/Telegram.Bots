namespace Telegram.Bots.Types
{
  public sealed class ChatPhoto
  {
    public string SmallFileId { get; set; } = null!;

    public string SmallFileUniqueId { get; set; } = null!;

    public string BigFileId { get; set; } = null!;

    public string BigFileUniqueId { get; set; } = null!;
  }
}
