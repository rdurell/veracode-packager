using System.Collections.Concurrent;
using System.CommandLine;
using System.IO.Compression;
using Robbot.Veracode.Packager.Core;

namespace Robbot.Veracode.Packager
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            var root = new RootCommand();

            var packCommand = new Command("pack", "Creates an archive including the required files for Veracode scanning");
            var outputOption = new Option<FileInfo>(new[] { "--output", "-o" },
                
                getDefaultValue: () => new FileInfo($"{DateTime.Now:yyyyMMddHHmmss}-veracode-package.zip"))
            {
                Description = "The output file path",
                IsRequired = false,
                AllowMultipleArgumentsPerToken = false,
                Arity = ArgumentArity.ZeroOrOne
            };

            var platformOption = new Option<Platform>(new[] { "--platform", "-p" })
            {
                Description = "The targeted application platform",
                IsRequired = false,
                AllowMultipleArgumentsPerToken = false,
                Arity = ArgumentArity.ZeroOrOne
            };

            var targetArgument = new Argument<DirectoryInfo>("target")
            {
                Description = "The directory containing the application",
            };

            packCommand.Add(outputOption);
            packCommand.Add(platformOption);
            packCommand.Add(targetArgument);

            packCommand.SetHandler(HandlePackCommandAsync, outputOption, platformOption, targetArgument);

            root.Add(packCommand);

            return await root.InvokeAsync(args);
        }

        private static Task<int> HandlePackCommandAsync(FileInfo outputFile, Platform platform, DirectoryInfo targetDirectory)
        {
            if (!targetDirectory.Exists)
            {
                throw new DirectoryNotFoundException();
            }

            IPathValidator pathValidator = platform switch
            {
                Platform.Dotnet => new Dotnet.PathValidator(),
                Platform.DotnetFramework => throw new NotImplementedException(),
                _ => throw new ArgumentOutOfRangeException(nameof(platform), platform, null)
            };

            var filesToPack = new List<FileInfo>(1000);
            var directories = new ConcurrentStack<DirectoryInfo>();
            directories.Push(targetDirectory);
            while (directories.TryPop(out var current))
            {
                var subDirectories = current.GetDirectories();
                directories.PushRange(subDirectories.AsParallel().Where(di => pathValidator.IsRequired(di)).ToArray());
                filesToPack.AddRange(current.GetFiles().AsParallel().Where(fi => pathValidator.IsRequired(fi)));
            }

            if (outputFile.Exists)
            {
                outputFile.Delete();
            }

            using var zip = ZipFile.Open(outputFile.FullName, ZipArchiveMode.Create);
            foreach (var file in filesToPack)
            {
                zip.CreateEntryFromFile(file.FullName, file.FullName[targetDirectory.FullName.Length..]);
            }

            return Task.FromResult(0);
        }
    }
}