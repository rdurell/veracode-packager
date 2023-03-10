using Robbot.Veracode.Packager.Core.Validators;

namespace Robbot.Veracode.Packager.Dotnet.FileValidators;

internal class ImageFileValidator : FileExtensionsValidator
{
    protected override string[] Extensions { get; } =
    {
        ".jpg", ".png", ".jpeg", ".gif", ".svg", ".bmp", ".ico", ".icns"
    };

    public override string Name => nameof(ImageFileValidator);
}