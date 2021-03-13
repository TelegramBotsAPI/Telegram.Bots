// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2021 Aman Agnihotri

using System;
using System.Collections.Generic;
using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public abstract record SendVideo<TChatId, TVideo> : IRequest<VideoMessage>,
    IChatTargetable<TChatId>, ICaptionable, INotifiable, IReplyable, IMarkupable
  {
    public TChatId ChatId { get; }

    public TVideo Video { get; }

    public string? Caption { get; init; }

    public ParseMode? ParseMode { get; init; }

    public IEnumerable<MessageEntity>? CaptionEntities { get; init; }

    public bool? DisableNotification { get; init; }

    public int? ReplyToMessageId { get; init; }

    public bool? AllowSendingWithoutReply { get; init; }

    public ReplyMarkup? ReplyMarkup { get; init; }

    public string Method { get; } = "sendVideo";

    protected SendVideo(TChatId chatId, TVideo video)
    {
      ChatId = chatId;
      Video = video;
    }
  }

  public abstract record SendVideoFile<TChatId> : SendVideo<TChatId, InputFile>, IUploadable
  {
    public bool? SupportsStreaming { get; init; }

    public int? Duration { get; init; }

    public int? Width { get; init; }

    public int? Height { get; init; }

    public InputFile? Thumb { get; init; }

    protected SendVideoFile(TChatId chatId, InputFile video) : base(chatId, video) { }

    public IEnumerable<InputFile?> GetFiles() => new[] {Video, Thumb};
  }

  public sealed record SendCachedVideo : SendVideo<long, string>
  {
    public SendCachedVideo(long chatId, string video) : base(chatId, video) { }
  }

  public sealed record SendVideoUrl : SendVideo<long, Uri>
  {
    public SendVideoUrl(long chatId, Uri video) : base(chatId, video) { }
  }

  public sealed record SendVideoFile : SendVideoFile<long>
  {
    public SendVideoFile(long chatId, InputFile video) : base(chatId, video) { }
  }

  namespace Usernames
  {
    public sealed record SendCachedVideo : SendVideo<string, string>
    {
      public SendCachedVideo(string username, string video) : base(username, video) { }
    }

    public sealed record SendVideoUrl : SendVideo<string, Uri>
    {
      public SendVideoUrl(string username, Uri video) : base(username, video) { }
    }

    public sealed record SendVideoFile : SendVideoFile<string>
    {
      public SendVideoFile(string username, InputFile video) : base(username, video) { }
    }
  }
}
