// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2021 Aman Agnihotri

using System;
using Telegram.Bots.Json;
using Xunit;

namespace Telegram.Bots.Tests.Units.Json
{
  public sealed class UnixDateTimeTests : IClassFixture<Serializer>
  {
    private readonly Serializer _serializer;

    private const string Json = @"{""unix_date"":749008680,""date"":749008680}";

    private static readonly UnixDateTimeData Value = new()
    {
      UnixDate = 749008680L,
      Date = new DateTime(1993, 9, 26, 1, 58, 0, DateTimeKind.Utc)
    };

    public UnixDateTimeTests(Serializer serializer) => _serializer = serializer;

    [Fact(DisplayName = "Serialization converts DateTime to integer-based unix value")]
    public void SerializationConvertsDateTimeToUnixValue() =>
      Assert.Equal(Json, _serializer.Serialize(Value));

    [Fact(DisplayName = "Deserialization converts integer-based unix value to DateTime")]
    public void DeserializationConvertsUnixValueToDateTime()
    {
      var value = _serializer.Deserialize<UnixDateTimeData>(Json);

      Assert.Equal(Value.UnixDate, value.UnixDate);
      Assert.Equal(Value.Date, value.Date);
    }

    private sealed record UnixDateTimeData
    {
      public long UnixDate { get; init; }

      public DateTime Date { get; init; }
    }
  }
}
