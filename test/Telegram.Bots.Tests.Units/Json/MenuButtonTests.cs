// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2022 Aman Agnihotri

using System;
using Telegram.Bots.Json;
using Telegram.Bots.Types;
using Xunit;

namespace Telegram.Bots.Tests.Units.Json
{
  public sealed class MenuButtonTests : IClassFixture<Serializer>
  {
    private readonly Serializer _serializer;

    public MenuButtonTests(Serializer serializer) => _serializer = serializer;

    private static readonly Uri Uri = new("https://example.com");

    public static readonly TheoryData<(string, MenuButton)> SerializationData = new()
    {
      (@"{""type"":""default""}", new DefaultMenuButton()),
      (@"{""type"":""commands""}", new CommandsMenuButton()),
      (@"{""type"":""web_app"",""text"":""test"",""web_app"":{""url"":""https://example.com""}}",
        new WebAppMenuButton("test", new WebAppInfo(Uri)))
    };

    public static TheoryData<(string, Type)> DeserializationData => new()
    {
      (@"{""type"":""default""}", typeof(DefaultMenuButton)),
      (@"{""type"":""commands""}", typeof(CommandsMenuButton)),
      (@"{""type"":""web_app""}", typeof(WebAppMenuButton))
    };

    [Theory(DisplayName = "MenuButton serializes correctly")]
    [MemberData(nameof(SerializationData))]
    public void MenuButtonSerializesCorrectly((string, MenuButton) tuple)
    {
      var (value, button) = tuple;

      Assert.Equal(value, _serializer.Serialize(button));
    }

    [Theory(DisplayName = "MenuButton deserializes correctly")]
    [MemberData(nameof(DeserializationData))]
    public void MenuButtonDeserializesCorrectly((string, Type) tuple)
    {
      var (value, type) = tuple;

      Assert.IsAssignableFrom(type, _serializer.Deserialize<MenuButton>(value));
    }
  }
}
