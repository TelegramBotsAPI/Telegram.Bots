namespace Telegram.Bots.Types
{
  public sealed class KeyboardButtonPollType
  {
    public static readonly KeyboardButtonPollType AnyPoll = new KeyboardButtonPollType(null);

    public PollType? Type { get; }

    public KeyboardButtonPollType(PollType? type) => Type = type;

    public static implicit operator KeyboardButtonPollType(PollType type) =>
      ToKeyboardButtonPollType(type);

    public static KeyboardButtonPollType ToKeyboardButtonPollType(PollType type) =>
      new KeyboardButtonPollType(type);
  }
}
