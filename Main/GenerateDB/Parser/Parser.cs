using DataAccessLayer.Models;
using GenerateDB.Utils;
using System;
using System.Collections.Generic;
using System.Threading;
using Newtonsoft.Json.Linq;
using Type = DataAccessLayer.Models.Type;
using FileUtils = Utils.FileUtils.FileUtils;
using ParserUtils = Utils.ParserUtils.ParserUtils;
using APIUtils = Utils.APIUtils;
using DataAccessLayer.Data;
using System.Linq;
using Utils.DownloadUtils;

namespace GenerateDB.Data
{
    public class Parser
    {
        private string _line;
        private MovieManager _movieManager;

        public Parser()
        {
            _movieManager = new MovieManager();
        }

        /// <summary>
        /// Loads 'n' films from a file or an API
        /// </summary>
        /// <param name="nbMoviesToLoad"></param>
        /// <param name="loadAPI"></param>
        /// <param name="gui"></param>
        public void LoadMovies(int nbMoviesToLoad, bool loadAPI = false, bool gui = false)
        {
            if (Utils.Utils.ValidFile())
            {
                if(gui)
                {
                    Utils.Utils.DelayStart(3);
                    Console.Clear();
                }
                for (int indexMovie = 0; indexMovie < nbMoviesToLoad; ++indexMovie)
                {
                    if(gui)
                        Console.Clear();
                    DisplayConsole.DisplayProgress(indexMovie + 1, nbMoviesToLoad);
                    Console.WriteLine("Reading the file...");
                    _line = FileUtils.FileRandomRead(Constant.MOVIE_FILE);
                    Console.WriteLine("Splitting...");
                    string[] parts = this._line.Split(Constant.TRIANGULAR_BULLET);
                    Console.WriteLine("Processing...");
                    int resultParser = Parse(ParserUtils.ParseInt(parts[0]), loadAPI, parts);
                    if(resultParser != Constant.MOVIE_ADDED)
                    {
                        indexMovie--;
                        DisplayConsole.DisplayMovieNotAdded(resultParser);
                    }
                    Thread.Sleep(1000);
                }
            }
        }

