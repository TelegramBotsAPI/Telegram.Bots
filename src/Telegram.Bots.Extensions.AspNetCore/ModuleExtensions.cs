// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2021 Aman Agnihotri

using Microsoft.Extensions.DependencyInjection;
using Telegram.Bots.Json;

namespace Telegram.Bots.Extensions.AspNetCore
{
  public static class ModuleExtensions
  {
    public static IMvcBuilder AddBotSerializer(this IMvcBuilder builder) =>
      builder.AddNewtonsoftJson(options => Serializer.Modify(options.SerializerSettings));
  }
}
