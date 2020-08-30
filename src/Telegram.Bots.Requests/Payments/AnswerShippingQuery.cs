// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System.Collections.Generic;
using Telegram.Bots.Types.Payments;

namespace Telegram.Bots.Requests.Payments
{
  public sealed class AnswerShippingQuery : IRequest<bool>
  {
    public string QueryId { get; }

    public bool Ok { get; }

    public IEnumerable<ShippingOption>? Options { get; }

    public string? ErrorMessage { get; }

    public string Method { get; } = "answerShippingQuery";

    public AnswerShippingQuery(string queryId, IEnumerable<ShippingOption>? options)
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
}
