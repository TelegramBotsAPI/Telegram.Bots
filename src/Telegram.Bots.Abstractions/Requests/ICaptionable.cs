using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public interface ICaptionable
  {
    string? Caption { get; set; }

    ParseMode? ParseMode { get; set; }
  }
}
