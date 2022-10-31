// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Tests.Units.Json;

using Bots.Json;
using Bots.Types;
using System;
using Xunit;

public sealed class UpdateTests : IClassFixture<Serializer>
{
  private readonly Serializer _serializer;

  public UpdateTests(Serializer serializer)
  {
    _serializer = serializer;
  }

  public static TheoryData<(string, Type)> DeserializationData => new()
  {
    (@"{""update_id"":1,""message"":{}}", typeof(Update)),
    (@"{""message"":{}}", typeof(MessageUpdate)),
    (@"{""edited_message"":{}}", typeof(EditedMessageUpdate)),
    (@"{""channel_post"":{}}", typeof(ChannelPostUpdate)),
    (@"{""edited_channel_post"":{}}", typeof(EditedChannelPostUpdate)),
    (@"{""inline_query"":{}}", typeof(InlineQueryUpdate)),
    (@"{""chosen_inline_result"":{}}", typeof(ChosenInlineResultUpdate)),
    (@"{""callback_query"":{}}", typeof(CallbackQueryUpdate)),
    (@"{""shipping_query"":{}}", typeof(ShippingQueryUpdate)),
    (@"{""pre_checkout_query"":{}}", typeof(PreCheckoutQueryUpdate)),
    (@"{""poll"":{""type"":""regular""}}", typeof(PollUpdate)),
    (@"{""poll_answer"":{}}", typeof(PollAnswerUpdate)),
    (@"{""my_chat_member"":{}}", typeof(MyChatMemberUpdate)),
    (@"{""chat_member"":{}}", typeof(ChatMemberUpdate)),
    (@"{""chat_join_request"":{}}", typeof(ChatJoinRequestUpdate))
  };

  [Theory(DisplayName = "Update deserializes correctly")]
  [MemberData(nameof(DeserializationData))]
  public void UpdateDeserializesCorrectly((string, Type) tuple)
  {
    (string value, Type type) = tuple;

    Assert.IsAssignableFrom(type, _serializer.Deserialize<Update>(value));
  }
}
