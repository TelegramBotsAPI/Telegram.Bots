// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests
{
  using System;
  using System.Collections.Generic;
  using Types;

  public abstract record SendVideo<TChatId, TVideo>(
    TChatId ChatId,
    TVideo Video) : IRequest<VideoMessage>, IChatTargetable<TChatId>,
    IThreadable, ICaptionable, INotifiable, IProtectable, IReplyable,
    IMarkupable
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

    public string Method => "sendVideo";
  }

  public abstract record SendVideoFile<TChatId>(
    TChatId ChatId,
    InputFile Video) : SendVideo<TChatId, InputFile>(ChatId, Video), IUploadable
  {
    public bool? SupportsStreaming { get; init; }

    public int? Duration { get; init; }

    public int? Width { get; init; }

    public int? Height { get; init; }

    public InputFile? Thumb { get; init; }

    public IEnumerable<InputFile?> GetFiles()
    {
      return new[]
      {
        Video, Thumb
      };
    }
  }

  public sealed record SendCachedVideo(
    long ChatId,
    string Video) : SendVideo<long, string>(ChatId, Video);

  public sealed record SendVideoUrl(
    long ChatId,
    Uri Video) : SendVideo<long, Uri>(ChatId, Video);

  public sealed record SendVideoFile(
    long ChatId,
    InputFile Video) : SendVideoFile<long>(ChatId, Video);

  namespace Usernames
  {
    public sealed record SendCachedVideo(
      string ChatId,
      string Video) : SendVideo<string, string>(ChatId, Video);

    public sealed record SendVideoUrl(
      string ChatId,
      Uri Video) : SendVideo<string, Uri>(ChatId, Video);

    public sealed record SendVideoFile(
      string ChatId,
      InputFile Video) : SendVideoFile<string>(ChatId, Video);
  }
}
