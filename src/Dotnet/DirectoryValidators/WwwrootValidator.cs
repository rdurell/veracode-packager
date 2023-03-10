using Robbot.Veracode.Packager.Core;

namespace Robbot.Veracode.Packager.Dotnet.DirectoryValidators;

internal class WwwrootValidator : IPathValidator
{
    public string Name => nameof(WwwrootValidator);

    public bool IsRequired(DirectoryInfo directoryInfo) =>
        !directoryInfo.Name.Equals("wwwroot", StringComparison.OrdinalIgnoreCase);
}