        /// <summary>
        /// Loads one film from an API
        /// </summary>
        /// <param name="idMovie"></param>
        /// <param name="gui"></param>
        public void LoadMovie(int idMovie, bool gui = false)
        {
            if (Utils.Utils.ValidFile())
            {
                if (gui)
                {
                    Utils.Utils.DelayStart(3);
                    Console.Clear();
                }
                Console.WriteLine("Reading the file...");
                _line = FileUtils.FileRandomRead(Constant.MOVIE_FILE);
                Console.WriteLine("Splitting...");
                string[] parts = this._line.Split(Constant.TRIANGULAR_BULLET);
                Console.WriteLine("Processing...");
                int resultParser = Parse(idMovie, true);
                if (resultParser != Constant.MOVIE_ADDED)
                    DisplayConsole.DisplayMovieNotAdded(resultParser);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idMovie"></param>
        /// <param name="api"></param>
        /// <param name="parts"></param>
        /// <returns></returns>
        private int Parse(int idMovie, bool api, string[] parts = null)
        {
            if (idMovie == -1 || !APIUtils.APITheMovieDBManager.IsValidMovie(idMovie))
                return Constant.MOVIE_INVALID;
            if (_movieManager.IsExistMovie(idMovie))
                return Constant.MOVIE_ALREADY_ADDED;
            if(api)
                return ParseAPI(idMovie);
            else
                return ParseFile(parts, idMovie);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parts"></param>
        /// <param name="idMovie"></param>
        /// <returns></returns>
        private int ParseFile(string[] parts, int idMovie)
        {
            Movie movie = new Movie();
            IList<Type> types = new List<Type>();
            IList<Actor> actors = new List<Actor>();

            // === [ Movie details ] ===
            movie.Id = idMovie;
            movie.Title = parts[1];
            movie.ReleaseDate = ParserUtils.ParseDate(parts[3]);
            movie.Rating = Utils.Utils.ValidRating(ParserUtils.ParseFloat(parts[5].Replace(".", ",")));
            movie.Runtime = ParserUtils.ParseInt(parts[7]);
            if (DownloadUtils.IsValidFileDownload(Constant.URL_POSTER + parts[9]))
                movie.Poster = parts[9];
            else
                movie.Poster = APIUtils.APITheMovieDBManager.GetMoviePoster(movie.Id);
            if (_movieManager.InsertMovie(movie))
                DisplayConsole.DisplayMovie(movie, true);
            else
                return Constant.MOVIE_ERROR_ADDING;

            // === [ Movie Types ] ===
            string[] typesArray = parts[12].Split(Constant.VERTICAL_LINE);
            foreach (string typeArray in typesArray)
            {
                types = SaveType(new Type(Utils.Utils.GetIdForMovieType(typeArray), Utils.Utils.GetType(typeArray)), movie, types);
            }
            DisplayConsole.DisplayMovieType(types);

            // === [ Movie actors ] ===
            string[] actorsArray = parts[14].Split(Constant.VERTICAL_LINE);
            if (actors != null && actorsArray.Length > 0 && !string.IsNullOrWhiteSpace(actorsArray[0]))
            {
                DisplayConsole.DisplayActorStartHeader();
                foreach (string actorArray in actorsArray)
                {
                    Actor actor = new Actor(Utils.Utils.GetIdActor(actorArray), Utils.Utils.GetSurnameActor(Utils.Utils.GetSurnameNameActor(actorArray)), Utils.Utils.GetNameActor(Utils.Utils.GetSurnameNameActor(actorArray)));
                    Role role = new Role(Utils.Utils.GetCharacterActor(actorArray), actor, movie);
                    actors = SaveActor(actor, role, actors);
                }
                DisplayConsole.DisplayActorEndHeader();
            }
            else
                DisplayConsole.DisplayNoActor();
                
            // === Insert into Movie ===
            movie.Types = types;
            // === Insert into Movie ===
            movie.Actors = actors;
            _movieManager.UpdateMovie(movie);

            return Constant.MOVIE_ADDED;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idMovie"></param>
        /// <returns></returns>
        private int ParseAPI(int idMovie)
        {
            Movie movie = new Movie();
            IList<Type> types = new List<Type>();
            IList<Actor> actors = new List<Actor>();
            string resultAPITheMovieDB;

            // === [ Movie details ] ===
            movie.Id = idMovie;
            resultAPITheMovieDB = APIUtils.APITheMovieDBManager.GetMovieDetails(movie.Id);
            if (resultAPITheMovieDB == null)
                return Constant.MOVIE_ERROR_API_THEMOVIEDB;
            dynamic details = JObject.Parse(resultAPITheMovieDB);
            movie.Title = details.title;
            movie.ReleaseDate = ParserUtils.ParseDate((string)details.release_date);
            movie.Rating = details.vote_average;
            movie.Runtime = Utils.Utils.ValidNumberInt(ParserUtils.ParseInt((string)details.runtime));
            movie.Poster = details.poster_path;
            if(_movieManager.InsertMovie(movie))
                DisplayConsole.DisplayMovie(movie, true);
            else
                return Constant.MOVIE_ERROR_ADDING;

            // === [ Movie types ] ===
            JArray typesArray = details.genres;
            foreach (JObject jObject in typesArray)
            {
                dynamic type = JObject.Parse(jObject.ToString());
                types = SaveType(new Type((int)type.id, (string)type.name), movie, types);
            }
            DisplayConsole.DisplayMovieType(types);

            // === [ Movie actors ] ===
            resultAPITheMovieDB = APIUtils.APITheMovieDBManager.GetMovieCredits(movie.Id);
            if(resultAPITheMovieDB == null)
                DisplayConsole.DisplayNoActor();
            else
            {
                dynamic credits = JObject.Parse(resultAPITheMovieDB);
                JArray cast = credits.cast;
                if (cast != null && cast.Count > 0)
                {
                    DisplayConsole.DisplayActorStartHeader();
                    foreach (JObject jObject in cast)
                    {
                        dynamic actorCast = JObject.Parse(jObject.ToString());
                        Actor actor = new Actor((int)actorCast.id, Utils.Utils.GetSurnameActor((string)actorCast.original_name), Utils.Utils.GetNameActor((string)actorCast.original_name));
                        Role role = new Role((string)actorCast.character, actor, movie);
                        actors = SaveActor(actor, role, actors);
                    }   
                    DisplayConsole.DisplayActorEndHeader();
                }
                else
                    DisplayConsole.DisplayNoActor();
            }

            // === Insert into Movie ===
            movie.Types = types;
            // === Insert into Movie ===
            movie.Actors = actors;
            _movieManager.UpdateMovie(movie);

            return Constant.MOVIE_ADDED;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="movie"></param>
        /// <param name="movieTypes"></param>
        /// <returns></returns>
        private IList<Type> SaveType(Type type, Movie movie, IList<Type> types)
        {
            if (type.Id != -1)
            {
                if (!_movieManager.IsExistType(type.Id)) // If the movietype doesn't exist
                {
                    if(!_movieManager.InsertType(type))
                        return types;
                }
                types.Add(type);
            }
            return types;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actor"></param>
        /// <returns></returns>
        private IList<Actor> SaveActor(Actor actor, Role role, IList<Actor> actors)
        {
            if (actor.Id == -1)
            {
                DisplayConsole.DisplayActor(actor, false);
                return actors;
            }
            if (!_movieManager.IsExistActor(actor.Id))
            {
                if(_movieManager.InsertActor(actor))
                {
                    if(string.IsNullOrWhiteSpace(role.Character))
                    {
                        actors.Add(actor);
                        DisplayConsole.DisplayActor(actor, true);
                        return actors;
                    }
                }
                else
                {
                    DisplayConsole.DisplayActor(actor, false);
                    return actors;
                }
            }
            else
            {
                if (actors.Select(actor => actor.Id).OrderBy(ActorId => ActorId).ToList().Contains(actor.Id))
                {
                    foreach (Actor actorItem in actors)
                    {
                        if (actorItem.Id == actor.Id)
                        {
                            actorItem.Roles.Add(role);
                            DisplayConsole.DisplayActor(actorItem, true);
                            return actors;
                        }
                    }
                }
            }
            actor.Roles.Add(role);
            actors.Add(actor);
            DisplayConsole.DisplayActor(actor, true);
            return actors;
        }
    }
}
