using Robbot.Veracode.Packager.Core;

namespace Robbot.Veracode.Packager.Dotnet.DirectoryValidators;

internal class RuntimeIdentifierValidator : IPathValidator
{
    private readonly string[] _ridDirectories = { "win-x64", "win-x86" };

    public string Name => nameof(RuntimeIdentifierValidator);

    public bool IsRequired(DirectoryInfo directoryInfo) => _ridDirectories.All(rid =>
        !rid.Equals(directoryInfo.Name, StringComparison.OrdinalIgnoreCase));
}