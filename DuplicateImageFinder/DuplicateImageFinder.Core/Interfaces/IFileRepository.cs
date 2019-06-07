using DuplicateImageFinder.Core.Dto;
using System.Collections.Generic;

namespace DuplicateImageFinder.Core.Interfaces
{
    public interface IFileRepository
    {
        List<FileInfoWithHash> GetFiles(string path);
    }
}
