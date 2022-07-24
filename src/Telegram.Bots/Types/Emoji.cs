// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Types;

using System.Runtime.Serialization;

public enum Emoji
{
  [EnumMember(Value = "🎲")]
  Dice,

  [EnumMember(Value = "🎯")]
  Dart,

  [EnumMember(Value = "🎳")]
  Bowling,

  [EnumMember(Value = "🏀")]
  Basketball,

  [EnumMember(Value = "⚽")]
  Football,

  [EnumMember(Value = "🎰")]
  SlotMachine
}
