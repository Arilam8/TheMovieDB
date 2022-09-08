using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Utils.APIUtils;
using Utils.APIUtils.Models;
using WpfApp.Model;

namespace WpfApp.ViewModel
{
    public class MovieViewModel
    {

        public ObservableCollection<MovieModel> _dataSource { get; }
        private string _title;

        private int _index = 1;
        public MovieViewModel()
        {
            _dataSource = new ObservableCollection<MovieModel>();
            StopResearchAsync();
        }

        public async Task SearchMovieAsync(string title)
        {
            if (title == "" || title == null)
                StopResearchAsync();
            else
            {
                if (_title != title)
                {
                    _title = title;

                    IList<MovieDTO> ourListOfMovies = new List<MovieDTO>();
                    Console.WriteLine("Title : " + _title);
                    APIResponseMultiplePagination<MovieDTO> response = await WebAPIManager.FindListMovieByPartialMovieTitleAsync(_title, 1, 10000);
                    ourListOfMovies = response.Datas;
                    UpdateDataAsync(ourListOfMovies);
                }
            }
        }
        public async Task StopResearchAsync()
        {
            _title = null;

            IList<MovieDTO> ourListOfMovies;
            APIResponseMultiplePagination<MovieDTO> response = await WebAPIManager.GetListMoviesOrderByReleaseDateAsync(_index, 5);
            ourListOfMovies = response.Datas;
            UpdateDataAsync(ourListOfMovies);
        }

        public async Task GetNextPageAsync()
        {
            IList<MovieDTO> lf;
            APIResponseMultiplePagination<MovieDTO> response = await WebAPIManager.GetListMoviesOrderByReleaseDateAsync(++_index, 5);
            lf = response.Datas;

            UpdateDataAsync(lf);
        }

        public async Task GetPreviousPageAsync()
        {
            IList<MovieDTO> lf;
            _index -= 1;
            if (_index < 1)
                _index = 1;
            APIResponseMultiplePagination<MovieDTO> response = await WebAPIManager.GetListMoviesOrderByReleaseDateAsync(_index, 5);
            lf = response.Datas;

            UpdateDataAsync(lf);
        }

        private async Task UpdateDataAsync(IList<MovieDTO> ourListOfMovies)
        {
            _dataSource.Clear(); // Clear the interface

            if(ourListOfMovies != null)
            {
                foreach (var f in ourListOfMovies)
                {
                    var tmp = new MovieModel(f);
                    APIResponseMultiple<MovieTypeDTO> response = await WebAPIManager.GetListMovieTypesByIdMovieAsync(tmp.Id);
                    IList<MovieTypeDTO> lft = response.Datas;
                    foreach (MovieTypeDTO ft in lft)
                    {
                        tmp.MovieType.Add(APIManager.GetFilmTypeIconFromData(ft.Name));
                    }

                    _dataSource.Add(tmp);
                }
            }
        }

        
    }
}
