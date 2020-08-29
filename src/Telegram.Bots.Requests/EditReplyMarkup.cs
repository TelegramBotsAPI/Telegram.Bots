using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  using Result = Either<bool, ReplyMarkupMessage>;

  public abstract class EditReplyMarkupBase : IRequest<Result>, IInlineMarkupable
  {
    public InlineKeyboardMarkup? ReplyMarkup { get; set; }

    public string Method { get; } = "editMessageReplyMarkup";
  }

  public abstract class EditReplyMarkup<TChatId> : EditReplyMarkupBase,
    IChatMessageTargetable<TChatId>
  {
    public TChatId ChatId { get; }

    public int MessageId { get; }

    protected EditReplyMarkup(TChatId chatId, int messageId)
    {
      ChatId = chatId;
      MessageId = messageId;
    }
  }

  public sealed class EditReplyMarkup : EditReplyMarkup<long>
  {
    public EditReplyMarkup(long chatId, int messageId) : base(chatId, messageId) { }
  }

  namespace Usernames
  {
    public sealed class EditReplyMarkup : EditReplyMarkup<string>
    {
      public EditReplyMarkup(string username, int messageId) : base(username, messageId) { }
    }
  }

  namespace Inline
  {
    public sealed class EditReplyMarkup : EditReplyMarkupBase, IInlineMessageTargetable
    {
      public string MessageId { get; }

      public EditReplyMarkup(string messageId) => MessageId = messageId;
    }
  }
}
