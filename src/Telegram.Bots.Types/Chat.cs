namespace Telegram.Bots.Types
{
  public class Chat
  {
    public long Id { get; set; }

    public ChatType Type { get; set; }

    public string? Title { get; set; }

    public string? Username { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }
  }

  public sealed class ChatInfo : Chat
  {
    public ChatPhoto? Photo { get; set; }

    public string? Description { get; set; }

    public string? InviteLink { get; set; }

    public Message? Pinned { get; set; }

    public ChatPermissions? Permissions { get; set; }

    public int SlowModeDelay { get; set; }

    public string? StickerSetName { get; set; }

    public bool CanSetStickerSet { get; set; }
  }
}
