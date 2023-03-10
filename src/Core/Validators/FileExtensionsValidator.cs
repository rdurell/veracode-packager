namespace Robbot.Veracode.Packager.Core.Validators
{
    public abstract class FileExtensionsValidator : IPathValidator
    {
        public abstract string Name { get; }

        protected abstract string[] Extensions { get; }

        public bool IsRequired(FileInfo fileInfo) =>
            Extensions.AsParallel()
                .All(ext => !ext.Equals(fileInfo.Extension, StringComparison.OrdinalIgnoreCase));
    }
}
