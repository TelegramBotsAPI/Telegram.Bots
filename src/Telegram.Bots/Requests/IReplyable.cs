// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Requests
{
  public interface IReplyable
  {
    int? ReplyToMessageId { get; set; }

    bool? AllowSendingWithoutReply { get; set; }
  }
}
