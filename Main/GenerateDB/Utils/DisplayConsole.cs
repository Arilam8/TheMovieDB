using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using Utils.TextUtils;
using Utils.ConsoleUtils;
using System.Linq;
using Type = DataAccessLayer.Models.Type;

namespace GenerateDB.Utils
{
    static class DisplayConsole
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="added"></param>
        /// <param name="maxAdded"></param>
        static public void DisplayProgress(int added, int maxAdded)
        {
            ConsoleUtils.DisplayWithColor($"Addition in progress... ({added}/{maxAdded})", true, ConsoleColor.Black, ConsoleColor.White);
        }

        /// <summary>
        /// 
        /// </summary>
        static public void DisplayFinished()
        {
            ConsoleUtils.DisplayWithColor("Finished", true, ConsoleColor.Black, ConsoleColor.White);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="status"></param>
        /// <param name="line"></param>
        static public void DisplayStatus(bool status, bool line)
        {
            if (status)
                ConsoleUtils.DisplayWithColor("   Added   ", line, ConsoleColor.White, ConsoleColor.Green);
            else
                ConsoleUtils.DisplayWithColor(" Not added ", line, ConsoleColor.White, ConsoleColor.Red);
        }

        /// <summary>
        /// 
        /// </summary>
        static private void DisplayMovieInvalid()
        {
            ConsoleUtils.DisplayWithColor("Invalid movie !", true, ConsoleColor.White, ConsoleColor.Red);
        }

        /// <summary>
        /// 
        /// </summary>
        static private void DisplayMovieAlreadyAdded()
        {
            ConsoleUtils.DisplayWithColor("Movie already added !", true, ConsoleColor.White, ConsoleColor.Red);
        }

        /// <summary>
        /// 
        /// </summary>
        static private void DisplayMovieErrorAdding()
        {
            ConsoleUtils.DisplayWithColor("Error (Adding) !", true, ConsoleColor.White, ConsoleColor.Red);
        }

        /// <summary>
        /// 
        /// </summary>
        static private void DisplayMovieErrorAPITheMovieDB()
        {
            ConsoleUtils.DisplayWithColor("Error (API TheMovieDB) !", true, ConsoleColor.White, ConsoleColor.Red);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resultCode"></param>
        static public void DisplayMovieNotAdded(int resultCode)
        {
            switch (resultCode)
            {
                case Constant.MOVIE_INVALID:
                    DisplayMovieInvalid();
                    break;
                case Constant.MOVIE_ALREADY_ADDED:
                    DisplayMovieAlreadyAdded();
                    break;
                case Constant.MOVIE_ERROR_ADDING:
                    DisplayMovieErrorAdding();
                    break;
                case Constant.MOVIE_ERROR_API_THEMOVIEDB:
                    DisplayMovieErrorAPITheMovieDB();
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="movie"></param>
        /// <param name="status"></param>
        static public void DisplayMovie(Movie movie, bool status)
        {
            Console.Write("Id : ");
            ConsoleUtils.DisplayText(movie.Id.ToString(), Constant.DEFAULT_TEXT, true);
            Console.Write("Status : ");
            DisplayStatus(status, true);
            Console.Write("Title : ");
            ConsoleUtils.DisplayText(movie.Title, Constant.DEFAULT_TEXT, true);
            Console.Write("Release date : ");
            if(movie.ReleaseDate == (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
                ConsoleUtils.DisplayNotAvailable(Constant.DEFAULT_TEXT, true);
            else
                ConsoleUtils.DisplayText(movie.ReleaseDate.ToString("MM/dd/yyyy"), Constant.DEFAULT_TEXT, true);
            Console.Write("Runtime : ");
            if (movie.Runtime < 0)
                ConsoleUtils.DisplayNotAvailable(Constant.DEFAULT_TEXT, true);
            else
                ConsoleUtils.DisplayText($"{movie.Runtime} minutes", Constant.DEFAULT_TEXT, true);
            Console.Write("Rating : ");
            ConsoleUtils.DisplayText($"{movie.Rating}/10", Constant.DEFAULT_TEXT, true);
            Console.Write("Poster : ");
            ConsoleUtils.DisplayText(movie.Poster, Constant.DEFAULT_TEXT, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="movieTypes"></param>
        static public void DisplayMovieType(ICollection<Type> types)
        {
            Console.Write("Movie type : ");
            List<string> Types = new List<string>();
            if(types != null && types.Count > 0)
            {
                foreach (Type type in types)
                {
                    Types.Add($"{type.Name} ({type.Id})");
                }
            }
            ConsoleUtils.DisplayText(TextUtils.GetTextList(Types), Constant.DEFAULT_TEXT, true);
        }

        /// <summary>
        /// 
        /// </summary>
        static public void DisplayActorStartHeader()
        {
            Console.WriteLine(" ------------------------------------------------------------------------------------------ ");
            Console.WriteLine("|   Status    |    Id    |             Actor              |            Character           |");
            Console.WriteLine("|-------------|----------|--------------------------------|--------------------------------|");
        }

        /// <summary>
        /// 
        /// </summary>
        static public void DisplayActorEndHeader()
        {
            Console.WriteLine(" ------------------------------------------------------------------------------------------ ");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="movieActor"></param>
        /// <param name="status"></param>
        static public void DisplayActor(Actor actor, bool status)
        {
            string id = TextUtils.GetTextMaxLength(actor.Id.ToString(), 8);
            string nameActor = TextUtils.GetTextMaxLength(actor.Surname + ' ' + actor.Name, 30);
            string character = string.Empty;
            if(actor.Roles != null && actor.Roles.Count > 0)
                character = TextUtils.GetTextMaxLength(actor.Roles.ToList().Last().Character, 30);
            int spaceId = TextUtils.GetSpace(id, Constant.DEFAULT_TEXT, 8);
            int spaceActor = TextUtils.GetSpace(nameActor, Constant.DEFAULT_TEXT, 30);
            int spaceCharacter = TextUtils.GetSpace(character, Constant.DEFAULT_TEXT, 30);  
            Console.Write("| ");
            DisplayStatus(status, false);
            Console.Write(" | ");
            ConsoleUtils.DisplayText(id, Constant.DEFAULT_TEXT, false);
            ConsoleUtils.DisplaySpace(spaceId);
            Console.Write(" | ");
            ConsoleUtils.DisplayText(nameActor, Constant.DEFAULT_TEXT, false);
            ConsoleUtils.DisplaySpace(spaceActor);
            Console.Write(" | ");
            ConsoleUtils.DisplayText(character, Constant.DEFAULT_TEXT, false);
            ConsoleUtils.DisplaySpace(spaceCharacter);
            Console.WriteLine(" |");
        }

        /// <summary>
        /// 
        /// </summary>
        static public void DisplayNoActor()
        {
            Console.WriteLine(" ------------------------------------------------------------------------------------------ ");
            Console.WriteLine("|   Status    |    Id    |             Actor              |            Character           |");
            Console.WriteLine("|------------------------------------------------------------------------------------------|");
            Console.Write("|");
            ConsoleUtils.DisplaySpace(41);
            ConsoleUtils.DisplayWithColor("No actor", false, ConsoleColor.Black, ConsoleColor.White);
            ConsoleUtils.DisplaySpace(41);
            Console.WriteLine("|");
            DisplayActorEndHeader();
        }
    }
}
