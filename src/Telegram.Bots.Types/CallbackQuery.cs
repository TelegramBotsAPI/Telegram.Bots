namespace Telegram.Bots.Types
{
  public abstract class CallbackQuery
  {
    public string Id { get; set; } = null!;

    public User From { get; set; } = null!;

    public string ChatInstance { get; set; } = null!;
  }

  public sealed class MessageCallbackQuery : CallbackQuery
  {
    public Message Message { get; set; } = null!;

    public string Data { get; set; } = null!;
  }

  public class GameCallbackQuery : CallbackQuery
  {
    public Message Message { get; set; } = null!;

    public string ShortName { get; set; } = null!;
  }

  public class InlineMessageCallbackQuery : CallbackQuery
  {
    public string MessageId { get; set; } = null!;

    public string Data { get; set; } = null!;
  }

  public class InlineGameCallbackQuery : CallbackQuery
  {
    public string MessageId { get; set; } = null!;

    public string ShortName { get; set; } = null!;
  }
}
