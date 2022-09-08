using System;
using System.Collections.Generic;

namespace DataTransferObject
{
    public class FullMovieDTO : MovieDTO
    {
        #region MEMBER_VARIABLES
        private string _logo;
        private string _backdrop;
        private ICollection<MovieTypeDTO> _movieTypes;
        #endregion

        #region PROPERTIES
        public string Logo
        {
            get { return _logo; }
            set
            {
                if (_logo != value)
                {
                    _logo = value;
                }
            }
        }

        public string Backdrop
        {
            get { return _backdrop; }
            set
            {
                if (_backdrop != value)
                {
                    _backdrop = value;
                }
            }
        }

        public virtual ICollection<MovieTypeDTO> MovieTypes
        {
            get { return _movieTypes; }
            set
            {
                if (_movieTypes != value)
                {
                    _movieTypes = value;
                }
            }
        }
        #endregion

        #region BUILDERS
        public FullMovieDTO() : base()
        {
            Logo = string.Empty;
            Backdrop = string.Empty;
            MovieTypes = new List<MovieTypeDTO>();
        }

        public FullMovieDTO(int id, string title, DateTime releaseDate, float rating, int runtime, string poster, ICollection<CommentDTO> comments, ICollection<MovieTypeDTO> movieTypes) : base(id, title, releaseDate, rating, runtime, poster, comments)
        {
            Logo = string.Empty;
            Backdrop = string.Empty;
            MovieTypes = movieTypes;
        }
        #endregion

        #region METHODS
        public override string ToString()
        {
            string toString = "Id : " + Id + "\nTitle : " + Title + "\nRelease date : " + ReleaseDate + "\nRating (TheMovieDB) : " + RatingTheMovieDB + "\nRating : " + Rating + "\nRuntime : " + Runtime + "\nPoster : " + Poster;
            if (MovieTypes != null && MovieTypes.Count > 0)
            {
                toString += "\nType(s) :";
                foreach (MovieTypeDTO movieType in MovieTypes)
                    toString += "\n\t- " + movieType.ToString();
            }
            return toString;
        }
        #endregion
    }
}
