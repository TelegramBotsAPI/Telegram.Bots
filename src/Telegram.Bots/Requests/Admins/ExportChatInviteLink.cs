// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests.Admins
{
  public abstract record ExportChatInviteLink<TChatId>(
    TChatId ChatId) : IRequest<string>, IChatTargetable<TChatId>
  {
    public string Method => "exportChatInviteLink";
  }

  public sealed record ExportChatInviteLink(
    long ChatId) : ExportChatInviteLink<long>(ChatId);

  namespace Usernames
  {
    public sealed record ExportChatInviteLink(
      string ChatId) : ExportChatInviteLink<string>(ChatId);
  }
}
