using System.Collections.Generic;
using DuplicateImageFinder.Core.Dto;
using DuplicateImageFinder.Core.Interfaces;

namespace DuplicateImageFinder.Core.Services
{
    public class ImageRepository : IFileRepository
    {
        public List<FileInfoWithHash> GetFiles(string path)
        {
            throw new System.NotImplementedException();
        }
    }
}
