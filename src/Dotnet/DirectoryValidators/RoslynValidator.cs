using Robbot.Veracode.Packager.Core;

namespace Robbot.Veracode.Packager.Dotnet.DirectoryValidators;

internal class RoslynValidator : IPathValidator
{
    public string Name => nameof(RoslynValidator);

    public bool IsRequired(DirectoryInfo directoryInfo) =>
        !directoryInfo.Name.Equals("roslyn", StringComparison.OrdinalIgnoreCase);
}