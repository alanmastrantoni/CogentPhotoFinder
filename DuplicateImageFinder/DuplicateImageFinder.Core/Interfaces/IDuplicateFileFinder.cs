using DuplicateImageFinder.Core.Dto;
using System.Collections.Generic;

namespace DuplicateImageFinder.Core.Interfaces
{
    public interface IDuplicateFileFinder
    {
        List<FileInfoWithHash> FindDuplicates(string path);
    }
}
