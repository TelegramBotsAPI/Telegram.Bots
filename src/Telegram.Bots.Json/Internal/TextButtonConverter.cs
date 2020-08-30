// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System;
using Newtonsoft.Json;
using Telegram.Bots.Types;

namespace Telegram.Bots.Json.Internal
{
  internal sealed class TextButtonConverter : JsonConverter<TextButton>
  {
    public override bool CanRead => false;

    public override void WriteJson(JsonWriter writer, TextButton? value, JsonSerializer serializer)
    {
      if (value != null) writer.WriteValue(value.Text);
    }

    public override TextButton ReadJson(
      JsonReader reader,
      Type objectType,
      TextButton? existingValue,
      bool hasExistingValue,
      JsonSerializer serializer) => throw new NotImplementedException();
  }
}
