// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests
{
  using System;
  using Types;

  public abstract record EditMediaBase<TMedia, TResult>(
    InputMedia<TMedia> Media) : IRequest<TResult>, IInlineMarkupable
  {
    public InlineKeyboardMarkup? ReplyMarkup { get; init; }

    public string Method => "editMessageMedia";
  }

  public abstract record EditMedia<TChatId, TMedia>(
    TChatId ChatId,
    int MessageId,
    InputMedia<TMedia> Media) : EditMediaBase<TMedia, MediaMessage>(Media),
    IChatMessageTargetable<TChatId>;

  public sealed record EditMediaViaCache(
    long ChatId,
    int MessageId,
    InputMedia<string> Media) :
    EditMedia<long, string>(ChatId, MessageId, Media);

  public sealed record EditMediaViaUrl(
    long ChatId,
    int MessageId,
    InputMedia<Uri> Media) : EditMedia<long, Uri>(ChatId, MessageId, Media);

  public sealed record EditMediaViaFile(
    long ChatId,
    int MessageId,
    InputMedia<InputFile> Media) :
    EditMedia<long, InputFile>(ChatId, MessageId, Media);

  namespace Usernames
  {
    public sealed record EditMediaViaCache(
      string ChatId,
      int MessageId,
      InputMedia<string> Media) :
      EditMedia<string, string>(ChatId, MessageId, Media);

    public sealed record EditMediaViaUrl(
      string ChatId,
      int MessageId,
      InputMedia<Uri> Media) : EditMedia<string, Uri>(ChatId, MessageId, Media);

    public sealed record EditMediaViaFile(
      string ChatId,
      int MessageId,
      InputMedia<InputFile> Media) :
      EditMedia<string, InputFile>(ChatId, MessageId, Media);
  }

  namespace Inline
  {
    public abstract record EditMedia<TMedia>(
      string MessageId,
      InputMedia<TMedia> Media) : EditMediaBase<TMedia, bool>(Media),
      IInlineMessageTargetable;

    public sealed record EditMediaViaCache(
      string MessageId,
      InputMedia<string> Media) : EditMedia<string>(MessageId, Media);

    public sealed record EditMediaViaUrl(
      string MessageId,
      InputMedia<Uri> Media) : EditMedia<Uri>(MessageId, Media);
  }
}
