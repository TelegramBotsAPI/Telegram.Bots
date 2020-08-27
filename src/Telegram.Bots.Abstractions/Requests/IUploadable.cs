using System.Collections.Generic;
using System.Linq;
using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public interface IUploadable
  {
    IEnumerable<InputFile?> GetFiles();

    bool HasFiles() => GetFiles().Any(file => file != null);
  }
}
