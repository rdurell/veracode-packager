using Robbot.Veracode.Packager.Core.Validators;

namespace Robbot.Veracode.Packager.Dotnet.FileValidators;

internal class KnownDocumentTypeValidator : FileExtensionsValidator
{
    protected override string[] Extensions { get; } =
    {
        ".pdf", ".md", ".doc", ".dot", ".wbk", ".docx", ".docm", ".dotx", ".dotm", ".docb", ".wll", ".wwl",
        ".xls", ".xlt", ".xlm", ".xll_", ".xla_", ".xla5", ".xla8", ".xlsx", ".xlsm", ".xltx", ".xltm",
        ".ppt", ".pot", ".pps", ".pptx", ".pptm", ".potx", ".potm", ".one", ".ecf", ".ACCDA", ".ACCDB",
        ".ACCDE", ".ACCDT", ".MDA", ".MDE", ".xml"
    };

    public override string Name => nameof(KnownDocumentTypeValidator);
}