using DataTransferObject;
using System;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfApp.Model
{
    public class MovieModel
    {

        static string _key = "8e5ee976a1e9057022a3e4eb85854f1a";
        static string _host = "http://localhost:44331/";
        static string _hostTMDB = "https://api.themoviedb.org/3/movie/";
        static string _hostPoster = "https://image.tmdb.org/t/p/original";

        public MovieModel(MovieDTO ourMovie)
        {
            Id = ourMovie.Id;
            Title = ourMovie.Title;
            ReleaseDate = ourMovie.ReleaseDate;
            Rating = ourMovie.Rating;
            RatingTheMovieDB = ourMovie.RatingTheMovieDB;
            int min = ourMovie.Runtime % 60;
            int hours = ourMovie.Runtime / 60;
            Runtime = hours.ToString() + "h" + min.ToString();
            Poster = APIManager.GetPosterFromTMDB(_hostPoster + ourMovie.Poster);

            MovieType = new List<BitmapImage>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public float Rating { get; set; }
        public float RatingTheMovieDB { get; set; }
        public string Runtime { get; set; }
        public BitmapImage Poster { get; set; }
        public List<BitmapImage> MovieType { get; set; }
    }
}
