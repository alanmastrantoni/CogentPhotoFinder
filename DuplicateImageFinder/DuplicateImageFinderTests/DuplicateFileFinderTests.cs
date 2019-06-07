using DuplicateImageFinder.Core.Dto;
using DuplicateImageFinder.Core.Interfaces;
using DuplicateImageFinder.Core.Repository;
using DuplicateImageFinder.Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace DuplicateImageFinderTests
{
    [TestClass]
    public class DuplicateFileFinderTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DuplicateFileFinderWithEmptyStringFileRepositoryError()
        {
            IDuplicateFileFinder duplicateFileFinder = new DuplicateFileFinder(null);
            duplicateFileFinder.FindDuplicates(string.Empty);
        }

        [TestMethod]
        public void DuplicateFileFinderWithNoDuplicatesReturnsSuccess()
        {
            Mock<IFileHashProvider> fileHashMock = new Mock<IFileHashProvider>();
            var fileList = new List<FileInfoWithHash>();
            fileList.Add(new FileInfoWithHash("test1", "test1" ));
            fileList.Add(new FileInfoWithHash("test2", "test2"));
            Mock<IFileRepository> fileRepositoryMock = new Mock<IFileRepository>();
            fileRepositoryMock.Setup(m => m.GetFiles(It.IsAny<string>()))
                .Returns(fileList);

            IDuplicateFileFinder duplicateFileFinder = new DuplicateFileFinder(fileRepositoryMock.Object);
            var duplicates = duplicateFileFinder.FindDuplicates(@".\");
            Assert.IsTrue(duplicates.Count == 0);
        }

        [TestMethod]
        public void DuplicateFileFinderWithDuplicatesReturnsSuccess()
        {
            Mock<IFileHashProvider> fileHashMock = new Mock<IFileHashProvider>();
            var fileList = new List<FileInfoWithHash>();
            fileList.Add(new FileInfoWithHash("test1", "test1"));
            fileList.Add(new FileInfoWithHash("test1", "test1"));
            fileList.Add(new FileInfoWithHash("test2", "test2"));
            Mock<IFileRepository> fileRepositoryMock = new Mock<IFileRepository>();
            fileRepositoryMock.Setup(m => m.GetFiles(It.IsAny<string>()))
                .Returns(fileList);

            IDuplicateFileFinder duplicateFileFinder = new DuplicateFileFinder(fileRepositoryMock.Object);
            var duplicates = duplicateFileFinder.FindDuplicates(@".\");
            Assert.IsTrue(duplicates.Count == 2);
            foreach (var file in duplicates)
                Assert.IsTrue(file.FullFileName == "test1");
        }
        [TestMethod]
        public void DuplicateFileFinderWithTriplicatesReturnsSuccess()
        {
            Mock<IFileHashProvider> fileHashMock = new Mock<IFileHashProvider>();
            var fileList = new List<FileInfoWithHash>();
            fileList.Add(new FileInfoWithHash("test1", "test1"));
            fileList.Add(new FileInfoWithHash("test1", "test1"));
            fileList.Add(new FileInfoWithHash("test2", "test2"));
            fileList.Add(new FileInfoWithHash("test1", "test1"));
            Mock<IFileRepository> fileRepositoryMock = new Mock<IFileRepository>();
            fileRepositoryMock.Setup(m => m.GetFiles(It.IsAny<string>()))
                .Returns(fileList);
            IDuplicateFileFinder duplicateFileFinder = new DuplicateFileFinder(fileRepositoryMock.Object);
            var duplicates = duplicateFileFinder.FindDuplicates(@".\");
            Assert.IsTrue(duplicates.Count == 3);
        }

        [TestMethod]
        public void DuplicateFileFinderWithMultipleDuplicatesReturnsSuccess()
        {
            Mock<IFileHashProvider> fileHashMock = new Mock<IFileHashProvider>();
            var fileList = new List<FileInfoWithHash>();
            fileList.Add(new FileInfoWithHash("test1", "test1"));
            fileList.Add(new FileInfoWithHash("test1", "test1"));
            fileList.Add(new FileInfoWithHash("test2", "test2"));
            fileList.Add(new FileInfoWithHash("test3", "test3"));
            fileList.Add(new FileInfoWithHash("test1", "test1"));
            fileList.Add(new FileInfoWithHash("test3", "test3"));
            Mock<IFileRepository> fileRepositoryMock = new Mock<IFileRepository>();
            fileRepositoryMock.Setup(m => m.GetFiles(It.IsAny<string>()))
                .Returns(fileList);
            IDuplicateFileFinder duplicateFileFinder = new DuplicateFileFinder(fileRepositoryMock.Object);
            var duplicates = duplicateFileFinder.FindDuplicates(@".\");
            Assert.IsTrue(duplicates.Count == 5);
        }
    }
}
