using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Utils.ConsoleUtils;
using Utils.DownloadUtils;
using Utils.FileUtils;
using Utils.ParserUtils;
using APIUtils = Utils.APIUtils;
using Type = DataAccessLayer.Models.Type;

namespace GenerateDB.Utils
{
    static class Utils
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static public bool ValidFile()
        {
            Console.Write("Checking if the file exists...");
            if (File.Exists(Constant.MOVIE_FILE))
                ConsoleUtils.DisplayWithColor("OK", true, ConsoleColor.White, ConsoleColor.Green);
            else
            {
                ConsoleUtils.DisplayWithColor("FAIL", true, ConsoleColor.White, ConsoleColor.Red);
                Console.WriteLine("We can't find the file !");
                return DownloadFile();
            }
            return CheckIntegrityFile();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static public bool DownloadFile()
        {
            Console.WriteLine("Do you want to download the file ?");
            List<string> options = new List<string>();
            options.Add("YES");
            options.Add("NO");
            if (MenuConsole.ChoiceYesNo(MenuConsole.Menu(options)))
            {
                while (!DownloadUtils.DownloadFileConsole(APIUtils.APIGoogleDriveManager.GetUrlDownloadFile(Constant.ID_MOVIE_FILE), Constant.MOVIE_FILE))
                {
                    ConsoleUtils.DisplayWithColor("FAIL", true, ConsoleColor.White, ConsoleColor.Red);
                    Console.WriteLine("Retry ?");
                    if (!MenuConsole.ChoiceYesNo(MenuConsole.Menu(options)))
                    {
                        DownloadUtils.DeleteFileConsole(Constant.MOVIE_FILE);
                        return false;
                    }
                }
            }
            else
                return false;
            return CheckIntegrityFile();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static public bool CheckIntegrityFile()
        {
            Console.Write("Checking file integrity...");
            if (FileUtils.IsValidFile(Constant.MOVIE_FILE, APIUtils.APIGoogleDriveManager.GetMD5ChecksumFile(Constant.ID_MOVIE_FILE)))
            {
                ConsoleUtils.DisplayWithColor("OK", true, ConsoleColor.White, ConsoleColor.Green);
                return true;
            }
            else
            {
                ConsoleUtils.DisplayWithColor("FAIL", true, ConsoleColor.White, ConsoleColor.Red);
                DownloadUtils.DeleteFileConsole(Constant.MOVIE_FILE);
                return DownloadFile();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        static public int ValidNumberInt(int number)
        {
            if (number <= 0)
                return -1;
            return number;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        static public float ValidRating(float number)
        {
            if (number <= 0)
                return 0;
            return number;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        static public int GetIdActor(string line)
        {
            if(String.IsNullOrWhiteSpace(line))
                return -1;
            string[] actor;
            if(line.Split(Constant.POINT_DELIMITER, StringSplitOptions.RemoveEmptyEntries).Count() != 0)
                actor = line.Split(Constant.POINT_DELIMITER, StringSplitOptions.RemoveEmptyEntries);
            else
                actor = line.Split(Constant.POINT_DELIMITER_OTHER, StringSplitOptions.RemoveEmptyEntries);
            return ParserUtils.ParseInt(actor[0]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        static public string GetSurnameNameActor(string line)
        {
            if (String.IsNullOrWhiteSpace(line))
                return null;
            string[] actor;
            if (line.Split(Constant.POINT_DELIMITER, StringSplitOptions.RemoveEmptyEntries).Count() != 0)
                actor = line.Split(Constant.POINT_DELIMITER, StringSplitOptions.RemoveEmptyEntries);
            else
                actor = line.Split(Constant.POINT_DELIMITER_OTHER, StringSplitOptions.RemoveEmptyEntries);
            return actor[1];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        static public string GetSurnameActor(string line)
        {
            if(String.IsNullOrWhiteSpace(line))
                return null;
            if(line.IndexOf(" ") == -1)
                return line;
            return line.Substring(0, line.IndexOf(" "));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        static public string GetNameActor(string line)
        {
            if (String.IsNullOrWhiteSpace(line) || line.IndexOf(" ") == -1)
                return null;
            return line.Substring(line.IndexOf(" ") + 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        static public string GetCharacterActor(string line)
        {
            if (String.IsNullOrWhiteSpace(line))
                return null;
            string[] actor;
            if (line.Split(Constant.POINT_DELIMITER, StringSplitOptions.RemoveEmptyEntries).Count() != 0)
                actor = line.Split(Constant.POINT_DELIMITER, StringSplitOptions.RemoveEmptyEntries);
            else
                actor = line.Split(Constant.POINT_DELIMITER_OTHER, StringSplitOptions.RemoveEmptyEntries);
            if (actor.Count() < 3)
                return null;
            else
                return actor[2];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="second"></param>
        static public void DelayStart(int second)
        {
            for (int i = 0; i < second; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine($"Inserting movies will start in {second - i} second...");
                Console.SetCursorPosition(0, --Console.CursorTop);
            }
            Thread.Sleep(500);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kindMovie"></param>
        /// <returns></returns>
        static public int GetIdForMovieType(string kindMovie)
        {
            string[] digits = Regex.Split(kindMovie, @"\D+");

            foreach (string value in digits)
            {
                int number;
                if (int.TryParse(value, out number))
                {
                    return number;
                }
            }
            return -1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeMovie"></param>
        /// <returns></returns>
        static public string GetType(string typeMovie)
        {
            Type type = new Type();

            MatchCollection matchesName = Regex.Matches(typeMovie, @"(\w+)");
            foreach (Match match in matchesName)
            {
                type.Name = match.Value;
            }

            return type.Name;
        }
    }
}
