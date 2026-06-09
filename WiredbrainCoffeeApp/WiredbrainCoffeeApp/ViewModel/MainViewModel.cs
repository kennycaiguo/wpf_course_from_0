using System.Threading.Tasks;
using WiredbrainCoffeeApp.Command;

namespace WiredbrainCoffeeApp.ViewModel
{
    public class MainViewModel:ViewModelBase
    {
        
        private ViewModelBase? _selectedViewModel;
        public MainViewModel(CustomerViewModel customerViewModel,ProductViewModel productViewModel)
        {
            CustomerViewModel = customerViewModel;
            ProductViewModel = productViewModel;
            SelectedViewModel = CustomerViewModel; //默认设置客户视图模型
            SelectViewModelCommand = new DelegateCommand(SelectViewModel);
        }
        public CustomerViewModel CustomerViewModel { get; }
        public ProductViewModel ProductViewModel { get; }
        public ViewModelBase SelectedViewModel
		{
            get => _selectedViewModel;
            set {
				_selectedViewModel = value;
				RaisePropertyChanged();
			}
		}
        public DelegateCommand SelectViewModelCommand{ get;} 
        public async override Task LoadAsync()
        {
            if (SelectedViewModel is not null)
            {
                await SelectedViewModel.LoadAsync();
            }
        }

        private async void SelectViewModel(object? parameter)
        {
            SelectedViewModel = parameter as ViewModelBase;
            await SelectedViewModel.LoadAsync();
        }

    }
}
