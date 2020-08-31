# Telegram.Bots
> A .NET Core wrapper for the Telegram Bot API.

### Overview

- Fully supports Bot API 4.9.

### Getting Started

#### Configuring the Bot Client
```c#
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bots;

...

IServiceCollection services = new ServiceCollection();

services.AddBotClient("<bot-token>");

IServiceProvider provider = services.BuildServiceProvider();

IBotClient bot = provider.GetRequiredService<IBotClient>();
```

#### Sending a "Hello, World!" Text

```c#
using Telegram.Bots.Requests;
using Telegram.Bots.Types;

...

Response<TextMessage> response = await bot.HandleAsync(new SendText(
  chatId: 1234567890,
  text: "Hello, World!"
));

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

### License

Telegram.Bots is a .NET Core wrapper for the Telegram Bot API.  
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
