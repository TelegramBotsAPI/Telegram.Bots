namespace Telegram.Bots.Types.Passport
{
  public sealed class PassportFile
  {
    public string Id { get; set; } = null!;

    public string UniqueId { get; set; } = null!;

    public uint Size { get; set; }

    public long Date { get; set; }
  }
}
