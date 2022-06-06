// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

using System;
using System.Collections.Generic;
using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public abstract record SendAnimation<TChatId, TAnimation> : IRequest<AnimationMessage>,
    IChatTargetable<TChatId>, ICaptionable, INotifiable, IProtectable, IReplyable, IMarkupable
  {
    public TChatId ChatId { get; }

    public TAnimation Animation { get; }

    public string? Caption { get; init; }

    public ParseMode? ParseMode { get; init; }

    public IEnumerable<MessageEntity>? CaptionEntities { get; init; }

    public bool? DisableNotification { get; init; }
    
    public bool? ProtectContent { get; init; }

    public int? ReplyToMessageId { get; init; }

    public bool? AllowSendingWithoutReply { get; init; }

    public ReplyMarkup? ReplyMarkup { get; init; }

    public string Method { get; } = "sendAnimation";

    protected SendAnimation(TChatId chatId, TAnimation animation)
    {
      ChatId = chatId;
      Animation = animation;
    }
  }

  public abstract record SendAnimationFile<TChatId> : SendAnimation<TChatId, InputFile>, IUploadable
  {
    public int? Duration { get; init; }

    public int? Width { get; init; }

    public int? Height { get; init; }

    public InputFile? Thumb { get; init; }

    protected SendAnimationFile(TChatId chatId, InputFile animation) : base(chatId, animation) { }

    public IEnumerable<InputFile?> GetFiles() => new[] {Animation, Thumb};
  }

  public sealed record SendCachedAnimation : SendAnimation<long, string>
  {
    public SendCachedAnimation(long chatId, string animation) : base(chatId, animation) { }
  }

  public sealed record SendAnimationUrl : SendAnimation<long, Uri>
  {
    public SendAnimationUrl(long chatId, Uri animation) : base(chatId, animation) { }
  }

  public sealed record SendAnimationFile : SendAnimationFile<long>
  {
    public SendAnimationFile(long chatId, InputFile animation) : base(chatId, animation) { }
  }

  namespace Usernames
  {
    public sealed record SendCachedAnimation : SendAnimation<string, string>
    {
      public SendCachedAnimation(string username, string animation) : base(username, animation) { }
    }

    public sealed record SendAnimationUrl : SendAnimation<string, Uri>
    {
      public SendAnimationUrl(string username, Uri animation) : base(username, animation) { }
    }

    public sealed record SendAnimationFile : SendAnimationFile<string>
    {
      public SendAnimationFile(string username, InputFile animation) : base(username, animation) { }
    }
  }
}
