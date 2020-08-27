namespace Telegram.Bots.Types
{
  public sealed class ButtonPollType
  {
    public static readonly ButtonPollType AnyPoll = new ButtonPollType(null);

    public PollType? Type { get; }

    public ButtonPollType(PollType? type) => Type = type;

    public static implicit operator ButtonPollType(PollType type) => ToButtonPollType(type);

    public static ButtonPollType ToButtonPollType(PollType type) => new ButtonPollType(type);
  }
}
