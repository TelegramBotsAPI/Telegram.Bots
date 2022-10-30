// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Tests.Units.Json;

using Bots.Json;
using Bots.Types;
using System;
using Xunit;

public sealed class CallbackQueryTests : IClassFixture<Serializer>
{
  private readonly Serializer _serializer;

  public CallbackQueryTests(Serializer serializer)
  {
    _serializer = serializer;
  }

  public static TheoryData<(string, Type)> DeserializationData => new()
  {
    (@"{""message"":{""text"":""""},""game_short_name"":""""}",
      typeof(GameCallbackQuery)),
    (@"{""message"":{""text"":""""},""data"":""""}",
      typeof(MessageCallbackQuery)),
    (@"{""inline_message_id"":"""",""game_short_name"":""""}",
      typeof(InlineGameCallbackQuery)),
    (@"{""inline_message_id"":"""",""data"":""""}",
      typeof(InlineMessageCallbackQuery))
  };

  [Theory(DisplayName = "CallbackQuery deserializes correctly")]
  [MemberData(nameof(DeserializationData))]
  public void CallbackQueryDeserializesCorrectly((string, Type) tuple)
  {
    (string value, Type type) = tuple;

    CallbackQuery query = _serializer.Deserialize<CallbackQuery>(value);

    Assert.IsAssignableFrom(type, query);
  }
}
