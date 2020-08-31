// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System.Runtime.Serialization;

namespace Telegram.Bots.Types.Inline
{
  public enum ThumbMimeType
  {
    [EnumMember(Value = "image/jpeg")] Jpeg,
    [EnumMember(Value = "image/gif")] Gif,
    [EnumMember(Value = "video/mp4")] Video
  }
}
