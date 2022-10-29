// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Extensions.Polling;

using System.Threading;
using System.Threading.Tasks;
using Types;

public interface IUpdateHandler
{
  public Task HandleAsync(
    IBotClient bot,
    Update update,
    CancellationToken token);
}
