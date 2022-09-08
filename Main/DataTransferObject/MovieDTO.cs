using System;
using System.Collections.Generic;
using System.Linq;

namespace DataTransferObject
{
    public class MovieDTO
    {
        #region MEMBER_VARIABLES
        private int _id;
        private string _title;
        private DateTime _releaseDate;
        private float _ratingTheMovieDB;
        private float _rating;
        private int _runtime;
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

        public int Runtime
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
        public MovieDTO()
        {
            Id = -1;
            Title = string.Empty;
            ReleaseDate = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            RatingTheMovieDB = 0;
            Rating = 0;
            Runtime = -1;
            Poster = string.Empty;
            Overview = string.Empty;
        }

        public MovieDTO(int id, string title, DateTime releaseDate, float rating, int runtime, string poster, ICollection<CommentDTO> comments)
        {
            Id = id;
            Title = title;
            ReleaseDate = releaseDate;
            RatingTheMovieDB = rating;
            Rating = GetAverageRateComments(comments);
            Runtime = runtime;
            Poster = poster;
            Overview = string.Empty;
        }
        #endregion

        #region METHODS
        //https://stackoverflow.com/questions/7238248/why-is-there-no-convert-tofloat-method
        private float GetAverageRateComments(ICollection<CommentDTO> commentDTOs)
        {
            float averageRate = 0;
            foreach (CommentDTO commentDTO in commentDTOs.Where(c => c.Valid == true))
                    averageRate += commentDTO.Rate;
            if (averageRate > 0)
                return Convert.ToSingle(Math.Round(averageRate / commentDTOs.Where(c => c.Valid == true).ToList().Count, 2));
            else
                return averageRate;
        }

        public override string ToString()
        {
            return "Id : " + Id + "\nTitle : " + Title + "\nRelease date : " + ReleaseDate + "\nRating (TheMovieDB) : " + RatingTheMovieDB + "\nRating : " + Rating + "\nRuntime : " + Runtime + "\nPoster : " + Poster;
        }
        #endregion
    }
}
