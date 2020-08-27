using System;
using System.IO;
using Telegram.Bots.Types;
using Xunit;

namespace Telegram.Bots.Json.Tests.Units
{
  public sealed class InputFileTests : IClassFixture<Serializer>
  {
    private static readonly InputFile File = Stream.Null;

    private readonly Serializer _serializer;

    public InputFileTests(Serializer serializer) => _serializer = serializer;

    [Fact(DisplayName = "Serialization prepends \"attach://\" to Id")]
    public void SerializationPrependsAttachSchemeToId() =>
      Assert.Equal($@"""attach://{File.Id}""", _serializer.Serialize(File));

    [Fact(DisplayName = "Deserialization throws NotImplementedException")]
    public void DeserializationThrowsNotImplementedException() =>
      Assert.Throws<NotImplementedException>(() =>
        _serializer.Deserialize<InputFile>(_serializer.Serialize(File)));
  }
}
