using WPFApplication.ViewModels;

namespace WPFApplication.Commands
{
    public class InvalidateCommentFullMovieCommand : CommandBase
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
        public InvalidateCommentFullMovieCommand(FullMovieViewModel fullMovieViewModel)
        {
            FullMovieViewModel = fullMovieViewModel;
        }
        #endregion

        #region METHODS
        public override void Execute(object? parameter)
        {
            if(parameter is int)
                FullMovieViewModel.InvalidateOrValidateComment((int)parameter, false);
        }
        #endregion
    }
}
