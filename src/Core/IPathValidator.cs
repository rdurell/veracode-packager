namespace Robbot.Veracode.Packager.Core
{
    public interface IPathValidator
    {
        public string Name { get; }

        public bool IsRequired(FileInfo fileInfo) => true;

        public bool IsRequired(DirectoryInfo directoryInfo) => true;
    }
}
