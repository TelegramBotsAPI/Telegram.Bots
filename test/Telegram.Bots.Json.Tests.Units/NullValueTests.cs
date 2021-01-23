// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2021 Aman Agnihotri

using Xunit;

namespace Telegram.Bots.Json.Tests.Units
{
  public sealed class NullValueTests : IClassFixture<Serializer>
  {
    private readonly Serializer _serializer;

    public NullValueTests(Serializer serializer) => _serializer = serializer;

    [Fact(DisplayName = "Serialization ignores null values")]
    public void SerializationIgnoresNullValues() =>
      Assert.Equal("{}", _serializer.Serialize(new NullData()));

    [Fact(DisplayName = "Serialization does not ignore non-null values")]
    public void SerializationDoesNotIgnoreNonNullValues()
    {
      const string json = @"{""file_id"":0,""first_name"":"""",""is_bot"":false}";

      var value = new NullData { FileId = 0, FirstName = "", IsBot = false };

      Assert.Equal(json, _serializer.Serialize(value));
    }

    [Fact(DisplayName = "Deserialization retains null values")]
    public void DeserializationRetainsNullValues()
    {
      NullData value = _serializer.Deserialize<NullData>("{}");

      Assert.Null(value.FileId);
      Assert.Null(value.FirstName);
      Assert.Null(value.IsBot);
    }

    private sealed record NullData
    {
      public int? FileId { get; init; }

      public string? FirstName { get; init; }

      public bool? IsBot { get; init; }
    }
  }
}
