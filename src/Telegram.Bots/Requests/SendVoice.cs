// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System;
using System.Collections.Generic;
using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public abstract record SendVoice<TChatId, TVoice> : IRequest<VoiceMessage>,
    IChatTargetable<TChatId>, ICaptionable, INotifiable, IReplyable, IMarkupable
  {
    public TChatId ChatId { get; }

    public TVoice Voice { get; }

    public string? Caption { get; init; }

    public ParseMode? ParseMode { get; init; }

    public IEnumerable<MessageEntity>? CaptionEntities { get; init; }

    public bool? DisableNotification { get; init; }

    public int? ReplyToMessageId { get; init; }

    public bool? AllowSendingWithoutReply { get; init; }

    public ReplyMarkup? ReplyMarkup { get; init; }

    public string Method { get; } = "sendVoice";

    protected SendVoice(TChatId chatId, TVoice voice)
    {
      ChatId = chatId;
      Voice = voice;
    }
  }

  public abstract record SendVoiceFile<TChatId> : SendVoice<TChatId, InputFile>, IUploadable
  {
    public int? Duration { get; init; }

    protected SendVoiceFile(TChatId chatId, InputFile voice) : base(chatId, voice) { }

    public IEnumerable<InputFile?> GetFiles() => new[] { Voice };
  }

  public sealed record SendCachedVoice : SendVoice<long, string>
  {
    public SendCachedVoice(long chatId, string voice) : base(chatId, voice) { }
  }

  public sealed record SendVoiceUrl : SendVoice<long, Uri>
  {
    public SendVoiceUrl(long chatId, Uri voice) : base(chatId, voice) { }
  }

  public sealed record SendVoiceFile : SendVoiceFile<long>
  {
    public SendVoiceFile(long chatId, InputFile voice) : base(chatId, voice) { }
  }

  namespace Usernames
  {
    public sealed record SendCachedVoice : SendVoice<string, string>
    {
      public SendCachedVoice(string username, string voice) : base(username, voice) { }
    }

    public sealed record SendVoiceUrl : SendVoice<string, Uri>
    {
      public SendVoiceUrl(string username, Uri voice) : base(username, voice) { }
    }

    public sealed record SendVoiceFile : SendVoiceFile<string>
    {
      public SendVoiceFile(string username, InputFile voice) : base(username, voice) { }
    }
  }
}
