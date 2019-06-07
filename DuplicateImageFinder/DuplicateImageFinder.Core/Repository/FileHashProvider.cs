using System;
using System.IO;
using System.Security.Cryptography;
using DuplicateImageFinder.Core.Interfaces;


namespace DuplicateImageFinder.Core.Repository
{
    public class FileHashProvider : IFileHashProvider
    {
        public string GetFileHash(string fullFileName)
        {
            if (string.IsNullOrEmpty(fullFileName))
                throw new ArgumentException("FileHashPovider: File name must be provided");
            if (!File.Exists(fullFileName))
                throw new FileNotFoundException("FileHashPovider: File must exists");

            using (FileStream fs = new FileStream(fullFileName, FileMode.Open))
            {
                byte[] tmpHash = new MD5CryptoServiceProvider().ComputeHash(fs);
                return ByteArrayToString(tmpHash);
            }
        }
        private string ByteArrayToString(byte[] arrInput)
        {
            return string.Concat(Array.ConvertAll(arrInput, x => x.ToString("X2")));
        }
    }
}
