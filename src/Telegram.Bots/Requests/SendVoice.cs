// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests
{
  using System;
  using System.Collections.Generic;
  using Types;

  public abstract record SendVoice<TChatId, TVoice>(
    TChatId ChatId,
    TVoice Voice) : IRequest<VoiceMessage>, IChatTargetable<TChatId>,
    ICaptionable, INotifiable, IProtectable, IReplyable, IMarkupable
  {
    public string? Caption { get; init; }

    public ParseMode? ParseMode { get; init; }

    public IEnumerable<MessageEntity>? CaptionEntities { get; init; }

    public bool? DisableNotification { get; init; }

    public bool? ProtectContent { get; init; }

    public int? ReplyToMessageId { get; init; }

    public bool? AllowSendingWithoutReply { get; init; }

    public ReplyMarkup? ReplyMarkup { get; init; }

    public string Method => "sendVoice";
  }

  public abstract record SendVoiceFile<TChatId>(
    TChatId ChatId,
    InputFile Voice) : SendVoice<TChatId, InputFile>(ChatId, Voice), IUploadable
  {
    public int? Duration { get; init; }

    public IEnumerable<InputFile?> GetFiles()
    {
      return new[]
      {
        Voice
      };
    }
  }

  public sealed record SendCachedVoice(
    long ChatId,
    string Voice) : SendVoice<long, string>(ChatId, Voice);

  public sealed record SendVoiceUrl(
    long ChatId,
    Uri Voice) : SendVoice<long, Uri>(ChatId, Voice);

  public sealed record SendVoiceFile(
    long ChatId,
    InputFile Voice) : SendVoiceFile<long>(ChatId, Voice);

  namespace Usernames
  {
    public sealed record SendCachedVoice(
      string ChatId,
      string Voice) : SendVoice<string, string>(ChatId, Voice);

    public sealed record SendVoiceUrl(
      string ChatId,
      Uri Voice) : SendVoice<string, Uri>(ChatId, Voice);

    public sealed record SendVoiceFile(
      string ChatId,
      InputFile Voice) : SendVoiceFile<string>(ChatId, Voice);
  }
}
