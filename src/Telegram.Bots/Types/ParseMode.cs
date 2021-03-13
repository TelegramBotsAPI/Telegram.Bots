// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2021 Aman Agnihotri

using System.Runtime.Serialization;

namespace Telegram.Bots.Types
{
  public enum ParseMode
  {
    Html,
    Markdown,

    [EnumMember(Value = "MarkdownV2")]
    MarkdownV2
  }
}
