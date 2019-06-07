using System.Collections.Generic;
using DuplicateImageFinder.Core.Dto;
using DuplicateImageFinder.Core.Interfaces;

namespace DuplicateImageFinder.Core.Services
{
    public class DuplicateFileFinder : IDuplicateFileFinder
    {
        private IFileRepository FileRepository { get; set; }

        public DuplicateFileFinder(IFileRepository fileRepository)
        {
            FileRepository = fileRepository;
        }
        public List<FileInfoWithHash> FindDuplicates(string path)
        {
            throw new System.NotImplementedException();
        }
    }
}
