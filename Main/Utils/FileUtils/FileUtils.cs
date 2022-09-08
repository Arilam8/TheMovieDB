using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Security.Cryptography;

namespace Utils.FileUtils
{
    static public class FileUtils
    {
        static public string FileRandomRead(string path)
        {
            string[] allLines = File.ReadAllLines(path);
            Random rnd = new Random();
            return (allLines[rnd.Next(allLines.Length)]);
        }

        static public bool IsValidFile(string path, string md5ChecksumFile)
        {
            if(md5ChecksumFile == null)
                return false;
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(path))
                {
                    return md5ChecksumFile.Equals(BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLowerInvariant());
                }
            }
        }

        static public float ByteToMegabyte(long bytes)
        {
            return ParserUtils.ParserUtils.ParseFloat(bytes.ToString()) / 1048576;
        }
    }
}
