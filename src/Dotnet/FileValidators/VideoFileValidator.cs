using Robbot.Veracode.Packager.Core.Validators;

namespace Robbot.Veracode.Packager.Dotnet.FileValidators;

internal class VideoFileValidator : FileExtensionsValidator
{
    protected override string[] Extensions { get; } =
    {
        ".mp4", ".webm", ".mkv", ".flv", ".vob", ".ogv", ".drc", ".gifv", ".mng", 
        ".avi", ".mov", ".qt", ".mts", ".wmv", ".amv", ".svi", ".m4v", ".mpg"
    };

    public override string Name => nameof(VideoFileValidator);
}