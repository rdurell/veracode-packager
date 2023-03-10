using System.Globalization;
using Robbot.Veracode.Packager.Core;

namespace Robbot.Veracode.Packager.Dotnet.DirectoryValidators;

internal class LanguagePathValidator : IPathValidator
{
    private readonly string[] _languagePaths = CultureInfo
        .GetCultures(CultureTypes.AllCultures)
        .SelectMany(c => new[] { c.Name, c.TwoLetterISOLanguageName })
        .Except(new[] { "en" })
        .ToArray();

    public string Name => nameof(LanguagePathValidator);

    public bool IsRequired(DirectoryInfo directoryInfo) =>
        _languagePaths.AsParallel().All(l => !l.Equals(directoryInfo.Name, StringComparison.Ordinal));
}