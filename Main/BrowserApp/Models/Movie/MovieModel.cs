using DataTransferObject;
using System;
using System.Configuration;

namespace BrowserApp.Models
{
    public class MovieModel
    {
        #region MEMBER_VARIABLES
        private int _id;
        private string _title;
        private DateTime _releaseDate;
        private float _ratingTheMovieDB;
        private string _ratingTheMovieDBStar;
        private float _rating;
        private string _ratingStar;
        private TimeSpan _runtime;
        private string _poster;
        private string _overview;
        #endregion

        #region PROPERTIES
        public int Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                }
            }
        }

        public string Title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    _title = value;
                }
            }
        }

        public DateTime ReleaseDate
        {
            get { return _releaseDate; }
            set
            {
                if (_releaseDate != value)
                {
                    _releaseDate = value;
                }
            }
        }

        public float RatingTheMovieDB
        {
            get { return _ratingTheMovieDB; }
            set
            {
                if (_ratingTheMovieDB != value)
                {
                    _ratingTheMovieDB = value;
                }
            }
        }

        public string RatingTheMovieDBStar
        {
            get { return _ratingTheMovieDBStar; }
            set
            {
                if (_ratingTheMovieDBStar != value)
                {
                    _ratingTheMovieDBStar = value;
                }
            }
        }

        public float Rating
        {
            get { return _rating; }
            set
            {
                if (_rating != value)
                {
                    _rating = value;
                }
            }
        }

        public string RatingStar
        {
            get { return _ratingStar; }
            set
            {
                if (_ratingStar != value)
                {
                    _ratingStar = value;
                }
            }
        }

        public TimeSpan Runtime
        {
            get { return _runtime; }
            set
            {
                if (_runtime != value)
                {
                    _runtime = value;
                }
            }
        }

        public string Poster
        {
            get { return _poster; }
            set
            {
                if (_poster != value)
                {
                    _poster = value;
                }
            }
        }

        public string Overview
        {
            get { return _overview; }
            set
            {
                if (_overview != value)
                {
                    _overview = value;
                }
            }
        }
        #endregion

        #region BUILDERS
        public MovieModel()
        {
            Id = -1;
            Title = string.Empty;
            ReleaseDate = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            RatingTheMovieDB = 0;
            RatingTheMovieDBStar = string.Empty;
            Rating = 0;
            RatingStar = string.Empty;
            Runtime = TimeSpan.FromMinutes(0);
            Poster = string.Empty;
            Overview = string.Empty;
        }

        public MovieModel(MovieDTO movieDTO)
        {
            Id = movieDTO.Id;
            Title = movieDTO.Title;
            ReleaseDate = movieDTO.ReleaseDate;
            RatingTheMovieDB = movieDTO.RatingTheMovieDB / 2;
            RatingTheMovieDBStar = Utils.Utils.RatingToStar(RatingTheMovieDB);
            Rating = movieDTO.Rating;
            RatingStar = Utils.Utils.RatingToStar(Rating);
            Runtime = TimeSpan.FromMinutes(movieDTO.Runtime);
            Poster = ConfigurationManager.AppSettings["HostPosters"] + movieDTO.Poster;
            Overview = movieDTO.Overview;
        }
        #endregion
    }
}