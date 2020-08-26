using Xunit;

namespace Telegram.Bots.Json.Tests.Units
{
  public sealed class SnakeCaseTests : IClassFixture<Serializer>
  {
    private const string Json = @"{""file_id"":1,""first_name"":""Some"",""is_bot"":true}";

    private static readonly SnakeClass Value =
      new SnakeClass { FileId = 1, FirstName = "Some", IsBot = true };

    private readonly Serializer _serializer;

    public SnakeCaseTests(Serializer serializer) => _serializer = serializer;

    [Fact(DisplayName = "Serialization uses snake_case naming strategy")]
    public void SerializationUsesSnakeCaseNamingStrategy() =>
      Assert.Equal(Json, _serializer.Serialize(Value));

    [Fact(DisplayName = "Deserialization uses snake_case naming strategy")]
    public void DeserializationUsesSnakeCaseNamingStrategy()
    {
      var value = _serializer.Deserialize<SnakeClass>(Json);

      Assert.Equal(Value.FileId, value.FileId);
      Assert.Equal(Value.FirstName, value.FirstName);
      Assert.True(value.IsBot);
    }

    [Fact(DisplayName = "Deserialization does not work with camelCase json")]
    public void DeserializationDoesNotWorkWithCamelCaseJson()
    {
      const string json = @"{""fileId"":1,""firstName"":""Some"",""isBot"":true}";

      var value = _serializer.Deserialize<SnakeClass>(json);

      Assert.Equal(default, value.FileId);
      Assert.Equal(default, value.FirstName);
      Assert.Equal(default, value.IsBot);
    }

    private class SnakeClass
    {
      public int FileId { get; set; }

      public string FirstName { get; set; } = null!;

      public bool IsBot { get; set; }
    }
  }
}
