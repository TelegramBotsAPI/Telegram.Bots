// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests
{
  using System;
  using System.Collections.Generic;
  using Types;

  public abstract record SendAudio<TChatId, TAudio>(
    TChatId ChatId,
    TAudio Audio) : IRequest<AudioMessage>, IChatTargetable<TChatId>,
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

    public string Method => "sendAudio";
  }

  public abstract record SendAudioFile<TChatId>(
    TChatId ChatId,
    InputFile Audio) : SendAudio<TChatId, InputFile>(ChatId, Audio), IUploadable
  {
    public int? Duration { get; init; }

    public string? Performer { get; init; }

    public string? Title { get; init; }

    public InputFile? Thumb { get; init; }

    public IEnumerable<InputFile?> GetFiles()
    {
      return new[]
      {
        Audio, Thumb
      };
    }
  }

  public sealed record SendCachedAudio(
    long ChatId,
    string Audio) : SendAudio<long, string>(ChatId, Audio);

  public sealed record SendAudioUrl(
    long ChatId,
    Uri Audio) : SendAudio<long, Uri>(ChatId, Audio);

  public sealed record SendAudioFile(
    long ChatId,
    InputFile Audio) : SendAudioFile<long>(ChatId, Audio);

  namespace Usernames
  {
    public sealed record SendCachedAudio(
      string ChatId,
      string Audio) : SendAudio<string, string>(ChatId, Audio);

    public sealed record SendAudioUrl(
      string ChatId,
      Uri Audio) : SendAudio<string, Uri>(ChatId, Audio);

    public sealed record SendAudioFile(
      string ChatId,
      InputFile Audio) : SendAudioFile<string>(ChatId, Audio);
  }
}
