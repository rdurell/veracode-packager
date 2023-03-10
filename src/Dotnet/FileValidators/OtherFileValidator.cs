using Robbot.Veracode.Packager.Core.Validators;

namespace Robbot.Veracode.Packager.Dotnet.FileValidators;

internal class OtherFileValidator : FileExtensionsValidator
{
    protected override string[] Extensions { get; } = { ".bin" };

    public override string Name => nameof(OtherFileValidator);
}