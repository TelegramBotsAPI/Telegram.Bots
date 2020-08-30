// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System.Threading;
using System.Threading.Tasks;
using Telegram.Bots.Types;

namespace Telegram.Bots.Extensions.Polling
{
  public interface IUpdateHandler
  {
    public Task HandleAsync(IBotClient bot, Update update, CancellationToken token);
  }
}
