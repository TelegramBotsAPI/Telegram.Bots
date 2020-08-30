// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System;
using System.Collections.Generic;
using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public abstract class SendVideoNote<TChatId, TVideoNote> : IRequest<VideoNoteMessage>,
    IChatTargetable<TChatId>, INotifiable, IReplyable, IMarkupable
  {
    public TChatId ChatId { get; }

    public TVideoNote VideoNote { get; }

    public bool? DisableNotification { get; set; }

    public int? ReplyToMessageId { get; set; }

    public ReplyMarkup? ReplyMarkup { get; set; }

    public string Method { get; } = "sendVideoNote";

    protected SendVideoNote(TChatId chatId, TVideoNote videoNote)
    {
      ChatId = chatId;
      VideoNote = videoNote;
    }
  }

  public abstract class SendVideoNoteFile<TChatId> : SendVideoNote<TChatId, InputFile>, IUploadable
  {
    public int? Duration { get; set; }

    public int? Length { get; set; }

    public InputFile? Thumb { get; set; }

    protected SendVideoNoteFile(TChatId chatId, InputFile videoNote) : base(chatId, videoNote) { }

    public IEnumerable<InputFile?> GetFiles() => new[] { VideoNote, Thumb };
  }

  public sealed class SendCachedVideoNote : SendVideoNote<long, string>
  {
    public SendCachedVideoNote(long chatId, string videoNote) : base(chatId, videoNote) { }
  }

  public sealed class SendVideoNoteUrl : SendVideoNote<long, Uri>
  {
    public SendVideoNoteUrl(long chatId, Uri videoNote) : base(chatId, videoNote) { }
  }

  public sealed class SendVideoNoteFile : SendVideoNoteFile<long>
  {
    public SendVideoNoteFile(long chatId, InputFile videoNote) : base(chatId, videoNote) { }
  }

  namespace Usernames
  {
    public sealed class SendCachedVideoNote : SendVideoNote<string, string>
    {
      public SendCachedVideoNote(string username, string videoNote) : base(username, videoNote) { }
    }

    public sealed class SendVideoNoteUrl : SendVideoNote<string, Uri>
    {
      public SendVideoNoteUrl(string username, Uri videoNote) : base(username, videoNote) { }
    }

    public sealed class SendVideoNoteFile : SendVideoNoteFile<string>
    {
      public SendVideoNoteFile(string username, InputFile videoNote) : base(username, videoNote) { }
    }
  }
}
