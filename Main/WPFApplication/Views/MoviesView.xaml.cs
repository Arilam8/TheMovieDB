using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPFApplication.ViewModels;

namespace WPFApplication.Views
{
    /// <summary>
    /// Interaction logic for MoviesView.xaml
    /// </summary>
    public partial class MoviesView : Window
    {
        public MoviesViewModel MoviesViewModel { get; }
        
        public MoviesView()
        {
            InitializeComponent();
            MoviesViewModel = new MoviesViewModel(this);
            this.DataContext = MoviesViewModel;
        }
    }
}
