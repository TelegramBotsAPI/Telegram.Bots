// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2021 Aman Agnihotri

using System.Collections.Generic;
using Telegram.Bots.Types;

namespace Telegram.Bots.Requests.Stickers
{
  public sealed record UploadStickerFile : IRequest<FileInfo>, IUserTargetable, IUploadable
  {
    public long UserId { get; }

    public InputFile Sticker { get; }

    public string Method { get; } = "uploadStickerFile";

    public UploadStickerFile(long userId, InputFile sticker)
    {
      UserId = userId;
      Sticker = sticker;
    }

    public IEnumerable<InputFile?> GetFiles() => new[] {Sticker};
  }
}
