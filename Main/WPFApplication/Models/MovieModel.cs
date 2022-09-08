using DataTransferObject;
using System;
using System.Collections.Generic;

namespace WPFApplication.Models
{
    public class MovieModel : ModelBase
    {
        #region MEMBER_VARIABLES
        private int _id;
        private string _title;
        private string _overview;
        private DateTime _releaseDate;
        private float _ratingTheMovieDB;
        private float _rating;
        private TimeSpan _runtime;
        private byte[] _poster;
        private List<MovieTypeModel> _movieTypes;
        private bool _selection;
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
                    OnPropertyChanaged(nameof(Id));
                }
            }
        }

        public String Title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanaged(nameof(Title));
                }
            }
        }

        public String Overview
        {
            get { return _overview; }
            set
            {
                if (_overview != value)
                {
                    _overview = value;
                    OnPropertyChanaged(nameof(Overview));
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
                    OnPropertyChanaged(nameof(ReleaseDate));
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
                    OnPropertyChanaged(nameof(RatingTheMovieDB));
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
                    OnPropertyChanaged(nameof(Rating));
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
                    OnPropertyChanaged(nameof(Runtime));
                }
            }
        }

        public byte[] Poster
        {
            get { return _poster; }
            set
            {
                if (_poster != value)
                {
                    _poster = value;
                    OnPropertyChanaged(nameof(Poster));
                }
            }
        }

        public List<MovieTypeModel> MovieTypes
        {
            get { return _movieTypes; }
            set
            {
                if (_movieTypes != value)
                {
                    _movieTypes = value;
                    OnPropertyChanaged(nameof(MovieTypes));
                }
            }
        }

        public bool Selection
        {
            get { return _selection; }
            set
            {
                if (_selection != value)
                {
                    _selection = value;
                    OnPropertyChanaged(nameof(Selection));
                }
            }
        }
        #endregion

        #region BUILDERS
        public MovieModel()
        {
            Id = -1;
            Title = string.Empty;
            Overview = string.Empty;
            ReleaseDate = DateTime.Now;
            RatingTheMovieDB = 0;
            Rating = 0;
            Runtime = TimeSpan.FromMinutes(0);
            Poster = new byte[0];
            MovieTypes = new List<MovieTypeModel>();
            Selection = false;
        }

        public MovieModel(MovieDTO movieDTO, byte[] poster, List<MovieTypeDTO> movieTypeDTOs)
        {
            Id = movieDTO.Id;
            Title = movieDTO.Title;
            Overview = movieDTO.Overview;
            ReleaseDate = movieDTO.ReleaseDate;
            RatingTheMovieDB = movieDTO.RatingTheMovieDB/2;
            Rating = movieDTO.Rating;
            Runtime = TimeSpan.FromMinutes(movieDTO.Runtime);
            Poster = poster;
            MovieTypes = Utils.Utils.MovieTypeDTOsToMovieTypeModels(movieTypeDTOs);
            Selection = false;
        }
        #endregion
    }
}
