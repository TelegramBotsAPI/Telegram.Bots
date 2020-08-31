// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System.Collections.Generic;
using Telegram.Bots.Types.Inline;

namespace Telegram.Bots.Requests.Inline
{
  public sealed class AnswerInlineQuery : IRequest<bool>
  {
    public string QueryId { get; }

    public IEnumerable<InlineResult> Results { get; }

    public int? CacheTime { get; set; }

    public bool? IsPersonal { get; set; }

    public string? NextOffset { get; set; }

    public string? SwitchPmText { get; set; }

    public string? SwitchPmParameter { get; set; }

    public string Method { get; } = "answerInlineQuery";

    public AnswerInlineQuery(string queryId, IEnumerable<InlineResult> results)
    {
      QueryId = queryId;
      Results = results;
    }
  }
}
