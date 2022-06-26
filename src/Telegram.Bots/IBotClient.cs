// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots;

using Requests;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Types;
using FileInfo = Types.FileInfo;

public interface IBotClient
{
  Task<Response<T>> HandleAsync<T>(
    IRequest<T> request,
    CancellationToken token = default);

  Task<Response<FileInfo>> HandleAsync(
    string fileId,
    Stream destination,
    CancellationToken token = default);
}
