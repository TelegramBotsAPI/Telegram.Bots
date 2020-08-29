using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Telegram.Bots.Http.Tests.Units
{
  using HttpAction = Func<HttpRequestMessage, HttpResponseMessage>;

  public sealed class MockActionHandler : DelegatingHandler
  {
    private readonly HttpAction _action;

    public MockActionHandler(HttpAction action) => _action = action;

    protected override Task<HttpResponseMessage> SendAsync(
      HttpRequestMessage request,
      CancellationToken cancellationToken) => Task.FromResult(_action(request));
  }
}
