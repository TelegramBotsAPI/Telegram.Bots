using Telegram.Bots.Types;

namespace Telegram.Bots.Requests.Games
{
  public sealed class SendGame : IRequest<GameMessage>,
    IChatTargetable<long>, INotifiable, IReplyable, IInlineMarkupable
  {
    public long ChatId { get; }

    public string ShortName { get; }

    public bool? DisableNotification { get; set; }

    public int? ReplyToMessageId { get; set; }

    public InlineKeyboardMarkup? ReplyMarkup { get; set; }

    public string Method { get; } = "sendGame";

    public SendGame(long chatId, string shortName)
    {
      ChatId = chatId;
      ShortName = shortName;
    }
  }
}
