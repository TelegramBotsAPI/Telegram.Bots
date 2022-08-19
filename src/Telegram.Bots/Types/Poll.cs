// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Types;

using System;
using System.Collections.Generic;

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
  public override PollType? Type => PollType.Regular;

  public bool? AllowsMultipleAnswers { get; init; }
}

public sealed record QuizPoll : Poll
{
  public override PollType? Type => PollType.Quiz;

  public uint? CorrectOptionId { get; init; }

  public string? Explanation { get; init; }

  public IReadOnlyList<MessageEntity>? ExplanationEntities { get; init; }
}
