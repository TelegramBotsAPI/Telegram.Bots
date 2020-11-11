// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System;
using System.IO;

namespace Telegram.Bots.Types
{
  public sealed record InputFile
  {
    public string Id { get; } = Guid.NewGuid().ToString();

    public Stream Data { get; }

    public InputFile(Stream data) => Data = data;

    public static implicit operator InputFile(Stream data) => ToInputFile(data);

    public static InputFile ToInputFile(Stream data) => new InputFile(data);
  }
}
