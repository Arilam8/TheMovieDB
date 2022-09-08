using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateDB.Utils
{
    public class Constant
    {
        public const char TRIANGULAR_BULLET = '\u2023';
        public const char VERTICAL_LINE     = '\u2016';
        public const char POINT_DELIMITER   = '․';
        public const char POINT_DELIMITER_OTHER = '․';
        public static string MOVIE_FILE     = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}{System.IO.Path.DirectorySeparatorChar}movies.txt";
        public static string DEFAULT_TEXT = "N/A";
        public static string URL_POSTER = "https://image.tmdb.org/t/p/original";
        public static string ID_MOVIE_FILE = "1RTIIbWjwxZKYep7IIAuYMUIY9CnULJHW";
        public const int MOVIE_ADDED = 0;
        public const int MOVIE_ALREADY_ADDED = 1;
        public const int MOVIE_INVALID = 2;
        public const int MOVIE_ERROR_ADDING = 3;
        public const int MOVIE_ERROR_API_THEMOVIEDB = 4;
    }
}
