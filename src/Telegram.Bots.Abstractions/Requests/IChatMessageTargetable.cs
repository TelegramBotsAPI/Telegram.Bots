namespace Telegram.Bots.Requests
{
  public interface IChatMessageTargetable<out TChatId> : IChatTargetable<TChatId>
  {
    int MessageId { get; }
  }
}
