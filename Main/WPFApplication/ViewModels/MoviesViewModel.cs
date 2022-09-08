using DataTransferObject;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Utils.APIUtils.Models;
using Utils.APIUtils;
using WPFApplication.Models;
using System.Windows;
using WPFApplication.Commands;
using WPFApplication.Views;
using System.ComponentModel;

namespace WPFApplication.ViewModels
{
    public class MoviesViewModel : INotifyPropertyChanged
    {
        #region MEMBER_VARIABLES
        private readonly ObservableCollection<MovieModel> _movies = new ObservableCollection<MovieModel>();
        private readonly List<string> _searchTypes = new List<string>() { Utils.Constant.SEARCH_TYPE_MOVIE_TITLE, Utils.Constant.SEARCH_TYPE_MOVIE_ACTOR };
        private MoviesView _moviesView;
        private APIResponseMultiplePagination<MovieDTO> _previousResponse;
        private APIResponseMultiplePagination<MovieDTO> _response;
        private int _currentAction;
        private bool _isLoadMovies;
        public ICommand SelectMovieCommand { get; }
        public ICommand MoreInformationMovieCommand { get; }
        public ICommand SearchMovieCommand { get; }
        public ICommand StopSearchMovieCommand { get; }
        public ICommand NavigationFirstPageMovieCommand { get; }
        public ICommand NavigationLastPageMovieCommand { get; }
        public ICommand NavigationNextPageMovieCommand { get; }
        public ICommand NavigationPreviousPageMovieCommand { get; }
        #endregion

        #region PROPERTIES
        public ObservableCollection<MovieModel> Movies
        {
            get { return _movies; }
        }

        public List<string> SearchTypes
        {
            get { return _searchTypes; }
        }

        public MoviesView MoviesView
        {
            get { return _moviesView; }
            set
            {
                if (_moviesView != value)
                {
                    _moviesView = value;
                    OnPropertyChanaged(nameof(MoviesView));
                }
            }
        }

        public APIResponseMultiplePagination<MovieDTO> PreviousResponse
        {
            get { return _previousResponse; }
            set
            {
                if (_previousResponse != value)
                {
                    _previousResponse = value;
                    OnPropertyChanaged(nameof(PreviousResponse));
                }
            }
        }

        public APIResponseMultiplePagination<MovieDTO> Response
        {
            get { return _response; }
            set
            {
                if (_response != value)
                {
                    _response = value;
                    OnPropertyChanaged(nameof(Response));
                }
            }
        }

        public int CurrentAction
        {
            get { return _currentAction; }
            set
            {
                if (_currentAction != value)
                {
                    _currentAction = value;
                    OnPropertyChanaged(nameof(CurrentAction));
                }
            }
        }

        public bool IsLoadMovies
        {
            get { return _isLoadMovies; }
            set
            {
                if (_isLoadMovies != value)
                {
                    _isLoadMovies = value;
                    OnPropertyChanaged(nameof(IsLoadMovies));
                }
            }
        }
        #endregion

        #region BUILDERS
        public MoviesViewModel(MoviesView moviesView)
        {
            MoviesView = moviesView;
            SelectMovieCommand = new SelectMovieCommand(this);
            MoreInformationMovieCommand = new MoreInformationMovieCommand(this);
            SearchMovieCommand = new SearchMovieCommand(this);
            StopSearchMovieCommand = new StopSearchMovieCommand(this);
            NavigationFirstPageMovieCommand = new NavigationFirstPageMovieCommand(this);
            NavigationLastPageMovieCommand = new NavigationLastPageMovieCommand(this);
            NavigationNextPageMovieCommand = new NavigationNextPageMovieCommand(this);
            NavigationPreviousPageMovieCommand = new NavigationPreviousPageMovieCommand(this);
            LoadInitialMovies();
        }
        #endregion

        #region METHODS
        public async Task FirstPage()
        {
            CurrentAction = Utils.Constant.METHOD_FIRST_PAGE;
            IsLoadMovies = true;
            Utils.Utils.DisplayLoading(MoviesView.Frame, 1);
            Movies.Clear();
            MoviesView.InformationBT.IsEnabled = false;
            Response = await WebAPIManager.GetListMoviesFromUrlAsync(PreviousResponse.FirstPage);
            if (Response.Succeeded)
            {
                await Utils.Utils.MovieDTOsToMovieModelsAsync(Movies, Response.Datas.ToList());
                PreviousResponse = Response;
                await Task.Delay(2000);
                Utils.Utils.CollapsedFrame(MoviesView.Frame);
                IsLoadMovies = false;
            }
            else
                Utils.Utils.DisplayError(MoviesView.Frame, 2, this, null);
        }

        public async Task LastPage()
        {
            CurrentAction = Utils.Constant.METHOD_LAST_PAGE;
            IsLoadMovies = true;
            Utils.Utils.DisplayLoading(MoviesView.Frame, 1);
            Movies.Clear();
            MoviesView.InformationBT.IsEnabled = false;
            Response = await WebAPIManager.GetListMoviesFromUrlAsync(PreviousResponse.LastPage);
            if (Response.Succeeded)
            {
                await Utils.Utils.MovieDTOsToMovieModelsAsync(Movies, Response.Datas.ToList());
                PreviousResponse = Response;
                await Task.Delay(2000);
                Utils.Utils.CollapsedFrame(MoviesView.Frame);
                IsLoadMovies = false;
            }
            else
                Utils.Utils.DisplayError(MoviesView.Frame, 2, this, null);
        }

