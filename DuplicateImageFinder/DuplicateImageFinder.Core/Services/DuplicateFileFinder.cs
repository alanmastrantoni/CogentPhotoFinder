using System.Linq;
using System.Collections.Generic;
using DuplicateImageFinder.Core.Dto;
using DuplicateImageFinder.Core.Interfaces;
using System;

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
            if (string.IsNullOrEmpty(path))
                throw new ArgumentException("Duplicate File Finder: A valid path was be provided");

            var files = FileRepository.GetFiles(path);

            var duplicates = files.GroupBy(s => s.ContentHash)
                             .Where(g => g.Count() > 1)
                             .SelectMany(g => g);

            return duplicates.ToList();
        }
    }
}
