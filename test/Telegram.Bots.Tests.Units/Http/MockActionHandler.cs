// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2021 Aman Agnihotri

using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Telegram.Bots.Tests.Units.Http
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
