// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests.Inline;

using System.Collections.Generic;
using Types.Inline;

public sealed record AnswerInlineQuery(
  string QueryId,
  IEnumerable<InlineResult> Results) : IRequest<bool>
{
  public int? CacheTime { get; init; }

  public bool? IsPersonal { get; init; }

  public string? NextOffset { get; init; }

  public string? SwitchPmText { get; init; }

  public string? SwitchPmParameter { get; init; }

  public string Method => "answerInlineQuery";
}
