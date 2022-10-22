// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Types.Inline;

using System.Runtime.Serialization;

public enum ThumbMimeType
{
  [EnumMember(Value = "image/jpeg")]
  Jpeg,

  [EnumMember(Value = "image/gif")]
  Gif,

  [EnumMember(Value = "video/mp4")]
  Video
}
