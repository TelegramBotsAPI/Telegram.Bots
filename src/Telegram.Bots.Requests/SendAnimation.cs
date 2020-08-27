using System;
using System.Collections.Generic;
using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public abstract class SendAnimation<TChatId, TAnimation> : IRequest<AnimationMessage>,
    IChatTargetable<TChatId>, ICaptionable, INotifiable, IReplyable, IMarkupable
  {
    public TChatId ChatId { get; }

    public TAnimation Animation { get; }

    public string? Caption { get; set; }

    public ParseMode? ParseMode { get; set; }

    public bool? DisableNotification { get; set; }

    public int? ReplyToMessageId { get; set; }

    public ReplyMarkup? ReplyMarkup { get; set; }

    public string Method { get; } = "sendAnimation";

    protected SendAnimation(TChatId chatId, TAnimation animation)
    {
      ChatId = chatId;
      Animation = animation;
    }
  }

  public abstract class SendAnimationFile<TChatId> : SendAnimation<TChatId, InputFile>, IUploadable
  {
    public int? Duration { get; set; }

    public int? Width { get; set; }

    public int? Height { get; set; }

    public InputFile? Thumb { get; set; }

    protected SendAnimationFile(TChatId chatId, InputFile animation) : base(chatId, animation) { }

    public IEnumerable<InputFile?> GetFiles() => new[] { Animation, Thumb };
  }

  public sealed class SendCachedAnimation : SendAnimation<long, string>
  {
    public SendCachedAnimation(long chatId, string animation) : base(chatId, animation) { }
  }

  public sealed class SendAnimationUrl : SendAnimation<long, Uri>
  {
    public SendAnimationUrl(long chatId, Uri animation) : base(chatId, animation) { }
  }

  public sealed class SendAnimationFile : SendAnimationFile<long>
  {
    public SendAnimationFile(long chatId, InputFile animation) : base(chatId, animation) { }
  }

  namespace Usernames
  {
    public sealed class SendCachedAnimation : SendAnimation<string, string>
    {
      public SendCachedAnimation(string username, string animation) : base(username, animation) { }
    }

    public sealed class SendAnimationUrl : SendAnimation<string, Uri>
    {
      public SendAnimationUrl(string username, Uri animation) : base(username, animation) { }
    }

    public sealed class SendAnimationFile : SendAnimationFile<string>
    {
      public SendAnimationFile(string username, InputFile animation) : base(username, animation) { }
    }
  }
}
