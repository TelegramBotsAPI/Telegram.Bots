// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Types
{
  public class Chat
  {
    public long Id { get; set; }

    public ChatType Type { get; set; }

    public string? Title { get; set; }

    public string? Username { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }
  }

  public sealed class ChatInfo : Chat
  {
    public ChatPhoto? Photo { get; set; }

    public string? Bio { get; set; }

    public string? Description { get; set; }

    public string? InviteLink { get; set; }

    public Message? Pinned { get; set; }

    public ChatPermissions? Permissions { get; set; }

    public int SlowModeDelay { get; set; }

    public string? StickerSetName { get; set; }

    public bool CanSetStickerSet { get; set; }

    public long? LinkedChatId { get; set; }

    public ChatLocation? Location { get; set; }
  }
}
