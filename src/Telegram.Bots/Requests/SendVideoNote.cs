// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System;
using System.Collections.Generic;
using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public abstract record SendVideoNote<TChatId, TVideoNote> : IRequest<VideoNoteMessage>,
    IChatTargetable<TChatId>, INotifiable, IReplyable, IMarkupable
  {
    public TChatId ChatId { get; }

    public TVideoNote VideoNote { get; }

    public bool? DisableNotification { get; init; }

    public int? ReplyToMessageId { get; init; }

    public bool? AllowSendingWithoutReply { get; init; }

    public ReplyMarkup? ReplyMarkup { get; init; }

    public string Method { get; } = "sendVideoNote";

    protected SendVideoNote(TChatId chatId, TVideoNote videoNote)
    {
      ChatId = chatId;
      VideoNote = videoNote;
    }
  }

  public abstract record SendVideoNoteFile<TChatId> : SendVideoNote<TChatId, InputFile>, IUploadable
  {
    public int? Duration { get; init; }

    public int? Length { get; init; }

    public InputFile? Thumb { get; init; }

    protected SendVideoNoteFile(TChatId chatId, InputFile videoNote) : base(chatId, videoNote) { }

    public IEnumerable<InputFile?> GetFiles() => new[] { VideoNote, Thumb };
  }

  public sealed record SendCachedVideoNote : SendVideoNote<long, string>
  {
    public SendCachedVideoNote(long chatId, string videoNote) : base(chatId, videoNote) { }
  }

  public sealed record SendVideoNoteUrl : SendVideoNote<long, Uri>
  {
    public SendVideoNoteUrl(long chatId, Uri videoNote) : base(chatId, videoNote) { }
  }

  public sealed record SendVideoNoteFile : SendVideoNoteFile<long>
  {
    public SendVideoNoteFile(long chatId, InputFile videoNote) : base(chatId, videoNote) { }
  }

  namespace Usernames
  {
    public sealed record SendCachedVideoNote : SendVideoNote<string, string>
    {
      public SendCachedVideoNote(string username, string videoNote) : base(username, videoNote) { }
    }

    public sealed record SendVideoNoteUrl : SendVideoNote<string, Uri>
    {
      public SendVideoNoteUrl(string username, Uri videoNote) : base(username, videoNote) { }
    }

    public sealed record SendVideoNoteFile : SendVideoNoteFile<string>
    {
      public SendVideoNoteFile(string username, InputFile videoNote) : base(username, videoNote) { }
    }
  }
}
