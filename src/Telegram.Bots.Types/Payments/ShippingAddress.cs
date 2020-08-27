namespace Telegram.Bots.Types.Payments
{
  public sealed class ShippingAddress
  {
    public string CountryCode { get; set; } = null!;

    public string State { get; set; } = null!;

    public string City { get; set; } = null!;

    public string StreetLine1 { get; set; } = null!;

    public string StreetLine2 { get; set; } = null!;

    public string PostCode { get; set; } = null!;
  }
}
