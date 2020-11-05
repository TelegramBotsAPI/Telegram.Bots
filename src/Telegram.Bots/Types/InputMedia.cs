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
    bool? DisableContentTypeDetection { get; set; }

    IEnumerable<InputFile?> GetFiles();
  }

  public abstract class InputMedia<TMedia> : IInputMedia
  {
    public abstract InputMediaType Type { get; }

    public TMedia Media { get; }

    public string? Caption { get; set; }

    public ParseMode? ParseMode { get; set; }

    public IEnumerable<MessageEntity>? CaptionEntities { get; set; }

    protected InputMedia(TMedia media) => Media = media;
  }
}
