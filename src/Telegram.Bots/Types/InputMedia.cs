// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Types;

using System.Collections.Generic;

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

public abstract record InputMedia<TMedia>(TMedia Media) : IInputMedia
{
  public abstract InputMediaType Type { get; }

  public string? Caption { get; init; }

  public ParseMode? ParseMode { get; init; }

  public IEnumerable<MessageEntity>? CaptionEntities { get; init; }
}
