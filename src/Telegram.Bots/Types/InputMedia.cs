// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System.Collections.Generic;

namespace Telegram.Bots.Types
{
  public interface IInputMedia
  {
    InputMediaType Type { get; }
  }

  public interface IGroupableMedia : IInputMedia { }

  public interface IUploadableMedia : IInputMedia
  {
    bool? DisableContentTypeDetection { get; init; }

    IEnumerable<InputFile?> GetFiles();
  }

  public abstract record InputMedia<TMedia> : IInputMedia
  {
    public abstract InputMediaType Type { get; }

    public TMedia Media { get; }

    public string? Caption { get; init; }

    public ParseMode? ParseMode { get; init; }

    public IEnumerable<MessageEntity>? CaptionEntities { get; init; }

    protected InputMedia(TMedia media) => Media = media;
  }
}
