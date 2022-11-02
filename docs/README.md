# Telegram.Bots
> A .NET 6 wrapper for the Telegram Bot API 6.1.

![Status][1] [![Nuget][2]][5] [![Downloads][3]][5] ![License][4]

### Usage

#### Configure the Bot Client
```c#
using System;
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bots;

IServiceProvider provider = new ServiceCollection()
  .AddBotClient("<bot-token>")
  .Services
  .BuildServiceProvider();

IBotClient bot = provider.GetRequiredService<IBotClient>();
```

#### Or Configure the Bot Client with a Web Proxy
```c#
using System;
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bots;

IServiceProvider provider = new ServiceCollection()
  .AddBotClient("<bot-token>")
  .ConfigurePrimaryHttpMessageHandler(() => new SocketsHttpHandler
  {
    Proxy = new WebProxy(Host: "<your-host>", Port: 1234),
    UseProxy = true
  })
  .Services
  .BuildServiceProvider();

IBotClient bot = provider.GetRequiredService<IBotClient>();
```

#### Get Bot Information

```cs
using Telegram.Bots.Requests;
using Telegram.Bots.Types;

// ...

GetMe request = new();

Response<MyBot> response = await bot.HandleAsync(request);

if (response.Ok)
{
  MyBot myBot = response.Result;

  Console.WriteLine(myBot.Id);
  Console.WriteLine(myBot.FirstName);
  Console.WriteLine(myBot.Username);
}
else
{
  Failure failure = response.Failure;

  Console.WriteLine(failure.Description);
}
```

#### Send a Text via Chat Id

```cs
using Telegram.Bots.Requests;
using Telegram.Bots.Types;

// ...

SendText request = new(chatId: 123456789, text: "Hello!");

Response<TextMessage> response = await bot.HandleAsync(request);

if (response.Ok)
{
  TextMessage message = response.Result;

  Console.WriteLine(message.Id);
  Console.WriteLine(message.Text);
  Console.WriteLine(message.Date.ToString("G"));
}
else
{
  Failure failure = response.Failure;

  Console.WriteLine(failure.Description);
}
```

#### Send a Text via Chat Username

```cs
using Telegram.Bots.Requests.Usernames;
using Telegram.Bots.Types;

// ...

SendText request = new(username: "@chat", text: "Hello!");

Response<TextMessage> response = await bot.HandleAsync(request);

if (response.Ok)
{
  TextMessage message = response.Result;

  // ...
}
else
{
  Failure failure = response.Failure;

  // ...
}

```

#### Send an Audio File via Chat Id

```cs
using Telegram.Bots.Requests;
using Telegram.Bots.Types;

// ...

await using var audioStream = System.IO.File.OpenRead("/path/to/audio.mp3");

SendAudioFile request = new(chatId: 123456789, audio: audioStream);

Response<AudioMessage> response = await bot.HandleAsync(request);

if (response.Ok)
{
  AudioMessage message = response.Result;

  Console.WriteLine(message.Id);
  Console.WriteLine(message.Audio.Id);
  Console.WriteLine(message.Audio.Title);
  Console.WriteLine(message.Audio.Performer);
  Console.WriteLine(message.Audio.Duration);
}
else
{
  Failure failure = response.Failure;

  Console.WriteLine(failure.Description);
}
```

#### Send a Cached Video via Chat Username

```c#
using Telegram.Bots.Requests.Usernames;
using Telegram.Bots.Types;

// ...

SendCachedVideo request = new(username: "@chat", video: "<file-id>")
{
  Caption = "New Caption"
};

Response<VideoMessage> response = await bot.HandleAsync(request);

if (response.Ok)
{
  VideoMessage message = response.Result;

  Console.WriteLine(message.Id);
  Console.WriteLine(message.Video.Id);
  Console.WriteLine(message.Video.Name);
  Console.WriteLine(message.Caption);
}
else
{
  Failure failure = response.Failure;

  Console.WriteLine(failure.Description);
}
```

#### Send a Media Group via Chat Id

```c#
using Telegram.Bots.Requests;
using Telegram.Bots.Types;

await using var photoStream = System.IO.File.OpenRead("path/to/photo.png");
await using var videoStream = System.IO.File.OpenRead("path/to/video.mp4");

var request = new SendMediaGroup(chatId: 123456789, new List<IGroupableMedia>
{
  new CachedPhoto("<photo-file-id>"),
  new CachedVideo("<video-file-id>"),
  new PhotoUrl(new Uri("https://example.com/photo.png")),
  new VideoUrl(new Uri("https://example.com/video.mp4")),
  new PhotoFile(photoStream),
  new VideoFile(videoStream)
})
{
  DisableNotification = true
};

Response<IReadOnlyList<MediaGroupMessage>> response = await bot.HandleAsync(request);

if (response.Ok)
{
  foreach (var mediaGroupMessage in response.Result)
  {
    switch (mediaGroupMessage)
    {
      case PhotoMessage message:
        Console.WriteLine(message.PhotoSet.Count);
        break;
      case VideoMessage message:
        Console.WriteLine(message.Video.Name);
        break;
    }
  }
}
else
{
  Failure failure = response.Failure;

  Console.WriteLine(failure.Description);
}
```

#### Download a File

```c#
using Telegram.Bots.Types;

await using var stream = System.IO.File.OpenWrite("path/to/file.extension");

Response<FileInfo> response = await bot.HandleAsync("<file-id>", stream);
```

#### Configuring the Serializer with ASP.NET Core

```c#
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bots.Extensions.AspNetCore;

// ...

IServiceCollection services = ...

services.AddControllers()
        .AddBotSerializer();
```

#### Configuring Long Polling with Telegram.Bots

```cs
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bots;
using Telegram.Bots.Extensions.Polling;

...

IServiceCollection services = ...

services.AddBotClient("<bot-token>");
services.AddPolling<UpdateHandler>();
```

#### Configuring an Update Handler for Polled Updates

```cs
using Telegram.Bots.Extensions.Polling;
using Telegram.Bots.Requests;
using Telegram.Bots.Types;

...

public sealed class UpdateHandler : IUpdateHandler
{
  public Task HandleAsync(IBotClient bot, Update update, CancellationToken token)
  {
    return update switch
    {
      MessageUpdate u when u.Data is TextMessage message =>
        bot.HandleAsync(new SendText(message.Chat.Id, message.Text), token),

      EditedMessageUpdate u when u.Data is TextMessage message =>
        bot.HandleAsync(new SendText(message.Chat.Id, message.Text)
        {
          ReplyToMessageId = message.Id
        }, token),

      _ => Task.CompletedTask
    };
  }
}
```

### License

Telegram.Bots is a .NET 6 wrapper for the Telegram Bot API 6.1.  
Copyright © 2020-2022  Aman Agnihotri (amanagnihotri@pm.me)  

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

[1]: https://img.shields.io/github/workflow/status/TelegramBotsAPI/Telegram.Bots/.NET%205?style=for-the-badge
[2]: https://img.shields.io/nuget/v/Telegram.Bots?style=for-the-badge
[3]: https://img.shields.io/nuget/dt/Telegram.Bots?style=for-the-badge
[4]: https://img.shields.io/github/license/TelegramBotsAPI/Telegram.Bots?style=for-the-badge
[5]: https://www.nuget.org/packages/Telegram.Bots/
