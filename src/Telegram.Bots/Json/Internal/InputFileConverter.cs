// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Json.Internal;

using Newtonsoft.Json;
using System;
using Types;

internal sealed class InputFileConverter : JsonConverter<InputFile?>
{
  public override void WriteJson(
    JsonWriter writer,
    InputFile? value,
    JsonSerializer serializer)
  {
    if (value != null)
    {
      writer.WriteValue($"attach://{value.Id}");
    }
  }

  public override InputFile ReadJson(
    JsonReader reader,
    Type objectType,
    InputFile? existingValue,
    bool hasExistingValue,
    JsonSerializer serializer)
  {
    throw new NotImplementedException();
  }
}
