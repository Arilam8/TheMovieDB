
using BrowserApp.Models;
using BrowserApp.Models.Actors;
using BrowserApp.Models.Comments;
using DataTransferObject;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using Utils.APIUtils.Models;

namespace BrowserApp.Models
{
    public class FullMovieModel
    {
        #region MEMBER_VARIABLES
        private int _id;
        private string _title;
        private DateTime _releaseDate;
        private float _ratingTheMovieDB;
        private float _rating;
        private TimeSpan _runtime;
        private string _poster;
        private string _overview;
        private string _logo;
        private string _backdrop;
        private List<string> _movieTypes;
        private PaginationModel<LightActorModel> _paginationModelLightActorModel;
        private PaginationModel<CommentModel> _paginationModelCommentModel;
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
        public List<string> MovieTypes
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

        public PaginationModel<LightActorModel> PaginationModelLightActorModel
        {
            get { return _paginationModelLightActorModel; }
            set
            {
                if (_paginationModelLightActorModel != value)
                {
                    _paginationModelLightActorModel = value;
                }
            }
        }

        public PaginationModel<CommentModel> PaginationModelCommentModel
        {
            get { return _paginationModelCommentModel; }
            set
            {
                if (_paginationModelCommentModel != value)
                {
                    _paginationModelCommentModel = value;
                }
            }
        }
        #endregion

        #region BUILDERS
        public FullMovieModel()
        {
            Id = -1;
            Title = string.Empty;
            ReleaseDate = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            RatingTheMovieDB = 0;
            Rating = 0;
            Runtime = TimeSpan.FromMinutes(-1);
            Poster = string.Empty;
            Overview = string.Empty;
            Logo = string.Empty;
            Backdrop = string.Empty;
            MovieTypes = new List<string>();
            PaginationModelLightActorModel = new PaginationModel<LightActorModel>();
            PaginationModelCommentModel = new PaginationModel<CommentModel>();
        }

        public FullMovieModel(FullMovieDTO fullMovieDTO, PaginationModel<LightActorModel> paginationModelLightActorModel, PaginationModel<CommentModel> paginationModelCommentModel)
        {
            Id = fullMovieDTO.Id;
            Title = fullMovieDTO.Title;
            ReleaseDate = fullMovieDTO.ReleaseDate;
            RatingTheMovieDB = fullMovieDTO.RatingTheMovieDB;
            Rating = fullMovieDTO.Rating;
            Runtime = TimeSpan.FromMinutes(fullMovieDTO.Runtime);
            Poster = Utils.Constant.URL_IMAGE_THEMOVIEDB + fullMovieDTO.Poster;
            Overview = fullMovieDTO.Overview;
            Logo = !string.IsNullOrWhiteSpace(fullMovieDTO.Logo) ? Utils.Constant.URL_IMAGE_THEMOVIEDB + fullMovieDTO.Logo : null;
            Backdrop = Utils.Constant.URL_IMAGE_THEMOVIEDB + fullMovieDTO.Backdrop;
            MovieTypes = fullMovieDTO.MovieTypes.Select(c => c.Name).ToList();
            PaginationModelLightActorModel = paginationModelLightActorModel;
            PaginationModelCommentModel = paginationModelCommentModel;
        }
        #endregion
    }
}