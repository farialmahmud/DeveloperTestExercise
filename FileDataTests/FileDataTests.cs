using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThirdPartyTools;
using Moq;

namespace FileDataTests
{
    [TestClass]
    public class FileDataTests
    {
        //Stub class of FileDetails to use with Moq to verify expected random number from the ThirdPartyTools given any filepath as string
        public class StubFileDetails: FileDetails
        {
            private readonly Random _random = new Random();
            public new virtual string Version(string filePath)
            {
               return string.Format("{0}.{1}.{2}", _random.Next(5), _random.Next(8), _random.Next(22));
            }
            public new virtual int Size(string filePath)
            {
                return _random.Next(100000) + 100000;
            }
        }

        [TestMethod]
        public void GivenFileDetailAs_MinusV_VerifyVersionIsValid()
        {
            string fileResult = FileData.FileData.FileDetailsCheck("-v", "c:\test.txt");

            string[] version = fileResult.Split('.');

            int majorVersion = Convert.ToInt32(version[0]);
            int minorVersion = Convert.ToInt32(version[1]);
            int buildVersion = Convert.ToInt32(version[2]);

            bool isValidVersion = false;

            if (majorVersion >= 0 && majorVersion < 5)
            {
                isValidVersion = true;
            }

            if (minorVersion >= 0 && minorVersion < 8)
            {
                isValidVersion = true;
            }

            if (buildVersion >= 0 && buildVersion < 22)
            {
                isValidVersion = true;
            }

            Assert.IsTrue(isValidVersion);
        }

        [TestMethod]
        public void GivenFileDetailAs_MinusMinusV_VerifyVersionIsValid()
        {
            string fileResult = FileData.FileData.FileDetailsCheck("--v", "c:\test.txt");

            string[] version = fileResult.Split('.');

            int majorVersion = Convert.ToInt32(version[0]);
            int minorVersion = Convert.ToInt32(version[1]);
            int buildVersion = Convert.ToInt32(version[2]);

            bool isValidVersion = false;

            if (majorVersion >= 0 && majorVersion < 5)
            {
                isValidVersion = true;
            }

            if (minorVersion >= 0 && minorVersion < 8)
            {
                isValidVersion = true;
            }

            if (buildVersion >= 0 && buildVersion < 22)
            {
                isValidVersion = true;
            }

            Assert.IsTrue(isValidVersion);
        }

        [TestMethod]
        public void GivenFileDetailAs_ForwardSlashV_VerifyVersionIsValid()
        {
            string fileResult = FileData.FileData.FileDetailsCheck("/v", "c:\test.txt");

            string[] version = fileResult.Split('.');

            int majorVersion = Convert.ToInt32(version[0]);
            int minorVersion = Convert.ToInt32(version[1]);
            int buildVersion = Convert.ToInt32(version[2]);

            bool isValidVersion = false;

            if (majorVersion >= 0 && majorVersion < 5)
            {
                isValidVersion = true;
            }

            if (minorVersion >= 0 && minorVersion < 8)
            {
                isValidVersion = true;
            }

            if (buildVersion >= 0 && buildVersion < 22)
            {
                isValidVersion = true;
            }

            Assert.IsTrue(isValidVersion);
        }

        [TestMethod]
        public void GivenFileDetailAs_MinusMinusVersion_VerifyVersionIsValid()
        {
            string fileResult = FileData.FileData.FileDetailsCheck("--version", "c:\test.txt");

            string[] version = fileResult.Split('.');

            int majorVersion = Convert.ToInt32(version[0]);
            int minorVersion = Convert.ToInt32(version[1]);
            int buildVersion = Convert.ToInt32(version[2]);

            bool isValidVersion = false;

            if (majorVersion >= 0 && majorVersion < 5)
            {
                isValidVersion = true;
            }

            if (minorVersion >= 0 && minorVersion < 8)
            {
                isValidVersion = true;
            }

            if (buildVersion >= 0 && buildVersion < 22)
            {
                isValidVersion = true;
            }

            Assert.IsTrue(isValidVersion);
        }

        
        [TestMethod]
        public void GivenFileDetailAs_MinusS_VerifyValidSize()
        {
            string fileResult = FileData.FileData.FileDetailsCheck("-s", "c:\test.txt");

            int fileSize = Convert.ToInt32(fileResult);

            bool isValidSize = false;

            if (fileSize >= 100000 && fileSize <= 200000)
            {
                isValidSize = true;
            }

            Assert.IsTrue(isValidSize);
        }

        [TestMethod]
        public void GivenFileDetailAs_MinusMinusS_VerifyValidSize()
        {
            string fileResult = FileData.FileData.FileDetailsCheck("--s", "c:\test.txt");

            int fileSize = Convert.ToInt32(fileResult);

            bool isValidSize = false;

            if (fileSize >= 100000 && fileSize <= 200000)
            {
                isValidSize = true;
            }

            Assert.IsTrue(isValidSize);
        }

        [TestMethod]
        public void GivenFileDetailAs_ForwardSlashS_VerifyValidSize()
        {
            string fileResult = FileData.FileData.FileDetailsCheck("/s", "c:\test.txt");

            int fileSize = Convert.ToInt32(fileResult);

            bool isValidSize = false;

            if (fileSize >= 100000 && fileSize <= 200000)
            {
                isValidSize = true;
            }

            Assert.IsTrue(isValidSize);
        }

        [TestMethod]
        public void GivenFileDetailAs_MinusMinusSize_VerifyValidSize()
        {
            string fileResult = FileData.FileData.FileDetailsCheck("--size", "c:\test.txt");

            int fileSize = Convert.ToInt32(fileResult);

            bool isValidSize = false;

            if (fileSize >= 100000 && fileSize <= 200000)
            {
                isValidSize = true;
            }

            Assert.IsTrue(isValidSize);
        }

        [TestMethod]
        public void GivenAnyFilePathVerifyFileVersion()
        {
            string expectedVersion = "4.5.5";
            var mockFileDetails = new Mock<StubFileDetails>();

            mockFileDetails.Setup(x => x.Version(It.IsAny<string>())).Returns(expectedVersion);

            Assert.AreEqual("4.5.5", mockFileDetails.Object.Version(It.IsAny<string>()));
        }

        [TestMethod]
        public void GivenAnyFilePathVerifyFileSize()
        {
            int expectedSize = 184981;
            var mockFileDetails = new Mock<StubFileDetails>();

            mockFileDetails.Setup(x => x.Size(It.IsAny<string>())).Returns(expectedSize);

            Assert.AreEqual(184981, mockFileDetails.Object.Size(It.IsAny<string>()));

        }
    }
}
