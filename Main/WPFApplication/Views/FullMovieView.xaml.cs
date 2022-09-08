using System.Windows;
using WPFApplication.ViewModels;

namespace WPFApplication.Views
{
    /// <summary>
    /// Logique d'interaction pour FullMovieView.xaml
    /// </summary>
    public partial class FullMovieView : Window
    {
        public FullMovieViewModel FullMovieViewModel { get; }
        public FullMovieView(int idMovie)
        {
            InitializeComponent();
            FullMovieViewModel = new FullMovieViewModel(this, idMovie);
            this.DataContext = FullMovieViewModel;
        }
    }
}
