using System;
using System.IO;

namespace Telegram.Bots.Types
{
  public sealed class InputFile
  {
    public string Id { get; } = Guid.NewGuid().ToString();

    public Stream Data { get; }

    public InputFile(Stream data) => Data = data;
  }
}
