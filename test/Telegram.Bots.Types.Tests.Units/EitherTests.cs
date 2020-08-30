// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using Xunit;

namespace Telegram.Bots.Types.Tests.Units
{
  public sealed class EitherTests
  {
    [Fact(DisplayName = "Left Either has IsLeft as True and Right Value as Default")]
    public void LeftEitherHasIsLeftAsTrueAndRightValueAsDefault()
    {
      Either<bool, int> either = false;

      Assert.True(either.IsLeft);
      Assert.False(either.Left);
      Assert.Equal(default, either.Right);
    }

    [Fact(DisplayName = "Right Either has IsLeft as False and Left Value as Default")]
    public void RightEitherHasIsLeftAsFalseAndLeftValueAsDefault()
    {
      Either<bool, int> either = 4;

      Assert.False(either.IsLeft);
      Assert.Equal(default, either.Left);
      Assert.Equal(4, either.Right);
    }
  }
}
