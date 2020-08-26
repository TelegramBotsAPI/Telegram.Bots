using System.Runtime.Serialization;

namespace Telegram.Bots.Types
{
  public enum Emoji
  {
    [EnumMember(Value = "🎲")] Dice,
    [EnumMember(Value = "🎯")] Dart,
    [EnumMember(Value = "🏀")] Basketball
  }
}
