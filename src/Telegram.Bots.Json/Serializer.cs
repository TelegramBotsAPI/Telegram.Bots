using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Telegram.Bots.Json.Internal;
using Telegram.Bots.Types;

namespace Telegram.Bots.Json
{
  public sealed class Serializer : ISerializer
  {
    private static readonly JsonSerializerSettings Settings = CreateSettings();

    private readonly JsonSerializer _serializer = JsonSerializer.Create(Settings);

    public string Serialize<T>(T value, Styling styling = Styling.None)
    {
      var builder = new StringBuilder(256);

      Serialize(value, new StringWriter(builder, CultureInfo.InvariantCulture), styling);

      return builder.ToString();
    }

    public void Serialize<T>(T value, Stream destination) =>
      Serialize(value, new StreamWriter(destination));

    public T Deserialize<T>(string value) => Deserialize<T>(new StringReader(value));

    public T Deserialize<T>(Stream stream) => Deserialize<T>(new StreamReader(stream));

    public IEnumerable<DataProperty> GetProperties<T>(T value)
    {
      if (value is null) throw new ArgumentNullException(nameof(value));

      return JObject.FromObject(value, _serializer).Properties().Select(property =>
        new DataProperty(property.Name, property.Value.ToString()));
    }

    private void Serialize<T>(T value, TextWriter textWriter, Styling styling = Styling.None)
    {
      JsonTextWriter? writer = null;
      try
      {
        writer = new JsonTextWriter(textWriter)
        {
          Formatting = styling == Styling.None ? Formatting.None : Formatting.Indented
        };

        _serializer.Serialize(writer, value);
      }
      finally
      {
        writer?.Close();
      }
    }

    private T Deserialize<T>(TextReader textReader)
    {
      JsonTextReader? reader = null;
      try
      {
        reader = new JsonTextReader(textReader);

        return _serializer.Deserialize<T>(reader)!;
      }
      finally
      {
        reader?.Close();
      }
    }

    private static JsonSerializerSettings CreateSettings()
    {
      var strategy = new SnakeCaseNamingStrategy();

      return new JsonSerializerSettings
      {
        ContractResolver = new ContractResolver { NamingStrategy = strategy },
        NullValueHandling = NullValueHandling.Ignore,
        Converters = { new StringEnumConverter(strategy) }
      };
    }
  }
}