        public async Task NextPage()
        {
            CurrentAction = Utils.Constant.METHOD_NEXT_PAGE;
            IsLoadMovies = true;
            Utils.Utils.DisplayLoading(MoviesView.Frame, 1);
            Movies.Clear();
            MoviesView.InformationBT.IsEnabled = false;
            Response = await WebAPIManager.GetListMoviesFromUrlAsync(PreviousResponse.NextPage);
            if (Response.Succeeded)
            {
                await Utils.Utils.MovieDTOsToMovieModelsAsync(Movies, Response.Datas.ToList());
                PreviousResponse = Response;
                await Task.Delay(2000);
                Utils.Utils.CollapsedFrame(MoviesView.Frame);
                IsLoadMovies = false;
            }
            else
                Utils.Utils.DisplayError(MoviesView.Frame, 2, this, null);
        }

        public async Task PreviousPage()
        {
            CurrentAction = Utils.Constant.METHOD_PREVIOUS_PAGE;
            IsLoadMovies = true;
            Utils.Utils.DisplayLoading(MoviesView.Frame, 1);
            Movies.Clear();
            MoviesView.InformationBT.IsEnabled = false;
            Response = await WebAPIManager.GetListMoviesFromUrlAsync(PreviousResponse.PreviousPage);
            if (Response.Succeeded)
            {
                await Utils.Utils.MovieDTOsToMovieModelsAsync(Movies, Response.Datas.ToList());
                PreviousResponse = Response;
                await Task.Delay(2000);
                Utils.Utils.CollapsedFrame(MoviesView.Frame);
                IsLoadMovies = false;
            }
            else
                Utils.Utils.DisplayError(MoviesView.Frame, 2, this, null);
        }

        public void SelectMovie(MovieModel movieModel)
        {
            if (Movies.Where(m => m.Selection).Count() >= 1)
            {
                movieModel.Selection = !movieModel.Selection;
                foreach (MovieModel movieModels in Movies.Where(m => m.Selection))
                {
                    if (movieModels.Id != movieModel.Id)
                        movieModels.Selection = false;
                }
            }
            else
                movieModel.Selection = true;
            MoviesView.InformationBT.IsEnabled = Movies.Where(m => m.Selection).Count() == 1 ? true : false;
        }

        public void MoreInformationMovie()
        {
            bool moreInformation = true;
            foreach (MovieModel movieModel in Movies.Where(m => m.Selection))
            {
                if(moreInformation)
                {
                    FullMovieView fullMovieView = new FullMovieView(movieModel.Id);
                    fullMovieView.ShowDialog();
                    moreInformation = false;
                }
                movieModel.Selection = false;
            }
            MoviesView.InformationBT.IsEnabled = false;
        }

        public async Task LoadInitialMovies()
        {
            CurrentAction = Utils.Constant.METHOD_LOAD_INITIAL_MOVIES;
            IsLoadMovies = true;
            Utils.Utils.DisplayLoading(MoviesView.Frame, 1);
            Movies.Clear();
            MoviesView.InformationBT.IsEnabled = false;
            Response = await WebAPIManager.GetListMoviesOrderByReleaseDateAsync(1, Utils.Constant.PAGE_COUNT);
            if(Response.Succeeded)
            {
                await Utils.Utils.MovieDTOsToMovieModelsAsync(Movies, Response.Datas.ToList());
                PreviousResponse = Response;
                await Task.Delay(2000);
                Utils.Utils.CollapsedFrame(MoviesView.Frame);
                IsLoadMovies = false;
            }
            else
                Utils.Utils.DisplayError(MoviesView.Frame, 2, this, null);
        }

        public async Task SearchMovies()
        {
            CurrentAction = Utils.Constant.METHOD_SEARCH_MOVIES;
            IsLoadMovies = true;
            Utils.Utils.DisplayLoading(MoviesView.Frame, 1);
            Movies.Clear();
            MoviesView.InformationBT.IsEnabled = false;
            MoviesView.BackButtonBT.Visibility = Visibility.Visible;
            MoviesView.TitlePageTBK.Visibility = Visibility.Hidden;
            Response = new APIResponseMultiplePagination<MovieDTO>();
            switch (MoviesView.SearchTypesCB.SelectedValue.ToString())
            {
                case Utils.Constant.SEARCH_TYPE_MOVIE_TITLE:
                    Response = await WebAPIManager.FindListMovieByPartialMovieTitleAsync(MoviesView.SearchMovieTBX.Text, 1, Utils.Constant.PAGE_COUNT);
                    break;
                case Utils.Constant.SEARCH_TYPE_MOVIE_ACTOR:
                    Response = await WebAPIManager.FindListMovieByPartialActorNameAsync(MoviesView.SearchMovieTBX.Text, 1, Utils.Constant.PAGE_COUNT);
                    break;
            }
            if (Response.Succeeded)
            {
                if(Response.Datas.Count > 0)
                {
                    await Utils.Utils.MovieDTOsToMovieModelsAsync(Movies, Response.Datas.ToList());
                    PreviousResponse = Response;
                    await Task.Delay(2000);
                    Utils.Utils.CollapsedFrame(MoviesView.Frame);
                    IsLoadMovies = false;
                }
                else
                    Utils.Utils.DisplayNoResult(MoviesView.Frame, 2);
            }
            else
            {
                MoviesView.TitlePageTBK.Visibility = Visibility.Visible;
                MoviesView.BackButtonBT.Visibility = Visibility.Hidden;
                Utils.Utils.DisplayError(MoviesView.Frame, 2, this, null);
            }
        }

        public async Task StopSearchMovie()
        {
            MoviesView.TitlePageTBK.Visibility = Visibility.Visible;
            MoviesView.BackButtonBT.Visibility = Visibility.Hidden;
            MoviesView.SearchMovieTBX.Text = "";
            await LoadInitialMovies();
        }
        #endregion

        #region NOTIFYPROPERTYCHANGED
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanaged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
