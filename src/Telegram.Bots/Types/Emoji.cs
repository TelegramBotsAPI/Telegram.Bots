// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2021 Aman Agnihotri

using System.Runtime.Serialization;

namespace Telegram.Bots.Types
{
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
}
