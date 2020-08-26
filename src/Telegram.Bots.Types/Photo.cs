namespace Telegram.Bots.Types
{
  public sealed class Photo : File
  {
    public int Width { get; set; }

    public int Height { get; set; }
  }
}
