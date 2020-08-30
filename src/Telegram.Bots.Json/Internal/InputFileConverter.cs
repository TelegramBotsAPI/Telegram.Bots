// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System;
using Newtonsoft.Json;
using Telegram.Bots.Types;

namespace Telegram.Bots.Json.Internal
{
  internal class InputFileConverter : JsonConverter<InputFile?>
  {
    public override void WriteJson(JsonWriter writer, InputFile? value, JsonSerializer serializer)
    {
      if (value != null) writer.WriteValue($"attach://{value.Id}");
    }

    public override InputFile ReadJson(
      JsonReader reader,
      Type objectType,
      InputFile? existingValue,
      bool hasExistingValue,
      JsonSerializer serializer) => throw new NotImplementedException();
  }
}
