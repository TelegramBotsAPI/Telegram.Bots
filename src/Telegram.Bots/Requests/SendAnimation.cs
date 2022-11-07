// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests
{
  using System;
  using System.Collections.Generic;
  using Types;

  public abstract record SendAnimation<TChatId, TAnimation>(
    TChatId ChatId,
    TAnimation Animation) : IRequest<AnimationMessage>,
    IChatTargetable<TChatId>, IThreadable, ICaptionable, INotifiable,
    IProtectable, IReplyable, IMarkupable
  {
    public int? ThreadId { get; init; }

    public string? Caption { get; init; }

    public ParseMode? ParseMode { get; init; }

    public IEnumerable<MessageEntity>? CaptionEntities { get; init; }

    public bool? DisableNotification { get; init; }

    public bool? ProtectContent { get; init; }

    public int? ReplyToMessageId { get; init; }

    public bool? AllowSendingWithoutReply { get; init; }

    public ReplyMarkup? ReplyMarkup { get; init; }

    public string Method => "sendAnimation";
  }

  public abstract record SendAnimationFile<TChatId>(
    TChatId ChatId,
    InputFile Animation) : SendAnimation<TChatId, InputFile>(ChatId, Animation),
    IUploadable
  {
    public int? Duration { get; init; }

    public int? Width { get; init; }

    public int? Height { get; init; }

    public InputFile? Thumb { get; init; }

    public IEnumerable<InputFile?> GetFiles()
    {
      return new[]
      {
        Animation, Thumb
      };
    }
  }

  public sealed record SendCachedAnimation(
    long ChatId,
    string Animation) : SendAnimation<long, string>(ChatId, Animation);

  public sealed record SendAnimationUrl(
    long ChatId,
    Uri Animation) : SendAnimation<long, Uri>(ChatId, Animation);

  public sealed record SendAnimationFile(
    long ChatId,
    InputFile Animation) : SendAnimationFile<long>(ChatId, Animation);

  namespace Usernames
  {
    public sealed record SendCachedAnimation(
      string ChatId,
      string Animation) : SendAnimation<string, string>(ChatId, Animation);

    public sealed record SendAnimationUrl(
      string ChatId,
      Uri Animation) : SendAnimation<string, Uri>(ChatId, Animation);

    public sealed record SendAnimationFile(
      string ChatId,
      InputFile Animation) : SendAnimationFile<string>(ChatId, Animation);
  }
}
