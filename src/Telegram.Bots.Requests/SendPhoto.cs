using System;
using System.Collections.Generic;
using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public abstract class SendPhoto<TChatId, TPhoto> : IRequest<PhotoMessage>,
    IChatTargetable<TChatId>, ICaptionable, INotifiable, IReplyable, IMarkupable
  {
    public TChatId ChatId { get; }

    public TPhoto Photo { get; }

    public string? Caption { get; set; }

    public ParseMode? ParseMode { get; set; }

    public bool? DisableNotification { get; set; }

    public int? ReplyToMessageId { get; set; }

    public ReplyMarkup? ReplyMarkup { get; set; }

    public string Method { get; } = "sendPhoto";

    protected SendPhoto(TChatId chatId, TPhoto photo)
    {
      ChatId = chatId;
      Photo = photo;
    }
  }

  public abstract class SendPhotoFile<TChatId> : SendPhoto<TChatId, InputFile>, IUploadable
  {
    protected SendPhotoFile(TChatId chatId, InputFile photo) : base(chatId, photo) { }

    public IEnumerable<InputFile?> GetFiles() => new[] { Photo };
  }

  public sealed class SendCachedPhoto : SendPhoto<long, string>
  {
    public SendCachedPhoto(long chatId, string photo) : base(chatId, photo) { }
  }

  public sealed class SendPhotoUrl : SendPhoto<long, Uri>
  {
    public SendPhotoUrl(long chatId, Uri photo) : base(chatId, photo) { }
  }

  public sealed class SendPhotoFile : SendPhotoFile<long>
  {
    public SendPhotoFile(long chatId, InputFile photo) : base(chatId, photo) { }
  }

  namespace Usernames
  {
    public sealed class SendCachedPhoto : SendPhoto<string, string>
    {
      public SendCachedPhoto(string username, string photo) : base(username, photo) { }
    }

    public sealed class SendPhotoUrl : SendPhoto<string, Uri>
    {
      public SendPhotoUrl(string username, Uri photo) : base(username, photo) { }
    }

    public sealed class SendPhotoFile : SendPhotoFile<string>
    {
      public SendPhotoFile(string username, InputFile photo) : base(username, photo) { }
    }
  }
}
