using System;
using System.Collections.Generic;
using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public abstract class SendAudio<TChatId, TAudio> : IRequest<AudioMessage>,
    IChatTargetable<TChatId>, ICaptionable, INotifiable, IReplyable, IMarkupable
  {
    public TChatId ChatId { get; }

    public TAudio Audio { get; }

    public string? Caption { get; set; }

    public ParseMode? ParseMode { get; set; }

    public bool? DisableNotification { get; set; }

    public int? ReplyToMessageId { get; set; }

    public ReplyMarkup? ReplyMarkup { get; set; }

    public string Method { get; } = "sendAudio";

    protected SendAudio(TChatId chatId, TAudio audio)
    {
      ChatId = chatId;
      Audio = audio;
    }
  }

  public abstract class SendAudioFile<TChatId> : SendAudio<TChatId, InputFile>, IUploadable
  {
    public int? Duration { get; set; }

    public string? Performer { get; set; }

    public string? Title { get; set; }

    public InputFile? Thumb { get; set; }

    protected SendAudioFile(TChatId chatId, InputFile audio) : base(chatId, audio) { }

    public IEnumerable<InputFile?> GetFiles() => new[] { Audio, Thumb };
  }

  public sealed class SendCachedAudio : SendAudio<long, string>
  {
    public SendCachedAudio(long chatId, string audio) : base(chatId, audio) { }
  }

  public sealed class SendAudioUrl : SendAudio<long, Uri>
  {
    public SendAudioUrl(long chatId, Uri audio) : base(chatId, audio) { }
  }

  public sealed class SendAudioFile : SendAudioFile<long>
  {
    public SendAudioFile(long chatId, InputFile audio) : base(chatId, audio) { }
  }

  namespace Usernames
  {
    public sealed class SendCachedAudio : SendAudio<string, string>
    {
      public SendCachedAudio(string username, string audio) : base(username, audio) { }
    }

    public sealed class SendAudioUrl : SendAudio<string, Uri>
    {
      public SendAudioUrl(string username, Uri audio) : base(username, audio) { }
    }

    public sealed class SendAudioFile : SendAudioFile<string>
    {
      public SendAudioFile(string username, InputFile audio) : base(username, audio) { }
    }
  }
}
