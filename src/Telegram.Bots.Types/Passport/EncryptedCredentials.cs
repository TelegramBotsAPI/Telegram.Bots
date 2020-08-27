namespace Telegram.Bots.Types.Passport
{
  public sealed class EncryptedCredentials
  {
    public string Data { get; set; } = null!;

    public string Hash { get; set; } = null!;

    public string Secret { get; set; } = null!;
  }
}
