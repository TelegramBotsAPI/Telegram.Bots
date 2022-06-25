// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2022 Aman Agnihotri

namespace Telegram.Bots.Json.Internal;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using Types;
using static MenuButtonSchema;

internal sealed class MenuButtonConverter : JsonConverter
{
  public override void WriteJson(
    JsonWriter writer,
    object? value,
    JsonSerializer serializer)
  {
    writer.WriteValue(value);
  }

  public override object? ReadJson(
    JsonReader reader,
    Type objectType,
    object? existingValue,
    JsonSerializer serializer)
  {
    JObject? data = JObject.Load(reader);

    if (data.Type == JTokenType.Null)
    {
      return null;
    }

    string type = data.Properties()
      .Single(property => property.Name == MenuButtonSchema.Type).Value
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

  public override bool CanConvert(Type type)
  {
    return type == typeof(MenuButton);
  }
}

internal static class MenuButtonSchema
{
  public const string Type = "type";
  public const string Default = "default";
  public const string Commands = "commands";
  public const string WebApp = "web_app";
}
