using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  using Result = Either<bool, PollMessage>;

  public abstract class StopPollBase : IRequest<Result>, IInlineMarkupable
  {
    public InlineKeyboardMarkup? ReplyMarkup { get; set; }

    public string Method { get; } = "stopPoll";
  }

  public abstract class StopPoll<TChatId> : StopPollBase, IChatMessageTargetable<TChatId>
  {
    public TChatId ChatId { get; }

    public int MessageId { get; }

    protected StopPoll(TChatId chatId, int messageId)
    {
      ChatId = chatId;
      MessageId = messageId;
    }
  }

  public sealed class StopPoll : StopPoll<long>
  {
    public StopPoll(long chatId, int messageId) : base(chatId, messageId) { }
  }

  namespace Usernames
  {
    public sealed class StopPoll : StopPoll<string>
    {
      public StopPoll(string username, int messageId) : base(username, messageId) { }
    }
  }
}
