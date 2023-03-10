using Robbot.Veracode.Packager.Core;
using Robbot.Veracode.Packager.Dotnet.DirectoryValidators;
using Robbot.Veracode.Packager.Dotnet.FileValidators;

namespace Robbot.Veracode.Packager.Dotnet
{
    public class PathValidator : IPathValidator
    {
        private readonly IPathValidator[] _directoryValidators =
        {
            new RoslynValidator(),
            new WwwrootValidator(),
            new RuntimesDirectoryValidator(),
            new RuntimeIdentifierValidator(),
            new LanguagePathValidator()
        };

        private readonly IPathValidator[] _fileValidators =
        {
            new ImageFileValidator(),
            new KnownDocumentTypeValidator(),
            new ArchiveFileValidator(),
            new FontFileValidator(),
            new VideoFileValidator(),
            new OtherFileValidator()
        };

        public string Name => nameof(Dotnet.PathValidator);


        public bool IsRequired(DirectoryInfo directoryInfo) => _directoryValidators
            .AsParallel().All(dv =>
            {
                var isRequired = dv.IsRequired(directoryInfo);
                if (!isRequired)
                {
                    Console.WriteLine($"[{dv.Name}] Skipping {directoryInfo.FullName}");
                }

                return isRequired;
            });

        public bool IsRequired(FileInfo fileInfo) => _fileValidators
            .AsParallel().All(dv =>
            {
                var isRequired = dv.IsRequired(fileInfo);
                if (!isRequired)
                {
                    Console.WriteLine($"[{dv.Name}] Skipping {fileInfo.FullName}");
                }

                return isRequired;
            });
    }
}
