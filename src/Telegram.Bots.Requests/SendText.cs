using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public abstract class SendText<TChatId> : IRequest<TextMessage>, IChatTargetable<TChatId>,
    INotifiable, IReplyable, IMarkupable
  {
    public TChatId ChatId { get; }

    public string Text { get; }

    public ParseMode? ParseMode { get; set; }

    public bool? DisableWebPagePreview { get; set; }

    public bool? DisableNotification { get; set; }

    public int? ReplyToMessageId { get; set; }

    public ReplyMarkup? ReplyMarkup { get; set; }

    public string Method { get; } = "sendMessage";

    protected SendText(TChatId chatId, string text)
    {
      ChatId = chatId;
      Text = text;
    }
  }

  public sealed class SendText : SendText<long>
  {
    public SendText(long chatId, string text) : base(chatId, text) { }
  }

  public sealed class SendTextToUsername : SendText<string>
  {
    public SendTextToUsername(string username, string text) : base(username, text) { }
  }
}
