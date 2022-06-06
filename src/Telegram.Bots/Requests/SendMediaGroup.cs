// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

using System.Collections.Generic;
using System.Linq;
using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  using IGroupableMediaList = IEnumerable<IGroupableMedia>;

  public abstract record SendMediaGroup<TChatId> : IRequest<IReadOnlyList<MediaGroupMessage>>,
    IChatTargetable<TChatId>, INotifiable, IProtectable, IReplyable, IUploadable
  {
    public TChatId ChatId { get; }

    public IGroupableMediaList Media { get; }

    public bool? DisableNotification { get; init; }
    
    public bool? ProtectContent { get; init; }

    public int? ReplyToMessageId { get; init; }

    public bool? AllowSendingWithoutReply { get; init; }

    public string Method { get; } = "sendMediaGroup";

    protected SendMediaGroup(TChatId chatId, IEnumerable<IGroupableMedia> media)
    {
      ChatId = chatId;
      Media = media;
    }

    public IEnumerable<InputFile?> GetFiles() =>
      Media.OfType<IUploadableMedia>().SelectMany(media => media.GetFiles());
  }

  public sealed record SendMediaGroup : SendMediaGroup<long>
  {
    public SendMediaGroup(long chatId, IGroupableMediaList media) : base(chatId, media) { }
  }

  namespace Usernames
  {
    public sealed record SendMediaGroup : SendMediaGroup<string>
    {
      public SendMediaGroup(string username, IGroupableMediaList media) : base(username, media) { }
    }
  }
}
