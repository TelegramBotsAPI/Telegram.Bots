// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2022 Aman Agnihotri

namespace Telegram.Bots.Requests.Inline;

using Types.Inline;

public sealed record AnswerWebAppQuery(
  string QueryId,
  InlineResult Result) : IRequest<SentWebAppMessage>
{
  public string Method => "answerWebAppQuery";
}
