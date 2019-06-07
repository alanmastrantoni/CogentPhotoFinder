using DuplicateImageFinder.Core.Interfaces;
using DuplicateImageFinder.Core.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace DuplicateImageFinderTests
{
    [TestClass]
    public class FileHashProviderTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FileHashWithEmptyPathReturnsError()
        {
            IFileHashProvider hashProvider = new FileHashProvider();
            hashProvider.GetFileHash(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void FileHashWithInvalidPathReturnsError()
        {
            IFileHashProvider hashProvider = new FileHashProvider();
            hashProvider.GetFileHash("zzz");
        }

        [TestMethod]
        public void FileHashWithValidFileReturnsHash()
        {
            IFileHashProvider hashProvider = new FileHashProvider();
            var contentHash = hashProvider.GetFileHash(@"..\..\..\Code Test\mew.jpg");
            Assert.IsNotNull(contentHash);
        }
    }
}
