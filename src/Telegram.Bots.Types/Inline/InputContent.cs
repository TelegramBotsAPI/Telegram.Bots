namespace Telegram.Bots.Types.Inline
{
  public abstract class InputContent { }

  public sealed class ContactContent : InputContent
  {
    public string PhoneNumber { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; } = null!;

    public string? Vcard { get; set; }
  }

  public sealed class LocationContent : InputContent
  {
    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public int? LivePeriod { get; set; }
  }

  public sealed class TextContent : InputContent
  {
    public string Text { get; set; } = null!;

    public ParseMode? ParseMode { get; set; }

    public bool? DisableWebPagePreview { get; set; }
  }

  public sealed class VenueContent : InputContent
  {
    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public string Title { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string? FoursquareId { get; set; }

    public string? FoursquareType { get; set; }
  }
}
