// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Tests.Units.Types;

using Bots.Types;
using Xunit;

public sealed class ResponseTests
{
  [Fact(DisplayName =
    "Success Response has Ok as True and Failure Value as Default")]
  public void SuccessResponseHasOkAsTrueAndFailureValueAsDefault()
  {
    Response<int> response = new(4);

    Assert.True(response.Ok);
    Assert.Equal(4, response.Result);
    Assert.Equal(default, response.Failure);
  }

  [Fact(DisplayName =
    "Failure Response has Ok as False and Result Value as Default")]
  public void FailureResponseHasOkAsFalseAndResultValueAsDefault()
  {
    Response<int> response = new(new Failure
    {
      Description = "Timeout", ErrorCode = 408
    });

    Assert.False(response.Ok);
    Assert.Equal(default, response.Result);
    Assert.Equal("Timeout", response.Failure.Description);
    Assert.Equal(408, response.Failure.ErrorCode);
    Assert.Equal(default, response.Failure.Parameters);
  }
}
