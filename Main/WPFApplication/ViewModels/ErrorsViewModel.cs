using System.Windows.Input;
using WPFApplication.Commands;
using WPFApplication.Views;
using System.ComponentModel;

namespace WPFApplication.ViewModels
{
    public class ErrorsViewModel : INotifyPropertyChanged
    {
        #region MEMBER_VARIABLES
        private ErrorsView _errorsView;
        private int _contextError;
        private MoviesViewModel _moviesViewModel;
        private FullMovieViewModel _fullmovieViewModel;
        public ICommand RetryErrorCommand { get; }
        #endregion

        #region PROPERTIES
        public ErrorsView ErrorsView
        {
            get { return _errorsView; }
            set
            {
                if (_errorsView != value)
                {
                    _errorsView = value;
                    OnPropertyChanaged(nameof(ErrorsView));
                }
            }
        }

        public int ContextError
        {
            get { return _contextError; }
            set
            {
                if (_contextError != value)
                {
                    _contextError = value;
                    OnPropertyChanaged(nameof(ContextError));
                }
            }
        }

        public MoviesViewModel MoviesViewModel
        {
            get { return _moviesViewModel; }
            set
            {
                if (_moviesViewModel != value)
                {
                    _moviesViewModel = value;
                    OnPropertyChanaged(nameof(MoviesViewModel));
                }
            }
        }

        public FullMovieViewModel FullMovieViewModel
        {
            get { return _fullmovieViewModel; }
            set
            {
                if (_fullmovieViewModel != value)
                {
                    _fullmovieViewModel = value;
                    OnPropertyChanaged(nameof(FullMovieViewModel));
                }
            }
        }
        #endregion

        #region BUILDERS
        public ErrorsViewModel(ErrorsView errorView, MoviesViewModel moviesViewModel, FullMovieViewModel fullMovieViewModel)
        {
            ErrorsView = errorView;
            if(moviesViewModel != null)
            {
                ContextError = Utils.Constant.MOVIES_VIEW_MODEL_CONTEXT_ERROR;
                MoviesViewModel = moviesViewModel;
            }
            else
            {
                ContextError = Utils.Constant.FULL_MOVIE_VIEW_MODEL_CONTEXT_ERROR;
                FullMovieViewModel = fullMovieViewModel;
            }
            RetryErrorCommand = new RetryErrorCommand(this);
        }
        #endregion

        #region METHODS
        public void Retry()
        {
            if(ContextError == Utils.Constant.MOVIES_VIEW_MODEL_CONTEXT_ERROR)
            {
                switch(MoviesViewModel.CurrentAction)
                {
                    case Utils.Constant.METHOD_FIRST_PAGE:
                        MoviesViewModel.FirstPage();
                        break;
                    case Utils.Constant.METHOD_LAST_PAGE:
                        MoviesViewModel.LastPage();
                        break;
                    case Utils.Constant.METHOD_NEXT_PAGE:
                        MoviesViewModel.NextPage();
                        break;
                    case Utils.Constant.METHOD_PREVIOUS_PAGE:
                        MoviesViewModel.PreviousPage();
                        break;
                    case Utils.Constant.METHOD_LOAD_INITIAL_MOVIES:
                        MoviesViewModel.LoadInitialMovies();
                        break;
                    case Utils.Constant.METHOD_SEARCH_MOVIES:
                        MoviesViewModel.SearchMovies();
                        break;
                }
            }
            else
            {
                switch (FullMovieViewModel.CurrentAction)
                {
                    case Utils.Constant.METHOD_LOAD_MOVIE:
                        FullMovieViewModel.LoadMovie();
                        break;
                    case Utils.Constant.METHOD_LOAD_LIGHT_ACTORS:
                        FullMovieViewModel.LoadLightActors();
                        break;
                    case Utils.Constant.METHOD_FIRST_PAGE_LIGHT_ACTORS:
                        FullMovieViewModel.FirstPageLightActors();
                        break;
                    case Utils.Constant.METHOD_LAST_PAGE_LIGHT_ACTORS:
                        FullMovieViewModel.LastPageLightActors();
                        break;
                    case Utils.Constant.METHOD_NEXT_PAGE_LIGHT_ACTORS:
                        FullMovieViewModel.NextPageLightActors();
                        break;
                    case Utils.Constant.METHOD_PREVIOUS_PAGE_LIGHT_ACTORS:
                        FullMovieViewModel.PreviousPageLightActors();
                        break;
                    case Utils.Constant.METHOD_LOAD_COMMENTS:
                        FullMovieViewModel.LoadComments();
                        break;
                    case Utils.Constant.METHOD_FIRST_PAGE_COMMENTS:
                        FullMovieViewModel.FirstPageComments();
                        break;
                    case Utils.Constant.METHOD_LAST_PAGE_COMMENTS:
                        FullMovieViewModel.LastPageComments();
                        break;
                    case Utils.Constant.METHOD_NEXT_PAGE_COMMENTS:
                        FullMovieViewModel.NextPageComments();
                        break;
                    case Utils.Constant.METHOD_PREVIOUS_PAGE_COMMENTS:
                        FullMovieViewModel.PreviousPageComments();
                        break;
                }
            }
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
