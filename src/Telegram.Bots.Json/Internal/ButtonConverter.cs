using System;
using Newtonsoft.Json;
using Telegram.Bots.Types;

namespace Telegram.Bots.Json.Internal
{
  internal sealed class ButtonConverter : JsonConverter<Button>
  {
    public override bool CanRead => false;

    public override void WriteJson(JsonWriter writer, Button? value, JsonSerializer serializer)
    {
      if (value != null) writer.WriteValue(value.Text);
    }

    public override Button ReadJson(
      JsonReader reader,
      Type objectType,
      Button? existingValue,
      bool hasExistingValue,
      JsonSerializer serializer) =>
      throw new NotImplementedException();
  }
}
