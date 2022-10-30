// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Tests.Units.Json;

using Bots.Json;
using Bots.Types;
using System;
using System.IO;
using Xunit;

public sealed class InputFileTests : IClassFixture<Serializer>
{
  private static readonly InputFile File = Stream.Null;

  private readonly Serializer _serializer;

  public InputFileTests(Serializer serializer)
  {
    _serializer = serializer;
  }

  [Fact(DisplayName = "Serialization prepends \"attach://\" to Id")]
  public void SerializationPrependsAttachSchemeToId()
  {
    Assert.Equal($@"""attach://{File.Id}""", _serializer.Serialize(File));
  }

  [Fact(DisplayName = "Deserialization throws NotImplementedException")]
  public void DeserializationThrowsNotImplementedException()
  {
    Assert.Throws<NotImplementedException>(() =>
      _serializer.Deserialize<InputFile>(_serializer.Serialize(File)));
  }
}
