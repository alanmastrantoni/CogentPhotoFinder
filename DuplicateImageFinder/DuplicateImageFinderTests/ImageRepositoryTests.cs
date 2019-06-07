using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace DuplicateImageFinderTests
{
    [TestClass]
    public class ImageRepositoryTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ImageRepositoryWithEmptyPathReturnsError()
        {
            IFileRepository fileRepository = new ImageRepository();
            fileRepository.GetFiles(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(DirectoryNotFoundException))]
        public void ImageRepositoryWithInvalidPathReturnsError()
        {
            IFileRepository fileRepository = new ImageRepository();
            fileRepository.GetFiles("ass@fff");
        }

        [TestMethod]
        [ExpectedException(typeof(DirectoryNotFoundException))]
        public void ImageRepositoryWithValidPathReturnsImages()
        {
            IFileRepository fileRepository = new ImageRepository();
            var images = fileRepository.GetFiles(@".\Code Test");
            Assert.IsTrue(images.Count == 52);
        }
    }
}
