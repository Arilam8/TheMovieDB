using DataTransferObject;
using System;
using System.IO;
using System.Net;
using System.Reflection.Metadata;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;
using Utils.APIUtils;

namespace Utils.DownloadUtils
{
    static public class DownloadUtils
    {
        static public bool IsValidFileDownload(string url)
        {
            bool isValid = false;
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "HEAD";
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if(response.StatusCode == HttpStatusCode.OK)
                    isValid = true;
            }
            catch (Exception)
            {
                isValid = false;
            }
            return isValid;
        }

        static public bool DeleteFile(string path)
        {
            bool deleted = false;
            try
            {
                File.Delete(path);
                deleted = true;
            }
            catch (Exception)
            {
                deleted = false;
            }
            return deleted;
        }

        static public bool DeleteFileConsole(string path)
        {
            bool deleted = false;
            ConsoleUtils.ConsoleUtils.DisplayTextLine("Deleting...", false);
            if(DeleteFile(path))
            {
                deleted = true;
                ConsoleUtils.ConsoleUtils.DisplayWithColor("OK", true, ConsoleColor.White, ConsoleColor.Green);
            }
            else
            {
                deleted = false;
                ConsoleUtils.ConsoleUtils.DisplayWithColor("FAIL", true, ConsoleColor.White, ConsoleColor.Red);
            }
            return deleted;
        }

        static public bool DownloadFileConsole(string urlDownload, string path)
        {
            bool downloaded = false;
            bool finish = false;
            bool progress = false;
            int timer = 0;
            int currentTimer = 0;
            long downloadedBytesSecond = 0;
            long previousBytesReceived = 0;
            long totalBytesToReceive = 0;
            ConsoleUtils.ConsoleUtils.DisplayTextLine("Downloading...", false);
            try
            {
                using (var client = new WebClient())
                {
                    client.DownloadProgressChanged += (sender, e) =>
                    {
                        if (totalBytesToReceive == 0)
                            totalBytesToReceive = e.TotalBytesToReceive;
                        if (timer != currentTimer && !progress)
                        {
                            progress = true;
                            DownloadProgressConsole(e, downloadedBytesSecond);
                            timer = currentTimer;
                            downloadedBytesSecond = 0;
                            progress = false;
                        }
                        downloadedBytesSecond += e.BytesReceived - previousBytesReceived;
                        previousBytesReceived = e.BytesReceived;
                    };
                    client.DownloadFileCompleted += (sender, e) =>
                    {
                        downloaded = e.Error == null ? true : false && e.Cancelled == false ? true : false;
                        if(downloaded)
                        {
                            ConsoleUtils.ConsoleUtils.ClearLine(Console.BufferWidth, false);
                            ConsoleUtils.ConsoleUtils.DisplayTextLine("Downloaded [100% - " + FileUtils.FileUtils.ByteToMegabyte(totalBytesToReceive).ToString("#0.00") + " Mb]", true);
                        }
                        finish = true;
                    };
                    client.DownloadFileAsync(new Uri(urlDownload), path);
                    while (!finish)
                    {
                        timer++;
                        Thread.Sleep(1000);
                    }
                }
            }
            catch (Exception)
            {
                downloaded = false;
            }
            return downloaded;
        }

        static private void DownloadProgressConsole(DownloadProgressChangedEventArgs downloadProgressChangedEventArgs, long downloadedByteSecond)
        {
            int progressPourcentage = downloadProgressChangedEventArgs.ProgressPercentage;
            float progressSpeed = FileUtils.FileUtils.ByteToMegabyte(downloadedByteSecond);
            TimeSpan timeSpan = new TimeSpan(0, 0, Math.Abs(DownloadTimeLeft(downloadProgressChangedEventArgs.BytesReceived, downloadProgressChangedEventArgs.TotalBytesToReceive, progressSpeed)));
            ConsoleUtils.ConsoleUtils.ClearLine(Console.BufferWidth, false);
            ConsoleUtils.ConsoleUtils.DisplayTextLine("Downloading... [" + progressPourcentage + "% - " + Math.Abs(progressSpeed).ToString("#0.00") + " Mb/s - " + FileUtils.FileUtils.ByteToMegabyte(downloadProgressChangedEventArgs.BytesReceived).ToString("#0.00") + " Mb / " + FileUtils.FileUtils.ByteToMegabyte(downloadProgressChangedEventArgs.TotalBytesToReceive).ToString("#0.00") + " Mb - " + string.Format("{0} min {1:00} s", (int)timeSpan.TotalMinutes, timeSpan.Seconds) + "]", false);
        }

        static public int DownloadTimeLeft(long currentBytes, long totalBytes, float speed)
        {
            return ParserUtils.ParserUtils.ParseInt(Math.Round((FileUtils.FileUtils.ByteToMegabyte(totalBytes - currentBytes) / speed), 0, MidpointRounding.AwayFromZero).ToString());
        }

        static public byte[] DownloadImage(string urlImage)
        {
            if (!string.IsNullOrWhiteSpace(urlImage) && IsValidFileDownload(urlImage))
            {
                WebClient webClient = new WebClient();
                return webClient.DownloadData(urlImage);
            }
            return null;
        }
    }
}
