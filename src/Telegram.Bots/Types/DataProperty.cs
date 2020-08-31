// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Types
{
  public sealed class DataProperty
  {
    public string Name { get; }

    public string Value { get; }

    public DataProperty(string name, string value)
    {
      Name = name;
      Value = value;
    }
  }
}
