// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System;

namespace Telegram.Bots.Types
{
  public readonly struct ButtonPollType : IEquatable<ButtonPollType>
  {
    public static readonly ButtonPollType AnyPoll = new ButtonPollType(null);

    public PollType? Type { get; }

    public ButtonPollType(PollType? type) => Type = type;

    public bool Equals(ButtonPollType other) => Type == other.Type;

    public override bool Equals(object? obj) => obj is ButtonPollType other && Equals(other);

    public override int GetHashCode() => Type.GetHashCode();

    public static bool operator ==(ButtonPollType left, ButtonPollType right) => left.Equals(right);

    public static bool operator !=(ButtonPollType left, ButtonPollType right) => !(left == right);
  }
}
