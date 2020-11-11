// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System.Collections.Generic;

namespace Telegram.Bots.Types.Passport
{
  public abstract record ElementError
  {
    public abstract ElementSource Source { get; }

    public ElementType Type { get; init; }

    public string Message { get; init; } = null!;
  }

  public abstract record DocumentError : ElementError
  {
    public string Hash { get; init; } = null!;
  }

  public abstract record DocumentsError : ElementError
  {
    public IEnumerable<string> Hashes { get; init; } = null!;
  }

  public sealed record DataFieldError : ElementError
  {
    public override ElementSource Source { get; } = ElementSource.Data;

    public string Name { get; init; } = null!;

    public string Hash { get; init; } = null!;
  }

  public sealed record FrontSideError : DocumentError
  {
    public override ElementSource Source { get; } = ElementSource.FrontSide;
  }

  public sealed record ReverseSideError : DocumentError
  {
    public override ElementSource Source { get; } = ElementSource.ReverseSide;
  }

  public sealed record SelfieError : DocumentError
  {
    public override ElementSource Source { get; } = ElementSource.Selfie;
  }

  public sealed record FileError : DocumentError
  {
    public override ElementSource Source { get; } = ElementSource.File;
  }

  public sealed record FilesError : DocumentsError
  {
    public override ElementSource Source { get; } = ElementSource.Files;
  }

  public sealed record TranslationFileError : DocumentError
  {
    public override ElementSource Source { get; } = ElementSource.TranslationFile;
  }

  public sealed record TranslationFilesError : DocumentsError
  {
    public override ElementSource Source { get; } = ElementSource.TranslationFiles;
  }

  public sealed record UnspecifiedError : ElementError
  {
    public override ElementSource Source { get; } = ElementSource.Unspecified;

    public string Hash { get; init; } = null!;
  }
}
