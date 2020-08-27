namespace Telegram.Bots.Requests
{
  public interface IReplyable
  {
    int? ReplyToMessageId { get; set; }
  }
}
