using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  using Result = Either<bool, LocationMessage>;

  public abstract class EditLiveLocationBase : IRequest<Result>, IInlineMarkupable
  {
    public double Latitude { get; }

    public double Longitude { get; }

    public InlineKeyboardMarkup? ReplyMarkup { get; set; }

    public string Method { get; } = "editMessageLiveLocation";

    protected EditLiveLocationBase(double latitude, double longitude)
    {
      Latitude = latitude;
      Longitude = longitude;
    }
  }

  public abstract class EditLiveLocation<TChatId> : EditLiveLocationBase,
    IChatMessageTargetable<TChatId>
  {
    public TChatId ChatId { get; }

    public int MessageId { get; }

    protected EditLiveLocation(TChatId chatId, int messageId, double latitude, double longitude) :
      base(latitude, longitude)
    {
      ChatId = chatId;
      MessageId = messageId;
    }
  }

  public sealed class EditLiveLocation : EditLiveLocation<long>
  {
    public EditLiveLocation(long chatId, int messageId, double latitude, double longitude) :
      base(chatId, messageId, latitude, longitude) { }
  }

  namespace Usernames
  {
    public sealed class EditLiveLocation : EditLiveLocation<string>
    {
      public EditLiveLocation(string username, int messageId, double latitude, double longitude) :
        base(username, messageId, latitude, longitude) { }
    }
  }

  namespace Inline
  {
    public sealed class EditLiveLocation : EditLiveLocationBase, IInlineMessageTargetable
    {
      public string MessageId { get; }

      public EditLiveLocation(string messageId, double latitude, double longitude) :
        base(latitude, longitude) => MessageId = messageId;
    }
  }
}
