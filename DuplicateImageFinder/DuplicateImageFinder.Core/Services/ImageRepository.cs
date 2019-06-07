﻿using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using DuplicateImageFinder.Core.Dto;
using DuplicateImageFinder.Core.Interfaces;

namespace DuplicateImageFinder.Core.Services
{
    public class ImageRepository : IFileRepository
    {
        public List<FileInfoWithHash> GetFiles(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentException("Path can not be null of empty");

            if (!Directory.Exists(path))
                throw new DirectoryNotFoundException("Directory provided does not exist");

            var result = new List<FileInfoWithHash>();
            string[] extensions = { ".jpg", ".bmp", ".png", ".gif" };

            foreach (string file in Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories)
                .Where(s => extensions.Any(ext => ext == Path.GetExtension(s))))
            {
                result.Add(new FileInfoWithHash(file, string.Empty));
            }
            return result;
        }
    }
}
