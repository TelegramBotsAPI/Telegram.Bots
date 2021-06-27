// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2021 Aman Agnihotri

using Telegram.Bots.Json;
using Telegram.Bots.Types;
using Xunit;

namespace Telegram.Bots.Tests.Units.Json
{
  public sealed class TextButtonTests : IClassFixture<Serializer>
  {
    private readonly Serializer _serializer;

    public TextButtonTests(Serializer serializer) => _serializer = serializer;

    [Fact(DisplayName = "Serialization uses Text property")]
    public void SerializationUsesTextProperty() =>
      Assert.Equal(@"""Test""", _serializer.Serialize(new TextButton("Test")));
  }
}
