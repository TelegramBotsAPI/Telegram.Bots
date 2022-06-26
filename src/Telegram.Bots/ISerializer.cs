// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots;

using System.Collections.Generic;
using System.IO;
using Types;

public interface ISerializer
{
  string Serialize<T>(T value);

  T Deserialize<T>(string value);

  T Deserialize<T>(Stream stream);

  IEnumerable<DataProperty> GetProperties<T>(T value);
}
