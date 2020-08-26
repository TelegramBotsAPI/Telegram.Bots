using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Telegram.Bots.Types;

namespace Telegram.Bots.Json.Internal
{
  using static MessageSchema;

  internal sealed class MessageConverter : JsonConverter
  {
    private static readonly HashSet<string> MessageTypes = new HashSet<string> { Text };

    public override bool CanWrite => false;

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer) =>
      throw new NotImplementedException();

    public override object? ReadJson(
      JsonReader reader,
      Type objectType,
      object? existingValue,
      JsonSerializer serializer)
    {
      var data = JObject.Load(reader);

      if (data.Type == JTokenType.Null) return null;

      var types = data.Properties().Where(property => MessageTypes.Contains(property.Name))
        .Select(property => property.Name).ToHashSet();

      if (types.Count == 0) return null;

      return types.Single() switch
      {
        Text => Get<TextMessage>(),
        _ => null
      };

      T Get<T>() => data.ToObject<T>(serializer)!;
    }

    public override bool CanConvert(Type objectType) => objectType == typeof(Message);
  }

  internal static class MessageSchema
  {
    public const string Text = "text";
  }
}
