using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;

namespace WpfApp.Model
{
    public class FullMovieModel : FullMovieDTO
    {
        public FullMovieModel(FullMovieDTO f)
        {
            Id = f.Id;
            Title = f.Title;
            ReleaseDate = f.ReleaseDate;
            Rating = f.Rating;
            RatingTheMovieDB = f.RatingTheMovieDB;
            Runtime = f.Runtime;
            MovieTypes = f.MovieTypes;
            Poster = APIManager.GetPosterFromTMDB("https://image.tmdb.org/t/p/original" + f.Poster);
        }

        public BitmapImage Poster { get; set; }
    }
}
