// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Tests.Units.Json;

using Bots.Json;
using Bots.Types;
using System;
using Xunit;

public sealed class PollTests : IClassFixture<Serializer>
{
  private readonly Serializer _serializer;

  public PollTests(Serializer serializer)
  {
    _serializer = serializer;
  }

  public static TheoryData<(string, Type)> DeserializationData => new()
  {
    (@"{""type"":""regular""}", typeof(RegularPoll)),
    (@"{""type"":""quiz""}", typeof(QuizPoll))
  };

  [Theory(DisplayName = "Poll deserializes correctly")]
  [MemberData(nameof(DeserializationData))]
  public void PollDeserializesCorrectly((string, Type) tuple)
  {
    (string value, Type type) = tuple;

    Assert.IsAssignableFrom(type, _serializer.Deserialize<Poll>(value));
  }
}
