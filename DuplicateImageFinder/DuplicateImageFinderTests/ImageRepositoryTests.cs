using DuplicateImageFinder.Core.Interfaces;
using DuplicateImageFinder.Core.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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
            Mock<IFileHashProvider> fileHashMock = new Mock<IFileHashProvider>();
            IFileRepository fileRepository = new ImageRepository(fileHashMock.Object);
            fileRepository.GetFiles(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(DirectoryNotFoundException))]
        public void ImageRepositoryWithInvalidPathReturnsError()
        {
            Mock<IFileHashProvider> fileHashMock = new Mock<IFileHashProvider>();
            IFileRepository fileRepository = new ImageRepository(fileHashMock.Object);
            fileRepository.GetFiles("ass@fff");
        }

        [TestMethod]
        public void ImageRepositoryWithValidPathReturnsImages()
        {
            Mock<IFileHashProvider> fileHashMock = new Mock<IFileHashProvider>();
            fileHashMock.Setup(m => m.GetFileHash(It.IsAny<string>()))
                .Returns("123");
            
            IFileRepository fileRepository = new ImageRepository(fileHashMock.Object);
            var images = fileRepository.GetFiles(@"..\..\..\Code Test");
            Assert.IsTrue(images.Count == 52);
        }
    }
}
