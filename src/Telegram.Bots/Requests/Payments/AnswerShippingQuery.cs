// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests.Payments;

using System.Collections.Generic;
using Types.Payments;

public sealed record AnswerShippingQuery : IRequest<bool>
{
  public string QueryId { get; }

  public bool Ok { get; }

  public IEnumerable<ShippingOption>? Options { get; }

  public string? ErrorMessage { get; }

  public string Method => "answerShippingQuery";

  public AnswerShippingQuery(
    string queryId,
    IEnumerable<ShippingOption>? options)
  {
    QueryId = queryId;
    Options = options;
    Ok = true;
  }

  public AnswerShippingQuery(string queryId, string? errorMessage)
  {
    QueryId = queryId;
    ErrorMessage = errorMessage;
  }
}
