using Robbot.Veracode.Packager.Core.Validators;

namespace Robbot.Veracode.Packager.Dotnet.FileValidators;

internal class ArchiveFileValidator : FileExtensionsValidator
{
    protected override string[] Extensions { get; } = { ".zip", ".tar", ".gz", ".7z", ".iso", ".rar", ".img" };

    public override string Name => nameof(ArchiveFileValidator);
}