using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public interface IMarkupable
  {
    ReplyMarkup? ReplyMarkup { get; set; }
  }
}
