using System.Windows.Controls;
using WPFApplication.ViewModels;

namespace WPFApplication.Commands
{
    public class NavigationNextScrollViewCommand : CommandBase
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
        public NavigationNextScrollViewCommand(FullMovieViewModel fullMovieViewModel)
        {
            FullMovieViewModel = fullMovieViewModel;
        }
        #endregion

        #region METHODS
        public override void Execute(object? parameter)
        {
            if(parameter is ScrollViewer)
                FullMovieViewModel.ScrollViewerActorRight((ScrollViewer)parameter);
        }
        #endregion
    }
}
