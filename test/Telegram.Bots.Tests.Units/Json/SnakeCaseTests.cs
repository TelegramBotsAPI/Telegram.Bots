// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Tests.Units.Json;

using Bots.Json;
using Xunit;

public sealed class SnakeCaseTests : IClassFixture<Serializer>
{
  private const string Json =
    @"{""file_id"":1,""first_name"":""Some"",""is_bot"":true}";

  private static readonly SnakeData Value = new()
  {
    FileId = 1, FirstName = "Some", IsBot = true
  };

  private readonly Serializer _serializer;

  public SnakeCaseTests(Serializer serializer)
  {
    _serializer = serializer;
  }

  [Fact(DisplayName = "Serialization uses snake_case naming strategy")]
  public void SerializationUsesSnakeCaseNamingStrategy()
  {
    Assert.Equal(Json, _serializer.Serialize(Value));
  }

  [Fact(DisplayName = "Deserialization uses snake_case naming strategy")]
  public void DeserializationUsesSnakeCaseNamingStrategy()
  {
    SnakeData value = _serializer.Deserialize<SnakeData>(Json);

    Assert.Equal(Value.FileId, value.FileId);
    Assert.Equal(Value.FirstName, value.FirstName);
    Assert.True(value.IsBot);
  }

  [Fact(DisplayName = "Deserialization does not work with camelCase json")]
  public void DeserializationDoesNotWorkWithCamelCaseJson()
  {
    const string json = @"{""fileId"":1,""firstName"":""Some"",""isBot"":true}";

    SnakeData value = _serializer.Deserialize<SnakeData>(json);

    Assert.Equal(default, value.FileId);
    Assert.Equal(default, value.FirstName);
    Assert.Equal(default, value.IsBot);
  }

  private sealed record SnakeData
  {
    public int FileId { get; init; }

    public string FirstName { get; init; } = null!;

    public bool IsBot { get; init; }
  }
}
