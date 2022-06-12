// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2022 Aman Agnihotri

using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Telegram.Bots.Types;

namespace Telegram.Bots.Json.Internal
{
  using static MenuButtonSchema;
  
  internal sealed class MenuButtonConverter : JsonConverter
  {
    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
      writer.WriteValue(value);
    }

    public override object? ReadJson(
      JsonReader reader,
      Type objectType,
      object? existingValue,
      JsonSerializer serializer)
    {
      var data = JObject.Load(reader);

      if (data.Type == JTokenType.Null) return null;

      var type = data.Properties()
        .Single(property => property.Name == Type).Value
        .ToString();

      return type switch
      {
        Default => Get<DefaultMenuButton>(),
        Commands => Get<CommandsMenuButton>(),
        WebApp => Get<WebAppMenuButton>(),
        _ => null
      };

      T Get<T>() => data.ToObject<T>(serializer)!;
    }

    public override bool CanConvert(Type type) => type == typeof(MenuButton);
  }
  
  internal static class MenuButtonSchema
  {
    public const string Type = "type";
    public const string Default = "default";
    public const string Commands = "commands";
    public const string WebApp = "web_app";
  }
}
