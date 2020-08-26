namespace Telegram.Bots.Types
{
  public class User
  {
    public int Id { get; set; }

    public bool IsBot { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string? Username { get; set; }

    public string? LanguageCode { get; set; }
  }

  public sealed class MyBot : User
  {
    public bool CanJoinGroups { get; set; }

    public bool CanReadAllGroupMessages { get; set; }

    public bool SupportsInlineQueries { get; set; }
  }
}
