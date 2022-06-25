// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Json;

using Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Types;

public sealed class Serializer : ISerializer
{
  private static readonly JsonSerializerSettings Settings = CreateSettings();

  private readonly JsonSerializer _serializer = JsonSerializer.Create(Settings);

  public string Serialize<T>(T value)
  {
    StringBuilder builder = new(256);

    Serialize(value, new StringWriter(builder, CultureInfo.InvariantCulture));

    return builder.ToString();
  }

  public void Serialize<T>(T value, Stream destination)
  {
    Serialize(value, new StreamWriter(destination));
  }

  public T Deserialize<T>(string value)
  {
    return Deserialize<T>(new StringReader(value));
  }

  public T Deserialize<T>(Stream stream)
  {
    return Deserialize<T>(new StreamReader(stream));
  }

  public IEnumerable<DataProperty> GetProperties<T>(T value)
  {
    if (value is null)
    {
      throw new ArgumentNullException(nameof(value));
    }

    return JObject.FromObject(value, _serializer).Properties().Select(
      property =>
        new DataProperty(property.Name, property.Value.ToString()));
  }

  public static void Modify(JsonSerializerSettings settings)
  {
    if (settings is null)
    {
      throw new ArgumentNullException(nameof(settings));
    }

    settings.ContractResolver = Settings.ContractResolver;
    settings.NullValueHandling = Settings.NullValueHandling;
    settings.Converters = Settings.Converters;
  }

  private void Serialize<T>(T value, TextWriter textWriter)
  {
    JsonTextWriter? writer = null;

    try
    {
      writer = new JsonTextWriter(textWriter);

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
    SnakeCaseNamingStrategy strategy = new();

    return new JsonSerializerSettings
    {
      ContractResolver = new ContractResolver
      {
        NamingStrategy = strategy
      },
      NullValueHandling = NullValueHandling.Ignore,
      Converters =
      {
        new UnixDateTimeConverter(),
        new StringEnumConverter(strategy),
        new CallbackQueryConverter(),
        new ChatMemberConverter(),
        new InlineButtonConverter(),
        new InputFileConverter(),
        new MenuButtonConverter(),
        new MessageConverter(),
        new PollConverter(),
        new TextButtonConverter(),
        new UpdateConverter()
      }
    };
  }
}
