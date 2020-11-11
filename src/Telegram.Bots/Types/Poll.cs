// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System;
using System.Collections.Generic;

namespace Telegram.Bots.Types
{
  public abstract record Poll
  {
    public string Id { get; init; } = null!;

    public string Question { get; init; } = null!;

    public IReadOnlyList<PollOption> Options { get; init; } = null!;

    public int TotalVoterCount { get; init; }

    public bool IsClosed { get; init; }

    public bool IsAnonymous { get; init; }

    public abstract PollType? Type { get; }

    public int? OpenPeriod { get; init; }

    public DateTime? CloseDate { get; init; }
  }

  public sealed record RegularPoll : Poll
  {
    public override PollType? Type { get; } = PollType.Regular;

    public bool? AllowsMultipleAnswers { get; init; }
  }

  public sealed record QuizPoll : Poll
  {
    public override PollType? Type { get; } = PollType.Quiz;

    public uint? CorrectOptionId { get; init; }

    public string? Explanation { get; init; }

    public IReadOnlyList<MessageEntity>? ExplanationEntities { get; init; }
  }
}
