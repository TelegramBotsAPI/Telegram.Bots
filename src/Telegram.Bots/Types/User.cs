// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Types
{
  public record User
  {
    public long Id { get; init; }

    public bool IsBot { get; init; }

    public string FirstName { get; init; } = null!;

    public string? LastName { get; init; }

    public string? Username { get; init; }

    public string? LanguageCode { get; init; }
  }

  public sealed record MyBot : User
  {
    public bool CanJoinGroups { get; init; }

    public bool CanReadAllGroupMessages { get; init; }

    public bool SupportsInlineQueries { get; init; }
  }
}
