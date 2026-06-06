using System.Collections.ObjectModel;
using WiredbrainCoffeeApp.Command;
using WiredbrainCoffeeApp.Data;
using WiredbrainCoffeeApp.Model;



namespace WiredbrainCoffeeApp.ViewModel
{
    public class CustomerViewModel:ViewModelBase
    {
        public CustomerViewModel(ICustomerDataProvider customerDataProvider)
        {
            _customerDataProvider = customerDataProvider;
            AddCommand = new DelegateCommand(Add);
            MoveNavigationCommand = new DelegateCommand(MoveNavigation);
            DeleteCommand = new DelegateCommand(Delete,CanDelete);
        }


        public ObservableCollection<CustomerItemViewModel> Customers { get; } = new();
        public CustomerItemViewModel? SelectedCustomer { get => _selectedCustomer; 
            set { 
                _selectedCustomer = value; 
                //RaisePropertyChanged(nameof(SelectedCustomer)); //触发属性更改事件
                RaisePropertyChanged(nameof(IsCustomerSelected)); //触发IsCustomerSelected属性更改事件
                RaisePropertyChanged(); //触发属性更改事件
                DeleteCommand.RaiseCanExecuteChanged(); //触发删除按钮的属性更改通知
            } 
        }
        //定义一个IsCustomerSelected属性,和SelectedCustomer有关系
        public bool IsCustomerSelected => SelectedCustomer != null;

        public NavigationSide NavigationSide{ 
            get => _navigationSide;
            private set { 
                _navigationSide = value;
                RaisePropertyChanged();
            } 
        }

        private readonly ICustomerDataProvider _customerDataProvider;

        public DelegateCommand AddCommand { get; }
        public DelegateCommand MoveNavigationCommand { get; }
        public DelegateCommand DeleteCommand { get; }
        

        private CustomerItemViewModel? _selectedCustomer;
        private NavigationSide _navigationSide;

        public async Task LoadAsync()
        {
            if (Customers.Any())
            {
                return;
            }
            var customers = await _customerDataProvider.GetAllAsync();
            if (customers is not null)
            {
                foreach (var c in customers)
                {
                    Customers.Add(new CustomerItemViewModel(c));
                }
            }
            
        }

        private void Add(object? param)
        {
            var customer = new Customer { FirstName = "New" };
            var viewModel = new CustomerItemViewModel(customer); 
            Customers.Add(viewModel);
            SelectedCustomer = viewModel;
        }

        private void MoveNavigation(object? param)
        {
            NavigationSide = NavigationSide == NavigationSide .Left? NavigationSide.Right : NavigationSide.Left;
        }

        private bool CanDelete(object? param) => SelectedCustomer is not null; //因为只有选中了才能够删除

        private void Delete(object? param)
        {
           if(SelectedCustomer is not null)
            {
                Customers.Remove(SelectedCustomer); //只要有选中的客户，我们就可以把它删除
                SelectedCustomer = null; //以防止重复删除同一个客户引发异常
            }
        }
    }

    public enum NavigationSide
    {
        Left,
        Right
    }
}
