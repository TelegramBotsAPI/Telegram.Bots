// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Types;

using System;

public readonly struct ButtonPollType : IEquatable<ButtonPollType>
{
  public static readonly ButtonPollType AnyPoll = new(null);

  public PollType? Type { get; }

  public ButtonPollType(PollType? type)
  {
    Type = type;
  }

  public bool Equals(ButtonPollType other)
  {
    return Type == other.Type;
  }

  public override bool Equals(object? obj)
  {
    return obj is ButtonPollType other && Equals(other);
  }

  public override int GetHashCode()
  {
    return Type.GetHashCode();
  }

  public static bool operator ==(ButtonPollType left, ButtonPollType right)
  {
    return left.Equals(right);
  }

  public static bool operator !=(ButtonPollType left, ButtonPollType right)
  {
    return !(left == right);
  }
}
