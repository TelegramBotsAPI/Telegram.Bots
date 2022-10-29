// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Tests.Units.Http;

using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public sealed class MockResponseHandler : DelegatingHandler
{
  private readonly HttpStatusCode _statusCode;
  private readonly string _content;

  public MockResponseHandler(HttpStatusCode statusCode, string content)
  {
    _statusCode = statusCode;
    _content = content;
  }

  protected override Task<HttpResponseMessage> SendAsync(
    HttpRequestMessage request,
    CancellationToken cancellationToken)
  {
    return Task.FromResult(new HttpResponseMessage(_statusCode)
    {
      Content = new StringContent(_content, Encoding.UTF8, "application/json")
    });
  }
}
