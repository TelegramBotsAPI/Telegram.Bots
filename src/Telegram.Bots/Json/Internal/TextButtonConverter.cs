// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Json.Internal;

using Newtonsoft.Json;
using System;
using Types;

internal sealed class TextButtonConverter : JsonConverter<TextButton>
{
  public override bool CanRead => false;

  public override void WriteJson(
    JsonWriter writer,
    TextButton? value,
    JsonSerializer serializer)
  {
    if (value != null)
    {
      writer.WriteValue(value.Text);
    }
  }

  public override TextButton ReadJson(
    JsonReader reader,
    Type objectType,
    TextButton? existingValue,
    bool hasExistingValue,
    JsonSerializer serializer)
  {
    throw new NotImplementedException();
  }
}
