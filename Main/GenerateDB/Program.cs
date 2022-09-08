using DataAccessLayer.Data;
using GenerateDB.Data;
using GenerateDB.Utils;
using System;
using System.Collections.Generic;
using Utils.ConsoleUtils;

namespace GenerateDB
{
    public class Program
    {
        private static bool s_api = false;
        private static int s_numberMovies = 50;

        /// <summary>
        /// Main method (parser)
        /// </summary>
        /// <param name="args">String array that represents the command-line arguments</param>
        public static void Main()
        {
            Menu();
            MovieManager movieManager = new MovieManager();

            //Movie _movie = new("MovieTestNext", new DateTime(2021, 10, 20), 4, 120);
            //Console.WriteLine("Inserting a DbMovies");
            //_dbManager.Insert<Movie>(_movie);
            //Console.WriteLine("DbMovies Inserted");

            Console.WriteLine("Creating the database...");
            movieManager.EnsureDatabase(); // Important !
            Parser parse = new Parser();
            parse.LoadMovies(s_numberMovies, s_api, true);
            DisplayConsole.DisplayFinished();
        }

        /// <summary>
        /// Displays main menu
        /// </summary>
        private static void Menu()
        {
            Console.WriteLine("############### Configuration of the DbManager ###############");
            Console.WriteLine("Get all information of the movies only from TheMovieDB ?");
            List<string> options = new List<string>();
            options.Add("YES");
            options.Add("NO");
            s_api = MenuConsole.ChoiceYesNo(MenuConsole.Menu(options));
            MenuNumberMovies();
            Console.WriteLine("##############################################################");
        }

        /// <summary>
        /// Displays the menu that asks for the number of films to be added
        /// </summary>
        private static void MenuNumberMovies()
        {
            bool success = false;
            Console.WriteLine("Number of movies ?");
            do
            {
                string line = Console.ReadLine();
                success = Int32.TryParse(line, out s_numberMovies);
                if(success)
                {
                    if(s_numberMovies <= 0)
                        success = false;
                }
                if (!success)
                    ConsoleUtils.ClearLine(line.Length, true);                
            } while (!success);
        }
    }
}
