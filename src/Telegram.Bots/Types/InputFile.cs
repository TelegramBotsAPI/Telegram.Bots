// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Types;

using System;
using System.IO;

public sealed record InputFile(Stream Data)
{
  public string Id { get; } = Guid.NewGuid().ToString();

  public static implicit operator InputFile(Stream data)
  {
    return ToInputFile(data);
  }

  public static InputFile ToInputFile(Stream data)
  {
    return new(data);
  }
}
