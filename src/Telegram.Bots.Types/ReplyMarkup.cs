using System.Collections.Generic;

namespace Telegram.Bots.Types
{
  using Keyboard = IEnumerable<KeyboardButton[]>;
  using InlineKeyboard = IEnumerable<InlineButton[]>;

  public abstract class ReplyMarkup { }

  public sealed class KeyboardMarkup : ReplyMarkup
  {
    public Keyboard Keyboard { get; }

    public bool? Resize { get; set; }

    public bool? OneTime { get; set; }

    public bool? Selective { get; set; }

    public KeyboardMarkup(Keyboard keyboard) => Keyboard = keyboard;
  }

  public sealed class InlineKeyboardMarkup : ReplyMarkup
  {
    public InlineKeyboard Keyboard { get; }

    public InlineKeyboardMarkup(InlineKeyboard keyboard) => Keyboard = keyboard;
  }

  public sealed class ForceReplyMarkup : ReplyMarkup
  {
    public bool ForceReply { get; } = true;

    public bool? Selective { get; set; }
  }

  public sealed class RemoveMarkup : ReplyMarkup
  {
    public bool RemoveKeyboard { get; } = true;

    public bool? Selective { get; set; }
  }
}
