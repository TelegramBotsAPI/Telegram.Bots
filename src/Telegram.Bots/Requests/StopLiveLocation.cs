// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public abstract class StopLiveLocationBase<TResult> : IRequest<TResult>, IInlineMarkupable
  {
    public InlineKeyboardMarkup? ReplyMarkup { get; set; }

    public string Method { get; } = "stopMessageLiveLocation";
  }

  public abstract class StopLiveLocation<TChatId> : StopLiveLocationBase<LocationMessage>,
    IChatMessageTargetable<TChatId>
  {
    public TChatId ChatId { get; }

    public int MessageId { get; }

    protected StopLiveLocation(TChatId chatId, int messageId)
    {
      ChatId = chatId;
      MessageId = messageId;
    }
  }

  public sealed class StopLiveLocation : StopLiveLocation<long>
  {
    public StopLiveLocation(long chatId, int messageId) : base(chatId, messageId) { }
  }

  namespace Usernames
  {
    public sealed class StopLiveLocation : StopLiveLocation<string>
    {
      public StopLiveLocation(string username, int messageId) : base(username, messageId) { }
    }
  }

  namespace Inline
  {
    public sealed class StopLiveLocation : StopLiveLocationBase<bool>, IInlineMessageTargetable
    {
      public string MessageId { get; }

      public StopLiveLocation(string messageId) => MessageId = messageId;
    }
  }
}
