using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using ThirdPartyTools;

namespace FileData
{
    public static class FileData
    {

        public static string FileDetailsCheck(string fileDetail, string filePath)
        {
            string fileResult = string.Empty;
            fileDetail = fileDetail.Trim();

            if (fileDetail == "-v" || fileDetail == "--v" || fileDetail == "/v" || fileDetail == "--version")
            {
                string fileVersion = new FileDetails().Version(filePath);
                fileResult = fileVersion;

            }
            
            if (fileDetail == "-s" || fileDetail == "--s" || fileDetail == "/s" || fileDetail == "--size")
            {
                int fileSize = new FileDetails().Size(filePath);
                fileResult = fileSize.ToString();
            }

            return fileResult;
        }
       
        public static void Main(string[] args)
        {

            Console.WriteLine(FileDetailsCheck(args[0], args[1]));

            Console.ReadKey();

        }
    }
}
