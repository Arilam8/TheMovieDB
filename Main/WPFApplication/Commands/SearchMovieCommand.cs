using WPFApplication.ViewModels;

namespace WPFApplication.Commands
{
    public class SearchMovieCommand : CommandBase
    {
        #region MEMBER_VARIABLES
        private MoviesViewModel _moviesViewModel;
        #endregion

        #region PROPERTIES
        public MoviesViewModel MoviesViewModel
        {
            get { return _moviesViewModel; }
            set
            {
                if (_moviesViewModel != value)
                {
                    _moviesViewModel = value;
                }
            }
        }
        #endregion

        #region BUILDERS
        public SearchMovieCommand(MoviesViewModel moviesViewModel)
        {
            MoviesViewModel = moviesViewModel;
        }
        #endregion

        #region METHODS
        public override void Execute(object? parameter)
        {
            MoviesViewModel.SearchMovies();   
        }
        #endregion
    }
}
