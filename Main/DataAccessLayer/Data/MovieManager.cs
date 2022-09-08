using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using Type = DataAccessLayer.Models.Type;


namespace DataAccessLayer.Data
{
    public class MovieManager : IDisposable
    {
        #region MEMBER_VARIABLES
        private MovieContext _movieContext;
        #endregion

        #region BUILDERS
        public MovieManager()
        {
            _movieContext = new MovieContext();
        }
        #endregion

        #region METHODS
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        private bool Insert<T>(T obj)
        {
            bool insert = false;
            using (MovieContext contextDB = new MovieContext())
            {
                try
                {
                    //contextDB.Database.EnsureDeleted(); // Don't need
                    //contextDB.Database.EnsureCreated(); // If you want to create the database
                    contextDB.Add(obj);
                    contextDB.SaveChanges();
                    insert = true;
                }
                catch
                {
                    insert = false;
                }
                contextDB.Dispose();
                return insert;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        private bool Update<T>(T obj)
        {
            bool update = false;
            using (MovieContext contextDB = new MovieContext())
            {
                try
                {
                    //contextDB.Database.EnsureDeleted(); // Don't need
                    //contextDB.Database.EnsureCreated(); // If you want to create the database
                    contextDB.Update(obj);
                    contextDB.SaveChanges();
                    update = true;
                }
                catch
                {
                    update = false;
                }
                contextDB.Dispose();
                return update;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        private bool Delete<T>(T obj)
        {
            bool delete = false;
            using (MovieContext contextDB = new MovieContext())
            {
                try
                {
                    //contextDB.Database.EnsureDeleted(); // Don't need
                    //contextDB.Database.EnsureCreated(); // If you want to create the database
                    contextDB.Remove(obj);
                    contextDB.SaveChanges();
                    delete = true;
                }
                catch
                {
                    delete = false;
                }
                contextDB.Dispose();
                return delete;
            }
        }

        /// <summary>
        /// Ensures that the database for the context exists
        /// </summary>
        public void EnsureDatabase()
        {
            using (MovieContext contextDB = new MovieContext())
            {
                //contextDB.Database.EnsureDeleted(); // Don't need
                contextDB.Database.EnsureCreated();
                contextDB.Dispose();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            _movieContext.Dispose();
        }

        /// <summary>
        /// Checks if the movie exists
        /// </summary>
        /// <param name="idMovie">the movie's id</param>
        /// <returns>True if the movie exists, else false</returns>
        public bool IsExistMovie(int idMovie)
        {
            return _movieContext.DbMovies.Any(m => m.Id == idMovie);
        }

        /// <summary>
        /// Checks if the type exists
        /// </summary>
        /// <param name="idType">the type's id</param>
        /// <returns>True if the type exists, else false</returns>
        public bool IsExistType(int idType)
        {
            return this._movieContext.DbTypes.Any(t => t.Id == idType);
        }

        /// <summary>
        /// Checks if the comment exists
        /// </summary>
        /// <param name="idComment"></param>
        /// <returns></returns>
        public bool IsExistComment(int idComment)
        {
            return this._movieContext.DbComments.Any(c => c.Id == idComment);
        }

        /// <summary>
        /// Checks if the actor exists
        /// </summary>
        /// <param name="idActor">the actor's id</param>
        /// <returns>True if the actor exists, else false</returns>
        public bool IsExistActor(int idActor)
        {
            return this._movieContext.DbActors.Any(a => a.Id == idActor);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        public bool InsertMovie(Movie movie)
        {
            return Insert<Movie>(movie);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool InsertType(Type type)
        {
            return Insert<Type>(type);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actor"></param>
        /// <returns></returns>
        public bool InsertActor(Actor actor)
        {
            return Insert<Actor>(actor);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        public bool UpdateMovie(Movie movie)
        {
            return Update<Movie>(movie);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        public bool UpdateComment(Comment comment)
        {
            return Update<Comment>(comment);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="comment"></param>
        /// <param name="commentCreated"></param>
        /// <returns></returns>
        public bool UpdateComment(Comment comment, out Comment commentCreated)
        {
            bool update = Update<Comment>(comment);
            commentCreated = comment;
            return update;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        public bool DeleteComment(Comment comment)
        {
            return Delete<Comment>(comment);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IQueryable<Movie> GetMoviesOrderByTitle()
        {
            return this._movieContext.DbMovies
                .Include(m => m.Comments)
                .OrderBy(m => m.Title);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public IQueryable<Movie> GetMoviesOrderByReleaseDate(int index, int take, out int moviesCount)
        {
            IQueryable<Movie> movies = this._movieContext.DbMovies
                                           .Include(m => m.Comments)
                                           .OrderByDescending(m => m.ReleaseDate.Year)
                                           .ThenByDescending(m => m.Rating);
            moviesCount = movies.Count();
            return movies.Skip(index * take)
                         .Take(take);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idMovies"></param>
        /// <param name="index"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public IQueryable<Movie> GetMoviesByIdMovies(IList<int> idMovies)
        {
            return this._movieContext.DbMovies
                .Include(m => m.Comments)
                .Where(m => idMovies.Contains(m.Id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idMovie"></param>
        /// <returns></returns>
        public Movie GetMovieByIdMovie(int idMovie)
        {
            return this._movieContext.DbMovies
                .Include(m => m.Comments)
                .FirstOrDefault(m => m.Id == idMovie);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idMovie"></param>
        /// <returns></returns>
        public Movie GetFullMovieByIdMovie(int idMovie)
        {
            return this._movieContext.DbMovies
                .Include(m => m.Comments)
                .Include(m => m.Types)
                .FirstOrDefault(m => m.Id == idMovie);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idMovie"></param>
        /// <returns></returns>
        public IQueryable<Type> GetTypesByIdMovie(int idMovie)
        {
            return this._movieContext.DbTypes
                .Include(t => t.Movies)
                .Where(t => t.Movies.Any(m => m.Id == idMovie));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idMovie"></param>
        /// <param name="index"></param>
        /// <param name="take"></param>
        /// <param name="invalidComment"></param>
        /// <param name="commentsCount"></param>
        /// <returns></returns>
        public IQueryable<Comment> GetListCommentsByIdMovie(int idMovie, bool invalidComment, int index, int take, out int commentsCount)
        {
            IQueryable<Comment> comments;
            if (invalidComment)
                comments = this._movieContext.DbComments
                    .Where(c => c.MovieId == idMovie)
                    .OrderByDescending(c => c.Date);
            else
                comments = this._movieContext.DbComments
                    .Where(c => c.MovieId == idMovie && c.Valid == true)
                    .OrderByDescending(c => c.Date);
            commentsCount = comments.Count();
            return comments.Skip(index * take)
                           .Take(take);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idComment"></param>
        /// <returns></returns>
        public Comment GetCommentByIdComment(int idComment)
        {
            return this._movieContext.DbComments
                .FirstOrDefault(c => c.Id == idComment);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public IQueryable<Movie> GetMoviesByPartialOrEntirelyTitle(string title)
        {
            return this._movieContext.DbMovies
                .Where(m => m.Title.ToLower()
                                   .Replace(" ", "")
                                   .Replace(".", "")
                                   .Replace(",", "")
                                   .Replace(";", "")
                                   .Replace(":", "")
                                   .Replace("?", "")
                                   .Replace("!", "")
                                   .Replace("-", "")
                                   .Replace("&", "")
                                   .Replace("'", "")
                                   .Replace("à", "a")
                                   .Replace("á", "a")
                                   .Replace("â", "a")
                                   .Replace("ç", "c")
                                   .Replace("è", "e")
                                   .Replace("é", "e")
                                   .Replace("ê", "e")
                                   .Replace("î", "i")
                                   .Replace("ò", "o")
                                   .Replace("ó", "o")
                                   .Replace("ô", "o")
                                   .Replace("ù", "u")
                                   .Replace("ú", "u")
                                   .Replace("û", "u")
                                   .Replace("ý", "y")
                                   .Contains(title.ToLower()
                                                  .Replace(" ", "")
                                                  .Replace(".", "")
                                                  .Replace(",", "")
                                                  .Replace(";", "")
                                                  .Replace(":", "")
                                                  .Replace("?", "")
                                                  .Replace("!", "")
                                                  .Replace("-", "")
                                                  .Replace("&", "")
                                                  .Replace("'", "")
                                                  .Replace("à", "a")
                                                  .Replace("á", "a")
                                                  .Replace("â", "a")
                                                  .Replace("ç", "c")
                                                  .Replace("è", "e")
                                                  .Replace("é", "e")
                                                  .Replace("ê", "e")
                                                  .Replace("î", "i")
                                                  .Replace("ò", "o")
                                                  .Replace("ó", "o")
                                                  .Replace("ô", "o")
                                                  .Replace("ù", "u")
                                                  .Replace("ú", "u")
                                                  .Replace("û", "u")
                                                  .Replace("ý", "y")))
                .Include(m => m.Comments);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IQueryable<Actor> GetActorsByPartialOrEntirelyName(string name)
        {
            return this._movieContext.DbActors
                    .Where(a => (a.Surname + a.Name).ToLower()
                                                    .Replace(" ", "")
                                                    .Replace(".", "")
                                                    .Replace(",", "")
                                                    .Replace(";", "")
                                                    .Replace(":", "")
                                                    .Replace("?", "")
                                                    .Replace("!", "")
                                                    .Replace("-", "")
                                                    .Replace("&", "")
                                                    .Replace("'", "")
                                                    .Replace("à", "a")
                                                    .Replace("á", "a")
                                                    .Replace("â", "a")
                                                    .Replace("ç", "c")
                                                    .Replace("è", "e")
                                                    .Replace("é", "e")
                                                    .Replace("ê", "e")
                                                    .Replace("î", "i")
                                                    .Replace("ò", "o")
                                                    .Replace("ó", "o")
                                                    .Replace("ô", "o")
                                                    .Replace("ù", "u")
                                                    .Replace("ú", "u")
                                                    .Replace("û", "u")
                                                    .Replace("ý", "y")
                                                    .Contains(name.ToLower()
                                                                    .Replace(" ", "")
                                                                    .Replace(".", "")
                                                                    .Replace(",", "")
                                                                    .Replace(";", "")
                                                                    .Replace(":", "")
                                                                    .Replace("?", "")
                                                                    .Replace("!", "")
                                                                    .Replace("-", "")
                                                                    .Replace("&", "")
                                                                    .Replace("'", "")
                                                                    .Replace("à", "a")
                                                                    .Replace("á", "a")
                                                                    .Replace("â", "a")
                                                                    .Replace("ç", "c")
                                                                    .Replace("è", "e")
                                                                    .Replace("é", "e")
                                                                    .Replace("ê", "e")
                                                                    .Replace("î", "i")
                                                                    .Replace("ò", "o")
                                                                    .Replace("ó", "o")
                                                                    .Replace("ô", "o")
                                                                    .Replace("ù", "u")
                                                                    .Replace("ú", "u")
                                                                    .Replace("û", "u")
                                                                    .Replace("ý", "y")))
                    .Include(a => a.Movies)
                    .ThenInclude(m => m.Comments);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public IQueryable<Actor> GetFavoriteActors(int index, int take, out int actorsCount)
        {
            IQueryable<Actor> actors = this._movieContext.DbActors
                .Include(a => a.Movies)
                .ThenInclude(b => b.Actors)
                .ThenInclude(b => b.Roles)
                .Where(a => a.Movies.Count >= 2)
                .OrderBy(a => a.Movies.Count);
            actorsCount = actors.Count();
            return actors.Skip(index * take)
                         .Take(take);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idMovie"></param>
        /// <param name="take"></param>
        /// <param name="actorsCount"></param>
        /// <returns></returns>
        public IQueryable<Actor> GetActorsByIdMovie(int idMovie, int index, int take, out int actorsCount)
        {
            IQueryable<Actor> actors = this._movieContext.DbActors
                       .Include(a => a.Movies)
                       .Include(a => a.Roles.Where(m => m.MovieId == idMovie))
                       .Where(a => a.Movies.Any(t => t.Id == idMovie));
            actorsCount = actors.Count();
            return actors.Skip(index * take)
                         .Take(take);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idActor"></param>
        /// <returns></returns>
        public Actor GetActorByIdActor(int idActor)
        {
            return this._movieContext.DbActors
                       .Include(a => a.Movies)
                       .Include(a => a.Roles)
                       .FirstOrDefault(a => a.Id == idActor);
        }
    }
    #endregion
}
