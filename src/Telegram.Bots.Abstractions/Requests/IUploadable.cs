// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System.Collections.Generic;
using System.Linq;
using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public interface IUploadable
  {
    IEnumerable<InputFile?> GetFiles();

    bool HasFiles() => GetFiles().Any(file => file != null);
  }
}
