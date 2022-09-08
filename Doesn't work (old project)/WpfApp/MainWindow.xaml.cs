using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Utils.APIUtils;
using Utils.APIUtils.Models;
using WpfApp.Model;
using WpfApp.View;
using WpfApp.ViewModel;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MovieViewModel fvm = new MovieViewModel();
        public MainWindow()
        {
            InitializeComponent();
            ViewMovie.MovieGrid.ItemsSource = fvm._dataSource;
        }

        private void BNextPage_Click(object sender, RoutedEventArgs e)
        {
                fvm.GetNextPageAsync();
        }

        private void BPreviousPage_Click(object sender, RoutedEventArgs e)
        {
                fvm.GetPreviousPageAsync();
        }

        private void ValiderRecherche_Click(object sender, RoutedEventArgs e)
        {
            fvm.SearchMovieAsync(TextBoxRechercheFilm.Text);
        }

        private async void ButtonDetails_Click(object sender, RoutedEventArgs e)
        {
            DataGridCellInfo sc = ViewMovie.MovieGrid.SelectedCells.FirstOrDefault();
            MovieModel SelectedFilm = (MovieModel)sc.Item;
            if(SelectedFilm != null)
            {
                APIResponseSingle<FullMovieDTO> response = await WebAPIManager.GetFullMovieDetailsByIdMovieAsync(SelectedFilm.Id);
                FullMovieViewModel ffvm = new FullMovieViewModel(response.Data);
                ViewFilmDetails fd = new ViewFilmDetails(ffvm);
                fd.ShowDialog();
            }
            else
            {
                MessageBox.Show("You need to select a movie","Error");
            }
        }

        private void AnnulerRecherche_Click(object sender, RoutedEventArgs e)
        {
            fvm.StopResearchAsync();
            TextBoxRechercheFilm.Text = "";
        }
    }
}
