// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bots.Extensions.Polling;
using Telegram.Bots.Requests;
using Telegram.Bots.Types;

namespace Telegram.Bots.Echo.Polling.Services
{
  public sealed class EchoService : IUpdateHandler
  {
    public Task HandleAsync(IBotClient bot, Update update, CancellationToken token)
    {
      if (bot is null) throw new ArgumentNullException(nameof(bot));

      return update switch
      {
        MessageUpdate u when u.Data is TextMessage message => EchoText(message),
        _ => Task.CompletedTask
      };

      Task EchoText(TextMessage message) =>
        bot.HandleAsync(new SendText(message.Chat.Id, message.Text), token);
    }
  }
}
