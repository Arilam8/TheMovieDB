using WPFApplication.ViewModels;

namespace WPFApplication.Commands
{
    public class NavigationFirstPageCommentCommand : CommandBase
    {
        #region MEMBER_VARIABLES
        private FullMovieViewModel _fullMovieViewModel;
        #endregion

        #region PROPERTIES
        public FullMovieViewModel FullMovieViewModel
        {
            get { return _fullMovieViewModel; }
            set
            {
                if (_fullMovieViewModel != value)
                {
                    _fullMovieViewModel = value;
                }
            }
        }
        #endregion

        #region BUILDERS
        public NavigationFirstPageCommentCommand(FullMovieViewModel fullMovieViewModel)
        {
            FullMovieViewModel = fullMovieViewModel;
        }
        #endregion

        #region METHODS
        public override void Execute(object? parameter)
        {
            FullMovieViewModel.FirstPageComments();
        }
        #endregion
    }
}
