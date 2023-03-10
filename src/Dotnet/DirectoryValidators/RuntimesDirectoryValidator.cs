using Robbot.Veracode.Packager.Core;

namespace Robbot.Veracode.Packager.Dotnet.DirectoryValidators;

internal class RuntimesDirectoryValidator : IPathValidator
{
    public string Name => nameof(RuntimesDirectoryValidator);

    public bool IsRequired(DirectoryInfo directoryInfo) =>
        !directoryInfo.Name.Equals("runtimes", StringComparison.OrdinalIgnoreCase);
}