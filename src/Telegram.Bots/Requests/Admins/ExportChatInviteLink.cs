// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Requests.Admins
{
  public abstract record ExportChatInviteLink<TChatId> : IRequest<string>, IChatTargetable<TChatId>
  {
    public TChatId ChatId { get; }

    public string Method { get; } = "exportChatInviteLink";

    protected ExportChatInviteLink(TChatId chatId) => ChatId = chatId;
  }

  public sealed record ExportChatInviteLink : ExportChatInviteLink<long>
  {
    public ExportChatInviteLink(long chatId) : base(chatId) { }
  }

  namespace Usernames
  {
    public sealed record ExportChatInviteLink : ExportChatInviteLink<string>
    {
      public ExportChatInviteLink(string username) : base(username) { }
    }
  }
}
