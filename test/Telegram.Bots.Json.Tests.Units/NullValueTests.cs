using Xunit;

namespace Telegram.Bots.Json.Tests.Units
{
  public sealed class NullValueTests : IClassFixture<Serializer>
  {
    private readonly Serializer _serializer;

    public NullValueTests(Serializer serializer) => _serializer = serializer;

    [Fact(DisplayName = "Serialization ignores null values")]
    public void SerializationIgnoresNullValues() =>
      Assert.Equal("{}", _serializer.Serialize(new NullClass()));

    [Fact(DisplayName = "Serialization does not ignore non-null values")]
    public void SerializationDoesNotIgnoreNonNullValues()
    {
      const string json = @"{""file_id"":0,""first_name"":"""",""is_bot"":false}";

      var value = new NullClass { FileId = 0, FirstName = "", IsBot = false };

      Assert.Equal(json, _serializer.Serialize(value));
    }

    [Fact(DisplayName = "Deserialization retains null values")]
    public void DeserializationRetainsNullValues()
    {
      NullClass value = _serializer.Deserialize<NullClass>("{}");

      Assert.Null(value.FileId);
      Assert.Null(value.FirstName);
      Assert.Null(value.IsBot);
    }

    private class NullClass
    {
      public int? FileId { get; set; }

      public string? FirstName { get; set; }

      public bool? IsBot { get; set; }
    }
  }
}
