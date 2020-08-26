namespace Telegram.Bots.Types
{
  public sealed class ChatPermissions
  {
    public bool? CanSendMessages { get; set; }

    public bool? CanSendMediaMessages { get; set; }

    public bool? CanSendPolls { get; set; }

    public bool? CanSendOtherMessages { get; set; }

    public bool? CanAddWebPagePreviews { get; set; }

    public bool? CanChangeInfo { get; set; }

    public bool? CanInviteUsers { get; set; }

    public bool? CanPinMessages { get; set; }
  }
}
