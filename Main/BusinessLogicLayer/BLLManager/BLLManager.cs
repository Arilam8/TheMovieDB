using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;

namespace BusinessLogicLayer.BLLManager
{
    public class BLLManager : IDisposable
    {
        #region MEMBER_VARIABLES
        private MovieManager _movieManager;
        #endregion

        #region BUILDERS
        public BLLManager()
        {
            _movieManager = new MovieManager();
        }
        #endregion

        #region METHODS
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            _movieManager.Dispose();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idMovie"></param>
        /// <returns></returns>
        public bool IsExistMovie(int idMovie)
        {
            return _movieManager.IsExistMovie(idMovie);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idMovieType"></param>
        /// <returns></returns>
        public bool IsExistType(int idMovieType)
        {
            return _movieManager.IsExistType(idMovieType);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idComment"></param>
        /// <returns></returns>
        public bool IsExistComment(int idComment)
        {
            return _movieManager.IsExistComment(idComment);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idActor"></param>
        /// <returns></returns>
        public bool IsExistActor(int idActor)
        {
            return _movieManager.IsExistActor(idActor);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public IList<MovieDTO> GetListMoviesOrderByReleaseDate(int index, int take, out int moviesCount)
        {
            return Utils.Utils.MoviesToMovieDTOs(_movieManager.GetMoviesOrderByReleaseDate(index, take, out moviesCount).ToList());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idMovie"></param>
        /// <returns></returns>
        public FullMovieDTO GetFullMovieDetailsByIdMovie(int idMovie)
        {
            return Utils.Utils.MovieToFullMovieDTO(_movieManager.GetFullMovieByIdMovie(idMovie));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idMovie"></param>
        /// <param name="newPoster"></param>
        /// <returns></returns>
        public bool UpdatePosterMovie(int idMovie, string newPoster)
        {
            bool update = false;
            Movie movie = _movieManager.GetMovieByIdMovie(idMovie);
            if (movie != null && movie.Id != -1)
            {
                movie.Poster = newPoster;
                update = _movieManager.UpdateMovie(movie);
            }
            return update;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idMovie"></param>
        /// <returns></returns>
        public IList<MovieTypeDTO> GetListMovieTypesByIdMovie(int idMovie)
        {
            return Utils.Utils.TypesToMovieTypeDTOs(_movieManager.GetTypesByIdMovie(idMovie).ToList());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idActor"></param>
        /// <returns></returns>
        public ActorDTO GetActorByIdActor(int idActor)
        {
            return Utils.Utils.ActorToActorDTO(_movieManager.GetActorByIdActor(idActor));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idMovie"></param>
        /// <param name="index"></param>
        /// <param name="take"></param>
        /// <param name="actorsCount"></param>
        /// <returns></returns>
        public IList<LightActorDTO> GetListActorsByIdMovie(int idMovie, int index, int take, out int actorsCount)
        {
            return Utils.Utils.ActorsToLightActorDTOs(_movieManager.GetActorsByIdMovie(idMovie, index, take, out actorsCount).ToList());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public IList<ActorDTO> GetFavoriteActors(int index, int take, out int actorsCount)
        {
            return Utils.Utils.ActorsToActorDTOs(_movieManager.GetFavoriteActors(index, take, out actorsCount).ToList());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commentDTOs"></param>
        /// <returns></returns>
        public IList<CommentDTO> GetComments(IList<CommentDTO> commentDTOs)
        {
            return commentDTOs.Where(c => c.Valid == true).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idMovie"></param>
        /// <param name="index"></param>
        /// <param name="take"></param>
        /// <param name="commentsCount"></param>
        /// <param name="invalidComment"></param>
        /// <returns></returns>
        public IList<CommentDTO> GetListCommentsByIdMovie(int idMovie, int index, int take, out int commentsCount, bool invalidComment)
        {
            return Utils.Utils.CommentsToCommentDTOs(_movieManager.GetListCommentsByIdMovie(idMovie, invalidComment, index, take, out commentsCount).ToList());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idComment"></param>
        /// <returns></returns>
        public CommentDTO GetCommentByIdComment(int idComment)
        {
            return Utils.Utils.CommentToCommentDTO(_movieManager.GetCommentByIdComment(idComment));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idMovie"></param>
        /// <param name="commentDTO"></param>
        /// <param name="commentDTOInserted"></param>
        /// <returns></returns>
        public bool InsertCommentOnIdMovie(int idMovie, CommentDTO commentDTO, out CommentDTO commentDTOInserted)
        {
            bool insert = false;
            Comment commentInserted = new Comment();
            Movie movie = _movieManager.GetMovieByIdMovie(idMovie);
            if (movie != null && movie.Id != -1)
                 insert = _movieManager.UpdateComment(new Comment(movie, commentDTO.Date, commentDTO.Rate, commentDTO.Content, commentDTO.Username), out commentInserted);
            commentDTOInserted = Utils.Utils.CommentToCommentDTO(commentInserted);
            return insert;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idComment"></param>
        /// <param name="commentDTO"></param>
        /// <returns></returns>
        public bool ModifyCommentByIdComment(int idComment, CommentDTO commentDTO)
        {
            Comment comment = _movieManager.GetCommentByIdComment(idComment);
            if (comment != null && comment.Id != -1)
            {
                comment.Username = commentDTO.Username;
                comment.Content = commentDTO.Content;
                comment.Rate = commentDTO.Rate;
                comment.Date = DateTime.Now;
                comment.Valid = commentDTO.Valid;
                return _movieManager.UpdateComment(comment);
            }
            else return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idComment"></param>
        /// <returns></returns>
        public bool DeleteCommentByIdComment(int idComment)
        {
            Comment comment = _movieManager.GetCommentByIdComment(idComment);
            if (comment != null && comment.Id != -1)
                return _movieManager.DeleteComment(comment);
            else return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idComment"></param>
        /// <returns></returns>
        public bool ValidateCommentByIdComment(int idComment)
        {
            Comment comment = _movieManager.GetCommentByIdComment(idComment);
            if (comment == null)
                return false;
            if (comment.Valid)
                return true;
            else
            {
                comment.Valid = true;
                return _movieManager.UpdateComment(comment);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idComment"></param>
        /// <returns></returns>
        public bool InvalidateCommentByIdComment(int idComment)
        {
            Comment comment = _movieManager.GetCommentByIdComment(idComment);
            if (comment == null)
                return false;
            if (!comment.Valid)
                return true;
            else
            {
                comment.Valid = false;
                return _movieManager.UpdateComment(comment);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="index"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public IList<MovieDTO> FindListMovieByPartialMovieTitle(string title, int index, int take, out int moviesCount)
        {
            if(string.IsNullOrWhiteSpace(title))
            {
                return GetListMoviesOrderByReleaseDate(index, take, out moviesCount);
            }
            IList<int> idMoviesFirst = new List<int>();
            IList<int> idMoviesSecond = new List<int>();
            IList<KeyValuePair<int, int>> pertinenceMovies = new List<KeyValuePair<int, int>>();
            string[] titleSplits = title.Split('|');
            foreach (string titleSplit in titleSplits)
            {
                if(!string.IsNullOrWhiteSpace(titleSplit))
                { 
                    List<string> filter = new List<string>();
                    if (titleSplit.Contains("AND"))
                    {
                        filter = titleSplit.Split("AND").ToList();
                    }
                    if (titleSplit.Contains("OR"))
                    {
                        filter = titleSplit.Split("OR").ToList();
                    }
                    if (titleSplit.Contains("NOT"))
                    {
                        filter = titleSplit.Split("NOT").ToList();
                    }
                    if (titleSplit.Contains("AND") || titleSplit.Contains("OR") || titleSplit.Contains("NOT"))
                    {
                        if (filter.Count <= 0 || (string.IsNullOrWhiteSpace(filter[0]) && (titleSplit.Contains("AND") || titleSplit.Contains("OR"))) || string.IsNullOrWhiteSpace(filter[1]))
                        {
                            if (!string.IsNullOrWhiteSpace(filter[0]) && string.IsNullOrWhiteSpace(filter[1]))
                                return FindListMovieByPartialMovieTitle(filter[0], index, take, out moviesCount);
                            if (string.IsNullOrWhiteSpace(filter[0]) && !string.IsNullOrWhiteSpace(filter[1]))
                                return FindListMovieByPartialMovieTitle(filter[1], index, take, out moviesCount);
                            return GetListMoviesOrderByReleaseDate(index, take, out moviesCount);
                        }
                        if (titleSplit.Contains("AND"))
                        {
                            idMoviesFirst = Utils.Utils.GetIdMoviesMovie(_movieManager.GetMoviesByPartialOrEntirelyTitle(filter[0]).ToList(), new List<int>());
                            idMoviesSecond = Utils.Utils.GetIdMoviesMovie(_movieManager.GetMoviesByPartialOrEntirelyTitle(filter[1]).ToList(), new List<int>());
                            pertinenceMovies = Utils.Utils.GetPertinenceMovies(idMoviesFirst.Intersect(idMoviesSecond).ToList(), pertinenceMovies);
                        }
                        if (titleSplit.Contains("OR"))
                        {
                            idMoviesFirst = Utils.Utils.GetIdMoviesMovie(_movieManager.GetMoviesByPartialOrEntirelyTitle(filter[0]).ToList(), new List<int>());
                            idMoviesFirst = Utils.Utils.GetIdMoviesMovie(_movieManager.GetMoviesByPartialOrEntirelyTitle(filter[1]).ToList(), idMoviesFirst);
                            pertinenceMovies = Utils.Utils.GetPertinenceMovies(idMoviesFirst, pertinenceMovies);
                        }
                        if (titleSplit.Contains("NOT"))
                        {
                            idMoviesFirst = _movieManager.GetMoviesOrderByTitle().Select(m => m.Id).ToList();
                            idMoviesSecond = Utils.Utils.GetIdMoviesMovie(_movieManager.GetMoviesByPartialOrEntirelyTitle(filter[1]).ToList(), new List<int>());
                            pertinenceMovies = Utils.Utils.GetPertinenceMoviesWithNOT(idMoviesFirst, idMoviesSecond, pertinenceMovies);
                        }
                    }
                    else
                    {
                        idMoviesFirst = Utils.Utils.GetIdMoviesMovie(_movieManager.GetMoviesByPartialOrEntirelyTitle(titleSplit).ToList(), new List<int>());
                        pertinenceMovies = Utils.Utils.GetPertinenceMovies(idMoviesFirst, pertinenceMovies);
                    }
                }
            }
            moviesCount = pertinenceMovies.Count;
            return Utils.Utils.SortMovieDTOs(Utils.Utils.MoviesToMovieDTOs(_movieManager.GetMoviesByIdMovies(pertinenceMovies.OrderByDescending(m => m.Value).Select(m => m.Key).ToList().Skip(index * take).Take(take).ToList()).ToList()), pertinenceMovies.OrderByDescending(m => m.Value).Select(m => m.Key).ToList());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="index"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public IList<MovieDTO> FindListMovieByPartialActorName(string name, int index, int take, out int moviesCount)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return GetListMoviesOrderByReleaseDate(index, take, out moviesCount);
            }
            IList<int> idMoviesFirst = new List<int>();
            IList<int> idMoviesSecond = new List<int>();
            IList<KeyValuePair<int, int>> pertinenceMovies = new List<KeyValuePair<int, int>>();
            string[] nameSplits = name.Split('|');
            foreach (string nameSplit in nameSplits)
            {
                if(!string.IsNullOrWhiteSpace(nameSplit))
                {
                    List<string> filter = new List<string>();
                    if (nameSplit.Contains("AND"))
                    {
                        filter = nameSplit.Split("AND").ToList();
                    }
                    if(nameSplit.Contains("OR"))
                    {
                        filter = nameSplit.Split("OR").ToList();
                    }
                    if(nameSplit.Contains("NOT"))
                    {
                        filter = nameSplit.Split("NOT").ToList();
                    }
                    if (nameSplit.Contains("AND") || nameSplit.Contains("OR") || nameSplit.Contains("NOT"))
                    {
                        if(filter.Count <= 0 || (string.IsNullOrWhiteSpace(filter[0]) && (nameSplit.Contains("AND") || nameSplit.Contains("OR"))) || string.IsNullOrWhiteSpace(filter[1]))
                        {
                            if (!string.IsNullOrWhiteSpace(filter[0]) && string.IsNullOrWhiteSpace(filter[1]))
                                return FindListMovieByPartialActorName(filter[0], index, take, out moviesCount);
                            if (string.IsNullOrWhiteSpace(filter[0]) && !string.IsNullOrWhiteSpace(filter[1]))
                                return FindListMovieByPartialActorName(filter[1], index, take, out moviesCount);
                            return GetListMoviesOrderByReleaseDate(index, take, out moviesCount);
                        }
                        if (nameSplit.Contains("AND"))
                        {
                            idMoviesFirst = Utils.Utils.GetIdMoviesActor(_movieManager.GetActorsByPartialOrEntirelyName(filter[0]).ToList(), new List<int>());
                            idMoviesSecond = Utils.Utils.GetIdMoviesActor(_movieManager.GetActorsByPartialOrEntirelyName(filter[1]).ToList(), new List<int>());
                            pertinenceMovies = Utils.Utils.GetPertinenceMovies(idMoviesFirst.Intersect(idMoviesSecond).ToList(), pertinenceMovies);
                        }
                        if (nameSplit.Contains("OR"))
                        {
                            idMoviesFirst = Utils.Utils.GetIdMoviesActor(_movieManager.GetActorsByPartialOrEntirelyName(filter[0]).ToList(), new List<int>());
                            idMoviesFirst = Utils.Utils.GetIdMoviesActor(_movieManager.GetActorsByPartialOrEntirelyName(filter[1]).ToList(), idMoviesFirst);
                            pertinenceMovies = Utils.Utils.GetPertinenceMovies(idMoviesFirst, pertinenceMovies);
                        }
                        if (nameSplit.Contains("NOT"))
                        {
                            idMoviesFirst = _movieManager.GetMoviesOrderByTitle().Select(m => m.Id).ToList();
                            idMoviesSecond = Utils.Utils.GetIdMoviesActor(_movieManager.GetActorsByPartialOrEntirelyName(filter[1]).ToList(), new List<int>());
                            pertinenceMovies = Utils.Utils.GetPertinenceMoviesWithNOT(idMoviesFirst, idMoviesSecond, pertinenceMovies);
                        }
                    }
                    else
                    {
                        idMoviesFirst = Utils.Utils.GetIdMoviesActor(_movieManager.GetActorsByPartialOrEntirelyName(nameSplit).ToList(), new List<int>());
                        pertinenceMovies = Utils.Utils.GetPertinenceMovies(idMoviesFirst, pertinenceMovies);
                    }
                }
            }
            moviesCount = pertinenceMovies.Count;
            return Utils.Utils.SortMovieDTOs(Utils.Utils.MoviesToMovieDTOs(_movieManager.GetMoviesByIdMovies(pertinenceMovies.OrderByDescending(m => m.Value).Select(m => m.Key).ToList().Skip(index * take).Take(take).ToList()).ToList()), pertinenceMovies.OrderByDescending(m => m.Value).Select(m => m.Key).ToList());
        }
        #endregion
    }
}
