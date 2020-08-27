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
