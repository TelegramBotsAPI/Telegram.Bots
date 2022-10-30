// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Tests.Units.Json;

using Bots.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Xunit;

public sealed class StringEnumTests : IClassFixture<Serializer>
{
  private const string Json = @"[""test_enum"",""another""]";

  private static readonly IEnumerable<MyEnum> Values = new List<MyEnum>
  {
    MyEnum.TestEnum, MyEnum.Another
  };

  private readonly Serializer _serializer;

  public StringEnumTests(Serializer serializer)
  {
    _serializer = serializer;
  }

  [Fact(DisplayName = "Serialization uses string name for enum values")]
  public void SerializationUsesStringNameForEnumValues()
  {
    Assert.Equal(Json, _serializer.Serialize(Values));
  }

  [Fact(DisplayName = "Deserialization uses string name for enum values")]
  public void DeserializationUsesStringNameForEnumValues()
  {
    Assert.Equal(Values,
      _serializer.Deserialize<IReadOnlyList<MyEnum>>(Json));
  }

  [Fact(DisplayName = "Serialization respects EnumMember attribute")]
  public void SerializationRespectsEnumMemberAttribute()
  {
    Assert.Equal(@"""🎲""", _serializer.Serialize(MyEnum.Dice));
  }

  [Fact(DisplayName = "Deserialization respects EnumMember attribute")]
  public void DeserializationRespectsEnumMemberAttribute()
  {
    Assert.Equal(MyEnum.Dice, _serializer.Deserialize<MyEnum>(@"""🎲"""));
  }

  private enum MyEnum
  {
    TestEnum,
    Another,

    [EnumMember(Value = "🎲")]
    Dice
  }
}
