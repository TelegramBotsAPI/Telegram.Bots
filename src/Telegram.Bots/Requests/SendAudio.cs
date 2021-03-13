// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2021 Aman Agnihotri

using System;
using System.Collections.Generic;
using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public abstract record SendAudio<TChatId, TAudio> : IRequest<AudioMessage>,
    IChatTargetable<TChatId>, ICaptionable, INotifiable, IReplyable, IMarkupable
  {
    public TChatId ChatId { get; }

    public TAudio Audio { get; }

    public string? Caption { get; init; }

    public ParseMode? ParseMode { get; init; }

    public IEnumerable<MessageEntity>? CaptionEntities { get; init; }

    public bool? DisableNotification { get; init; }

    public int? ReplyToMessageId { get; init; }

    public bool? AllowSendingWithoutReply { get; init; }

    public ReplyMarkup? ReplyMarkup { get; init; }

    public string Method { get; } = "sendAudio";

    protected SendAudio(TChatId chatId, TAudio audio)
    {
      ChatId = chatId;
      Audio = audio;
    }
  }

  public abstract record SendAudioFile<TChatId> : SendAudio<TChatId, InputFile>, IUploadable
  {
    public int? Duration { get; init; }

    public string? Performer { get; init; }

    public string? Title { get; init; }

    public InputFile? Thumb { get; init; }

    protected SendAudioFile(TChatId chatId, InputFile audio) : base(chatId, audio) { }

    public IEnumerable<InputFile?> GetFiles() => new[] {Audio, Thumb};
  }

  public sealed record SendCachedAudio : SendAudio<long, string>
  {
    public SendCachedAudio(long chatId, string audio) : base(chatId, audio) { }
  }

  public sealed record SendAudioUrl : SendAudio<long, Uri>
  {
    public SendAudioUrl(long chatId, Uri audio) : base(chatId, audio) { }
  }

  public sealed record SendAudioFile : SendAudioFile<long>
  {
    public SendAudioFile(long chatId, InputFile audio) : base(chatId, audio) { }
  }

  namespace Usernames
  {
    public sealed record SendCachedAudio : SendAudio<string, string>
    {
      public SendCachedAudio(string username, string audio) : base(username, audio) { }
    }

    public sealed record SendAudioUrl : SendAudio<string, Uri>
    {
      public SendAudioUrl(string username, Uri audio) : base(username, audio) { }
    }

    public sealed record SendAudioFile : SendAudioFile<string>
    {
      public SendAudioFile(string username, InputFile audio) : base(username, audio) { }
    }
  }
}
