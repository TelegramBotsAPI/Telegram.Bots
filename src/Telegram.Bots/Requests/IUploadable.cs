// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests;

using System.Collections.Generic;
using System.Linq;
using Types;

public interface IUploadable
{
  IEnumerable<InputFile?> GetFiles();

  bool HasFiles()
  {
    return GetFiles().Any(file => file != null);
  }
}
