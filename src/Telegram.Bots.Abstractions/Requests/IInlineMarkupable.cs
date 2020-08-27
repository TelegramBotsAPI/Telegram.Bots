using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public interface IInlineMarkupable
  {
    InlineKeyboardMarkup? ReplyMarkup { get; set; }
  }
}
