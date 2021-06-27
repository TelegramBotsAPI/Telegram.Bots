// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2021 Aman Agnihotri

using System;
using Telegram.Bots.Json;
using Telegram.Bots.Types;
using Xunit;

namespace Telegram.Bots.Tests.Units.Json
{
  public sealed class ChatMemberTests : IClassFixture<Serializer>
  {
    private readonly Serializer _serializer;

    public ChatMemberTests(Serializer serializer) => _serializer = serializer;

    public static TheoryData<(string, Type)> DeserializationData => new()
    {
      (@"{""status"":""creator""}", typeof(Creator)),
      (@"{""status"":""administrator""}", typeof(Administrator)),
      (@"{""status"":""member""}", typeof(NormalMember)),
      (@"{""status"":""restricted""}", typeof(RestrictedMember)),
      (@"{""status"":""left""}", typeof(LeftMember)),
      (@"{""status"":""kicked""}", typeof(KickedMember))
    };

    [Theory(DisplayName = "ChatMember deserializes correctly")]
    [MemberData(nameof(DeserializationData))]
    public void ChatMemberDeserializesCorrectly((string, Type) tuple)
    {
      var (value, type) = tuple;

      Assert.IsAssignableFrom(type, _serializer.Deserialize<ChatMember>(value));
    }
  }
}
