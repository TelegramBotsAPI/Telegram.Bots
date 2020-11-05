// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System.Collections.Generic;
using System.Linq;
using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  using IGroupableMediaList = IEnumerable<IGroupableMedia>;

  public abstract class SendMediaGroup<TChatId> : IRequest<IReadOnlyList<MediaGroupMessage>>,
    IChatTargetable<TChatId>, INotifiable, IReplyable, IUploadable
  {
    public TChatId ChatId { get; }

    public IGroupableMediaList Media { get; }

    public bool? DisableNotification { get; set; }

    public int? ReplyToMessageId { get; set; }

    public bool? AllowSendingWithoutReply { get; set; }

    public string Method { get; } = "sendMediaGroup";

    protected SendMediaGroup(TChatId chatId, IEnumerable<IGroupableMedia> media)
    {
      ChatId = chatId;
      Media = media;
    }

    public IEnumerable<InputFile?> GetFiles() =>
      Media.OfType<IUploadableMedia>().SelectMany(media => media.GetFiles());
  }

  public sealed class SendMediaGroup : SendMediaGroup<long>
  {
    public SendMediaGroup(long chatId, IGroupableMediaList media) : base(chatId, media) { }
  }

  namespace Usernames
  {
    public sealed class SendMediaGroup : SendMediaGroup<string>
    {
      public SendMediaGroup(string username, IGroupableMediaList media) : base(username, media) { }
    }
  }
}
