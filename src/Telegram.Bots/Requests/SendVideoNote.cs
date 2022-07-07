// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests
{
  using System;
  using System.Collections.Generic;
  using Types;

  public abstract record SendVideoNote<TChatId, TVideoNote>(
    TChatId ChatId,
    TVideoNote VideoNote) : IRequest<VideoNoteMessage>,
    IChatTargetable<TChatId>, INotifiable, IProtectable, IReplyable, IMarkupable
  {
    public bool? DisableNotification { get; init; }

    public bool? ProtectContent { get; init; }

    public int? ReplyToMessageId { get; init; }

    public bool? AllowSendingWithoutReply { get; init; }

    public ReplyMarkup? ReplyMarkup { get; init; }

    public string Method => "sendVideoNote";
  }

  public abstract record SendVideoNoteFile<TChatId>(
    TChatId ChatId,
    InputFile VideoNote) : SendVideoNote<TChatId, InputFile>(ChatId, VideoNote),
    IUploadable
  {
    public int? Duration { get; init; }

    public int? Length { get; init; }

    public InputFile? Thumb { get; init; }

    public IEnumerable<InputFile?> GetFiles()
    {
      return new[]
      {
        VideoNote, Thumb
      };
    }
  }

  public sealed record SendCachedVideoNote(
    long ChatId,
    string VideoNote) : SendVideoNote<long, string>(ChatId, VideoNote);

  public sealed record SendVideoNoteUrl(
    long ChatId,
    Uri VideoNote) : SendVideoNote<long, Uri>(ChatId, VideoNote);

  public sealed record SendVideoNoteFile(
    long ChatId,
    InputFile VideoNote) : SendVideoNoteFile<long>(ChatId, VideoNote);

  namespace Usernames
  {
    public sealed record SendCachedVideoNote(
      string ChatId,
      string VideoNote) : SendVideoNote<string, string>(ChatId, VideoNote);

    public sealed record SendVideoNoteUrl(
      string ChatId,
      Uri VideoNote) : SendVideoNote<string, Uri>(ChatId, VideoNote);

    public sealed record SendVideoNoteFile(
      string ChatId,
      InputFile VideoNote) : SendVideoNoteFile<string>(ChatId, VideoNote);
  }
}
