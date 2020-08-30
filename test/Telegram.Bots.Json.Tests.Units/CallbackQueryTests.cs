// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System;
using Telegram.Bots.Types;
using Xunit;

namespace Telegram.Bots.Json.Tests.Units
{
  public sealed class CallbackQueryTests : IClassFixture<Serializer>
  {
    private readonly Serializer _serializer;

    public CallbackQueryTests(Serializer serializer) => _serializer = serializer;

    public static TheoryData<(string, Type)> DeserializationData => new TheoryData<(string, Type)>
    {
      (@"{""message"":{""text"":""""},""game_short_name"":""""}", typeof(GameCallbackQuery)),
      (@"{""message"":{""text"":""""},""data"":""""}", typeof(MessageCallbackQuery)),
      (@"{""inline_message_id"":"""",""game_short_name"":""""}", typeof(InlineGameCallbackQuery)),
      (@"{""inline_message_id"":"""",""data"":""""}", typeof(InlineMessageCallbackQuery))
    };

    [Theory(DisplayName = "CallbackQuery deserializes correctly")]
    [MemberData(nameof(DeserializationData))]
    public void CallbackQueryDeserializesCorrectly((string, Type) tuple)
    {
      var (value, type) = tuple;

      Assert.IsAssignableFrom(type, _serializer.Deserialize<CallbackQuery>(value));
    }
  }
}
