// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Tests.Units.Json;

using Bots.Json;
using Bots.Types;
using Xunit;

public sealed class TextButtonTests : IClassFixture<Serializer>
{
  private readonly Serializer _serializer;

  public TextButtonTests(Serializer serializer)
  {
    _serializer = serializer;
  }

  [Fact(DisplayName = "Serialization uses Text property")]
  public void SerializationUsesTextProperty()
  {
    Assert.Equal(@"""Test""", _serializer.Serialize(new TextButton("Test")));
  }
}
