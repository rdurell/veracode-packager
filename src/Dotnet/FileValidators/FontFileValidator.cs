using Robbot.Veracode.Packager.Core.Validators;

namespace Robbot.Veracode.Packager.Dotnet.FileValidators;

internal class FontFileValidator : FileExtensionsValidator
{
    protected override string[] Extensions { get; } = { ".ttf", ".otf", ".woff", ".woff2" };

    public override string Name => nameof(FontFileValidator);
}