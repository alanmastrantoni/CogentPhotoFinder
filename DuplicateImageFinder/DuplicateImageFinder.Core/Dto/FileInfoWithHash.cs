namespace DuplicateImageFinder.Core.Dto
{
    public class FileInfoWithHash
    {
        public string FullFileName {get; private set;}
        public string ContentHash { get; private set; }

        public FileInfoWithHash(string fullFileName, string contentHash)
        {
            FullFileName = fullFileName;
            ContentHash = contentHash;
        }
    }
}
