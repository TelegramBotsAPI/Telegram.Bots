using System.Collections.Generic;

namespace Telegram.Bots.Types.Payments
{
  public sealed class ShippingOption
  {
    public string Id { get; set; } = null!;

    public string Title { get; set; } = null!;

    public IReadOnlyList<LabeledPrice> Prices { get; set; } = null!;
  }
}
