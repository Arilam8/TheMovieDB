using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WPFApplication.Models
{
    public class FullMovieModel : MovieModel
    {
        #region MEMBER_VARIABLES
        private byte[] _logo;
        private byte[] _backdrop;
        #endregion

        #region PROPERTIES
        public byte[] Logo
        {
            get { return _logo; }
            set
            {
                if (_logo != value)
                {
                    _logo = value;
                    OnPropertyChanaged(nameof(Logo));
                }
            }
        }

        public byte[] Backdrop
        {
            get { return _backdrop; }
            set
            {
                if (_backdrop != value)
                {
                    _backdrop = value;
                    OnPropertyChanaged(nameof(Backdrop));
                }
            }
        }
        #endregion

        #region BUILDERS
        public FullMovieModel()
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
            Logo = new byte[0];
            Backdrop = new byte[0];
        }

        public FullMovieModel(FullMovieDTO fullMovieDTO, byte[] poster, byte[] logo, byte[] backdrop)
        {
            Id = fullMovieDTO.Id;
            Title = fullMovieDTO.Title;
            Overview = fullMovieDTO.Overview;
            ReleaseDate = fullMovieDTO.ReleaseDate;
            RatingTheMovieDB = fullMovieDTO.RatingTheMovieDB/2;
            Rating = fullMovieDTO.Rating;
            Runtime = TimeSpan.FromMinutes(fullMovieDTO.Runtime);
            Poster = poster;
            MovieTypes = Utils.Utils.MovieTypeDTOsToMovieTypeModels(fullMovieDTO.MovieTypes.ToList());
            Logo = logo;
            Backdrop = backdrop;
        }
        #endregion
    }
}
