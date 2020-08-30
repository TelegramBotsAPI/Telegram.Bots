// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public interface IMarkupable
  {
    ReplyMarkup? ReplyMarkup { get; set; }
  }
}
