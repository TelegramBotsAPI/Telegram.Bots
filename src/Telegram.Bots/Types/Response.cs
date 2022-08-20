// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Types;

public sealed record Response<TResult>
{
  public TResult Result { get; } = default!;

  public Failure Failure { get; } = default!;

  public bool Ok { get; }

  public Response(TResult result)
  {
    Result = result;
    Ok = true;
  }

  public Response(Failure failure)
  {
    Failure = failure;
  }
}

public sealed record Success<TResult>(TResult Result);

public sealed record Failure
{
  public string? Description { get; init; }

  public int? ErrorCode { get; init; }

  public ResponseParameters? Parameters { get; init; }
}

public sealed record ResponseParameters
{
  public long? MigrateToChatId { get; init; }

  public int? RetryAfter { get; init; }
}
