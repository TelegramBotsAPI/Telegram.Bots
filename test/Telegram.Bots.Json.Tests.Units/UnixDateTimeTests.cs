// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System;
using Xunit;

namespace Telegram.Bots.Json.Tests.Units
{
  public sealed class UnixDateTimeTests : IClassFixture<Serializer>
  {
    private readonly Serializer _serializer;

    private const string Json = @"{""unix_date"":749008680,""date"":749008680}";

    private static readonly UnixDateTimeClass Value = new UnixDateTimeClass
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
      var value = _serializer.Deserialize<UnixDateTimeClass>(Json);

      Assert.Equal(Value.UnixDate, value.UnixDate);
      Assert.Equal(Value.Date, value.Date);
    }

    private class UnixDateTimeClass
    {
      public long UnixDate { get; set; }

      public DateTime Date { get; set; }
    }
  }
}
