// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bots.Requests;
using Telegram.Bots.Types;
using FileInfo = Telegram.Bots.Types.FileInfo;

namespace Telegram.Bots
{
  public interface IBotClient
  {
    Task<Response<T>> HandleAsync<T>(IRequest<T> request, CancellationToken token = default);

    Task<Response<FileInfo>> HandleAsync(
      string fileId,
      Stream destination,
      CancellationToken token = default);
  }
}
