// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System.Collections.Generic;
using System.IO;
using Telegram.Bots.Types;

namespace Telegram.Bots
{
  public interface ISerializer
  {
    string Serialize<T>(T value, Styling styling = Styling.None);

    void Serialize<T>(T value, Stream destination);

    T Deserialize<T>(string value);

    T Deserialize<T>(Stream stream);

    IEnumerable<DataProperty> GetProperties<T>(T value);
  }
}
