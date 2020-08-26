using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Telegram.Bots.Types;

namespace Telegram.Bots.Json.Internal
{
  using static CallbackQuerySchema;
  using static CallbackQueryFlags;

  internal class CallbackQueryConverter : JsonConverter
  {
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

      var type = (data.ContainsKey(Data) ? HasData : None) |
                 (data.ContainsKey(MessageId) ? IsInline : None);

      return type switch
      {
        None => Get<GameCallbackQuery>(),
        HasData => Get<MessageCallbackQuery>(),
        IsInline => Get<InlineGameCallbackQuery>(),
        HasData | IsInline => Get<InlineMessageCallbackQuery>(),
        _ => null
      };

      T Get<T>() => data.ToObject<T>(serializer)!;
    }

    public override bool CanConvert(Type objectType) => objectType == typeof(CallbackQuery);
  }

  [Flags]
  internal enum CallbackQueryFlags
  {
    None = 0b00,
    HasData = 0b01,
    IsInline = 0b10
  }

  internal static class CallbackQuerySchema
  {
    public const string MessageId = "inline_message_id";
    public const string Data = "data";
  }
}
