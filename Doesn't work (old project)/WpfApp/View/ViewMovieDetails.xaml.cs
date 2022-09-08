using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Utils.APIUtils;
using Utils.APIUtils.Models;
using WpfApp.ViewModel;

namespace WpfApp.View
{
    /// <summary>
    /// Logique d'interaction pour FilmDetails.xaml
    /// </summary>
    public partial class ViewFilmDetails : Window
    {
        private FullMovieViewModel ffvm;
        public ViewFilmDetails()
        {
            InitializeComponent();
        }
        public ViewFilmDetails(FullMovieViewModel ffvm)
        {
            InitializeComponent();
            this.ffvm = ffvm;
            DataContext = ffvm._movie;

            Genres.FontSize = 10;
            foreach(MovieTypeDTO ft in ffvm._movie.MovieTypes)
            {
                Genres.Text = Genres.Text + ft.Name + "\n";
            }
        }

        private async void AjouterCommentaire_Click(object sender, RoutedEventArgs e)
        {
            await ffvm.AjouterCommentaire(ffvm._movie.Id, TextComment.Text, (int)SlideRate.Value, TextUsername.Text);
            APIResponseSingle<FullMovieDTO> response = await WebAPIManager.GetFullMovieDetailsByIdMovieAsync(ffvm._movie.Id);
            ffvm = new FullMovieViewModel(response.Data);
            DataContext = ffvm._movie;
        }
    }
}
