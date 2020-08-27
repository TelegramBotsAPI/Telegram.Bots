namespace Telegram.Bots.Types.Inline
{
  public sealed class ChosenInlineResult
  {
    public string ResultId { get; set; } = null!;

    public User From { get; set; } = null!;

    public string Query { get; set; } = null!;

    public Location? Location { get; set; } = null!;

    public string? MessageId { get; set; }
  }
}
