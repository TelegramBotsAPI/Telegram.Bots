// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System.Collections.Generic;

namespace Telegram.Bots.Types.Passport
{
  public abstract class ElementError
  {
    public abstract ElementSource Source { get; }

    public ElementType Type { get; set; }

    public string Message { get; set; } = null!;
  }

  public abstract class DocumentError : ElementError
  {
    public string Hash { get; set; } = null!;
  }

  public abstract class DocumentsError : ElementError
  {
    public IEnumerable<string> Hashes { get; set; } = null!;
  }

  public sealed class DataFieldError : ElementError
  {
    public override ElementSource Source { get; } = ElementSource.Data;

    public string Name { get; set; } = null!;

    public string Hash { get; set; } = null!;
  }

  public sealed class FrontSideError : DocumentError
  {
    public override ElementSource Source { get; } = ElementSource.FrontSide;
  }

  public sealed class ReverseSideError : DocumentError
  {
    public override ElementSource Source { get; } = ElementSource.ReverseSide;
  }

  public sealed class SelfieError : DocumentError
  {
    public override ElementSource Source { get; } = ElementSource.Selfie;
  }

  public sealed class FileError : DocumentError
  {
    public override ElementSource Source { get; } = ElementSource.File;
  }

  public sealed class FilesError : DocumentsError
  {
    public override ElementSource Source { get; } = ElementSource.Files;
  }

  public sealed class TranslationFileError : DocumentError
  {
    public override ElementSource Source { get; } = ElementSource.TranslationFile;
  }

  public sealed class TranslationFilesError : DocumentsError
  {
    public override ElementSource Source { get; } = ElementSource.TranslationFiles;
  }

  public sealed class UnspecifiedError : ElementError
  {
    public override ElementSource Source { get; } = ElementSource.Unspecified;

    public string Hash { get; set; } = null!;
  }
}
