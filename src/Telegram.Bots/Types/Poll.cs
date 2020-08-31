// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System;
using System.Collections.Generic;

namespace Telegram.Bots.Types
{
  public abstract class Poll
  {
    public string Id { get; set; } = null!;

    public string Question { get; set; } = null!;

    public IReadOnlyList<PollOption> Options { get; set; } = null!;

    public int TotalVoterCount { get; set; }

    public bool IsClosed { get; set; }

    public bool IsAnonymous { get; set; }

    public abstract PollType? Type { get; }

    public int? OpenPeriod { get; set; }

    public DateTime? CloseDate { get; set; }
  }

  public sealed class RegularPoll : Poll
  {
    public override PollType? Type { get; } = PollType.Regular;

    public bool? AllowsMultipleAnswers { get; set; }
  }

  public sealed class QuizPoll : Poll
  {
    public override PollType? Type { get; } = PollType.Quiz;

    public uint? CorrectOptionId { get; set; }

    public string? Explanation { get; set; }

    public IReadOnlyList<MessageEntity>? ExplanationEntities { get; set; }
  }
}
