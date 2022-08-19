// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Types;

using System.Runtime.Serialization;

public enum ParseMode
{
  Html,
  Markdown,

  [EnumMember(Value = "MarkdownV2")]
  MarkdownV2
}
