using System.Windows.Controls;
using WPFApplication.ViewModels;

namespace WPFApplication.Views
{
    /// <summary>
    /// Logique d'interaction pour ErrorView.xaml
    /// </summary>
    public partial class ErrorsView : Page
    {
        public ErrorsViewModel ErrorsViewModel { get; }

        public ErrorsView(MoviesViewModel moviesViewModel, FullMovieViewModel fullMovieViewModel)
        {
            InitializeComponent();
            ErrorsViewModel = new ErrorsViewModel(this, moviesViewModel, fullMovieViewModel);
            this.DataContext = ErrorsViewModel;
        }
    }
}
