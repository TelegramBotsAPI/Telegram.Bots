// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System;
using System.Collections.Generic;
using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public abstract class SendVoice<TChatId, TVoice> : IRequest<VoiceMessage>,
    IChatTargetable<TChatId>, ICaptionable, INotifiable, IReplyable, IMarkupable
  {
    public TChatId ChatId { get; }

    public TVoice Voice { get; }

    public string? Caption { get; set; }

    public ParseMode? ParseMode { get; set; }

    public bool? DisableNotification { get; set; }

    public int? ReplyToMessageId { get; set; }

    public bool? AllowSendingWithoutReply { get; set; }

    public ReplyMarkup? ReplyMarkup { get; set; }

    public string Method { get; } = "sendVoice";

    protected SendVoice(TChatId chatId, TVoice voice)
    {
      ChatId = chatId;
      Voice = voice;
    }
  }

  public abstract class SendVoiceFile<TChatId> : SendVoice<TChatId, InputFile>, IUploadable
  {
    public int? Duration { get; set; }

    protected SendVoiceFile(TChatId chatId, InputFile voice) : base(chatId, voice) { }

    public IEnumerable<InputFile?> GetFiles() => new[] { Voice };
  }

  public sealed class SendCachedVoice : SendVoice<long, string>
  {
    public SendCachedVoice(long chatId, string voice) : base(chatId, voice) { }
  }

  public sealed class SendVoiceUrl : SendVoice<long, Uri>
  {
    public SendVoiceUrl(long chatId, Uri voice) : base(chatId, voice) { }
  }

  public sealed class SendVoiceFile : SendVoiceFile<long>
  {
    public SendVoiceFile(long chatId, InputFile voice) : base(chatId, voice) { }
  }

  namespace Usernames
  {
    public sealed class SendCachedVoice : SendVoice<string, string>
    {
      public SendCachedVoice(string username, string voice) : base(username, voice) { }
    }

    public sealed class SendVoiceUrl : SendVoice<string, Uri>
    {
      public SendVoiceUrl(string username, Uri voice) : base(username, voice) { }
    }

    public sealed class SendVoiceFile : SendVoiceFile<string>
    {
      public SendVoiceFile(string username, InputFile voice) : base(username, voice) { }
    }
  }
}
