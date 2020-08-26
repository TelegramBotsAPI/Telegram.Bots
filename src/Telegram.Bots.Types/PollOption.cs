namespace Telegram.Bots.Types
{
  public sealed class PollOption
  {
    public string Text { get; set; } = null!;

    public uint VoterCount { get; set; }
  }
}
