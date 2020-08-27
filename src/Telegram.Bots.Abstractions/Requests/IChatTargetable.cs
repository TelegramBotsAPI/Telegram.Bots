namespace Telegram.Bots.Requests
{
  public interface IChatTargetable<out TChatId>
  {
    TChatId ChatId { get; }
  }
}
