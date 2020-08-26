namespace Telegram.Bots.Types
{
  public sealed class BotCommand
  {
    public string Command { get; set; } = null!;

    public string Description { get; set; } = null!;
  }
}
