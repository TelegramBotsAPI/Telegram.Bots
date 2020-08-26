namespace Telegram.Bots.Types
{
  public abstract class KeyboardButton
  {
    public string Text { get; }

    protected KeyboardButton(string text) => Text = text;

    public static implicit operator KeyboardButton(string text) => ToKeyboardButton(text);

    public static KeyboardButton ToKeyboardButton(string text) => new Button(text);
  }

  public sealed class Button : KeyboardButton
  {
    public Button(string text) : base(text) { }

    public static implicit operator Button(string text) => ToButton(text);

    public static Button ToButton(string text) => new Button(text);
  }

  public sealed class RequestContactButton : KeyboardButton
  {
    public bool RequestContact { get; } = true;

    public RequestContactButton(string text) : base(text) { }
  }

  public sealed class RequestLocationButton : KeyboardButton
  {
    public bool RequestLocation { get; } = true;

    public RequestLocationButton(string text) : base(text) { }
  }

  public sealed class RequestPollButton : KeyboardButton
  {
    public KeyboardButtonPollType RequestPoll { get; } = KeyboardButtonPollType.AnyPoll;

    public RequestPollButton(string text) : base(text) { }
  }

  public sealed class RequestRegularPollButton : KeyboardButton
  {
    public KeyboardButtonPollType? RequestPoll { get; } = PollType.Regular;

    public RequestRegularPollButton(string text) : base(text) { }
  }

  public sealed class RequestQuizPollButton : KeyboardButton
  {
    public KeyboardButtonPollType? RequestPoll { get; } = PollType.Quiz;

    public RequestQuizPollButton(string text) : base(text) { }
  }
}
