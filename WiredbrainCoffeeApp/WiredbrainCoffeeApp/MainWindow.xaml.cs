using System.Threading.Tasks;
using System.Windows;
using WiredbrainCoffeeApp.Data;
using WiredbrainCoffeeApp.ViewModel;

namespace WiredbrainCoffeeApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainViewModel(new CustomerViewModel(new CustomerDataProvider()),new ProductViewModel());
            DataContext = _viewModel;
            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
           await _viewModel.LoadAsync();
        }
    }
}