// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System.Collections.Generic;
using Telegram.Bots.Types.Inline;

namespace Telegram.Bots.Requests.Inline
{
  public sealed record AnswerInlineQuery : IRequest<bool>
  {
    public string QueryId { get; }

    public IEnumerable<InlineResult> Results { get; }

    public int? CacheTime { get; init; }

    public bool? IsPersonal { get; init; }

    public string? NextOffset { get; init; }

    public string? SwitchPmText { get; init; }

    public string? SwitchPmParameter { get; init; }

    public string Method { get; } = "answerInlineQuery";

    public AnswerInlineQuery(string queryId, IEnumerable<InlineResult> results)
    {
      QueryId = queryId;
      Results = results;
    }
  }
}
