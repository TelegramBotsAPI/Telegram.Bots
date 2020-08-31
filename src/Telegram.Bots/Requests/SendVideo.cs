// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System;
using System.Collections.Generic;
using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public abstract class SendVideo<TChatId, TVideo> : IRequest<VideoMessage>,
    IChatTargetable<TChatId>, ICaptionable, INotifiable, IReplyable, IMarkupable
  {
    public TChatId ChatId { get; }

    public TVideo Video { get; }

    public string? Caption { get; set; }

    public ParseMode? ParseMode { get; set; }

    public bool? DisableNotification { get; set; }

    public int? ReplyToMessageId { get; set; }

    public ReplyMarkup? ReplyMarkup { get; set; }

    public string Method { get; } = "sendVideo";

    protected SendVideo(TChatId chatId, TVideo video)
    {
      ChatId = chatId;
      Video = video;
    }
  }

  public abstract class SendVideoFile<TChatId> : SendVideo<TChatId, InputFile>, IUploadable
  {
    public bool? SupportsStreaming { get; set; }

    public int? Duration { get; set; }

    public int? Width { get; set; }

    public int? Height { get; set; }

    public InputFile? Thumb { get; set; }

    protected SendVideoFile(TChatId chatId, InputFile video) : base(chatId, video) { }

    public IEnumerable<InputFile?> GetFiles() => new[] { Video, Thumb };
  }

  public sealed class SendCachedVideo : SendVideo<long, string>
  {
    public SendCachedVideo(long chatId, string video) : base(chatId, video) { }
  }

  public sealed class SendVideoUrl : SendVideo<long, Uri>
  {
    public SendVideoUrl(long chatId, Uri video) : base(chatId, video) { }
  }

  public sealed class SendVideoFile : SendVideoFile<long>
  {
    public SendVideoFile(long chatId, InputFile video) : base(chatId, video) { }
  }

  namespace Usernames
  {
    public sealed class SendCachedVideo : SendVideo<string, string>
    {
      public SendCachedVideo(string username, string video) : base(username, video) { }
    }

    public sealed class SendVideoUrl : SendVideo<string, Uri>
    {
      public SendVideoUrl(string username, Uri video) : base(username, video) { }
    }

    public sealed class SendVideoFile : SendVideoFile<string>
    {
      public SendVideoFile(string username, InputFile video) : base(username, video) { }
    }
  }
}
