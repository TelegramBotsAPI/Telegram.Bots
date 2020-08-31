// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Types
{
  public sealed class Response<TResult>
  {
    public TResult Result { get; } = default!;

    public Failure Failure { get; } = default!;

    public bool Ok { get; }

    public Response(TResult result)
    {
      Result = result;
      Ok = true;
    }

    public Response(Failure failure) => Failure = failure;
  }

  public sealed class Success<TResult>
  {
    public TResult Result { get; }

    public Success(TResult result) => Result = result;
  }

  public sealed class Failure
  {
    public string? Description { get; set; }

    public int? ErrorCode { get; set; }

    public ResponseParameters? Parameters { get; set; }
  }

  public sealed class ResponseParameters
  {
    public long? MigrateToChatId { get; set; }

    public int? RetryAfter { get; set; }
  }
}
