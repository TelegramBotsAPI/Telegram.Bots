// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Tests.Units.Http;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using HttpAction =
  System.Func<System.Net.Http.HttpRequestMessage,
    System.Net.Http.HttpResponseMessage>;

public sealed class MockActionHandler : DelegatingHandler
{
  private readonly HttpAction _action;

  public MockActionHandler(HttpAction action)
  {
    _action = action;
  }

  protected override Task<HttpResponseMessage> SendAsync(
    HttpRequestMessage request,
    CancellationToken cancellationToken)
  {
    return Task.FromResult(_action(request));
  }
}
