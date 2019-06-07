
namespace DuplicateImageFinder.Core.Interfaces
{
    public interface IFileHashProvider
    {
        string GetFileHash(string fullFileName);
    }
}
