# Telegram.Bots
> A .NET Standard wrapper for the Telegram Bot API.

### Overview

- Fully supports Bot API 5.0.
- Targets .NET Standard 2.1.

### Getting Started

#### Configure the Bot Client
```c#
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bots;

IServiceProvider provider = new ServiceCollection()
  .AddBotClient("<bot-token>")
  .Services
  .BuildServiceProvider();

IBotClient bot = provider.GetRequiredService<IBotClient>();
```

#### Send a Text via Chat Id

```c#
using Telegram.Bots.Requests;
using Telegram.Bots.Types;

var request = new SendText(chatId: 123456789, text: "Hello, World!");

Response<TextMessage> response = await bot.HandleAsync(request);

if (response.Ok)
{
  TextMessage message = response.Result;

  ...
}
else
{
  Failure failure = response.Failure;

  ...
}
```

#### Send a Text via Chat Username

```c#
using Telegram.Bots.Requests.Usernames;
using Telegram.Bots.Types;

var request = new SendText(username: "@chat", text: "Hello, World!");

Response<TextMessage> response = await bot.HandleAsync(request);
```

#### Send an Audio File via Chat Id

```c#
using Telegram.Bots.Requests;
using Telegram.Bots.Types;
using File = System.IO.File;

await using FileStream audioStream = File.OpenRead("/path/to/audio.mp3");

var request = new SendAudioFile(chatId: 123456789, audio: audioStream)
{
  Title = "Title",
  Performer = "Performer",
  Duration = 120
};

Response<AudioMessage> response = await bot.HandleAsync(request);
```

#### Send a Cached Video via Chat Username

```c#
using Telegram.Bots.Requests.Usernames;
using Telegram.Bots.Types;

var request = new SendCachedVideo(username: "@chat", video: "<file-id>")
{
  Caption = "Caption"
};

Response<VideoMessage> response = await bot.HandleAsync(request);
```

#### Send a Media Group via Chat Id

```c#
using Telegram.Bots.Requests;
using Telegram.Bots.Types;
using File = System.IO.File;

await using var audioStream = File.OpenRead("path/to/audio.mp3");
await using var videoStream = File.OpenRead("path/to/video.mp4");

var request = new SendMediaGroup(chatId: 123456789, new List<IGroupableMedia>
{
  new CachedPhoto("<photo-file-id>"),
  new CachedVideo("<video-file-id>"),
  new PhotoUrl(new Uri("https://example.com/image.png")),
  new VideoUrl(new Uri("https://example.com/video.mp4")),
  new PhotoFile(audioStream),
  new VideoFile(videoStream)
})
{
  DisableNotification = true
};

Response<IReadOnlyList<MediaGroupMessage>> response = await bot.HandleAsync(request);
```

#### Download a File

```c#
using Telegram.Bots.Types;
using File = System.IO.File;

await using var stream = File.OpenWrite("path/to/file.extension");

Response<FileInfo> response = await bot.HandleAsync("<file-id>", stream);
```

### License

Telegram.Bots is a .NET Standard wrapper for the Telegram Bot API.  
Copyright © 2020  Aman Agnihotri (amanagnihotri@pm.me)

Telegram.Bots is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published
by the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

Telegram.Bots is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with Telegram.Bots.  If not, see [GNU Licenses](https://www.gnu.org/licenses/).

---
