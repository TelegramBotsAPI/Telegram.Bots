namespace Telegram.Bots.Types.Payments
{
  public sealed class LabeledPrice
  {
    public string Label { get; set; } = null!;

    public int Amount { get; set; }
  }
}
