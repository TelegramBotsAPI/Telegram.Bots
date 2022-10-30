// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Tests.Units.Json;

using Bots.Json;
using Bots.Types;
using System;
using Xunit;

public sealed class InlineButtonTests : IClassFixture<Serializer>
{
  private readonly Serializer _serializer;

  public InlineButtonTests(Serializer serializer)
  {
    _serializer = serializer;
  }

  public static TheoryData<(string, Type)> DeserializationData => new()
  {
    (@"{""url"":""https://example.com""}", typeof(UrlButton)),
    (@"{""login_url"":{}}", typeof(LoginUrlButton)),
    (@"{""callback_data"":""""}", typeof(CallbackDataButton)),
    (@"{""switch_inline_query"":""""}", typeof(SwitchInlineQueryButton)),
    (@"{""switch_inline_query_current_chat"":""""}",
      typeof(SwitchInlineQueryCurrentChatButton)),
    (@"{""callback_game"":{}}", typeof(CallbackGameButton)),
    (@"{""pay"":true}", typeof(PayButton))
  };

  [Theory(DisplayName = "InlineButton deserializes correctly")]
  [MemberData(nameof(DeserializationData))]
  public void InlineButtonDeserializesCorrectly((string, Type) tuple)
  {
    (string value, Type type) = tuple;

    Assert.IsAssignableFrom(type, _serializer.Deserialize<InlineButton>(value));
  }
}
