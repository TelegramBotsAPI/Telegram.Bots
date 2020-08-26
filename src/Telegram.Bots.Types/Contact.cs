namespace Telegram.Bots.Types
{
  public sealed class Contact
  {
    public string PhoneNumber { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public int? UserId { get; set; }

    public string? Vcard { get; set; }
  }
}
