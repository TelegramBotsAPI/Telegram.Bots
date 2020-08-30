// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using Xunit;

namespace Telegram.Bots.Types.Tests.Units
{
  public sealed class ResponseTests
  {
    [Fact(DisplayName = "Success Response has Ok as True and Failure Value as Default")]
    public void SuccessResponseHasOkAsTrueAndFailureValueAsDefault()
    {
      var response = new Response<int>(4);

      Assert.True(response.Ok);
      Assert.Equal(4, response.Result);
      Assert.Equal(default, response.Failure);
    }

    [Fact(DisplayName = "Failure Response has Ok as False and Result Value as Default")]
    public void FailureResponseHasOkAsFalseAndResultValueAsDefault()
    {
      var response = new Response<int>(new Failure { Description = "Timeout", ErrorCode = 408 });

      Assert.False(response.Ok);
      Assert.Equal(default, response.Result);
      Assert.Equal("Timeout", response.Failure.Description);
      Assert.Equal(408, response.Failure.ErrorCode);
      Assert.Equal(default, response.Failure.Parameters);
    }
  }
}
