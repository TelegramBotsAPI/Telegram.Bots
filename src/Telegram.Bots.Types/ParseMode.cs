using System.Runtime.Serialization;

namespace Telegram.Bots.Types
{
  public enum ParseMode
  {
    Html,
    Markdown,
    [EnumMember(Value = "MarkdownV2")] MarkdownV2
  }
}
