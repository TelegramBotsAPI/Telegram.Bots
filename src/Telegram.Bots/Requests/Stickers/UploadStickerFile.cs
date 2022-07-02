// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests.Stickers;

using System.Collections.Generic;
using Types;

public sealed record UploadStickerFile(
  long UserId,
  InputFile Sticker) : IRequest<FileInfo>, IUserTargetable, IUploadable
{
  public string Method => "uploadStickerFile";

  public IEnumerable<InputFile?> GetFiles()
  {
    return new[]
    {
      Sticker
    };
  }
}
