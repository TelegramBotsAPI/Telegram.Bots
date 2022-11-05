// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Types;

using System.Collections.Generic;

public record Chat
{
  public long Id { get; init; }

  public ChatType Type { get; init; }

  public string? Title { get; init; }

  public string? Username { get; init; }

  public string? FirstName { get; init; }

  public string? LastName { get; init; }

  public bool IsForum { get; init; }
}

public sealed record ChatInfo : Chat
{
  public ChatPhoto? Photo { get; init; }

  public IReadOnlyList<string>? ActiveUsernames { get; init; }

  public string? EmojiStatusCustomEmojiId { get; init; }

  public string? Bio { get; init; }

  public string? Description { get; init; }

  public string? InviteLink { get; init; }

  public Message? Pinned { get; init; }

  public ChatPermissions? Permissions { get; init; }

  public int SlowModeDelay { get; init; }

  public bool HasPrivateForwards { get; init; }

  public bool HasRestrictedVoiceAndVideoMessages { get; init; }

  public bool JoinToSendMessages { get; init; }

  public bool JoinByRequest { get; init; }

  public bool HasProtectedContent { get; init; }

  public string? StickerSetName { get; init; }

  public bool CanSetStickerSet { get; init; }

  public long? LinkedChatId { get; init; }

  public ChatLocation? Location { get; init; }
}
