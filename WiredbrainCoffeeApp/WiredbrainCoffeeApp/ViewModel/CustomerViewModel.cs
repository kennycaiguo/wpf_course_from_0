using System.Collections.ObjectModel;
using WiredbrainCoffeeApp.Data;
using WiredbrainCoffeeApp.Model;



namespace WiredbrainCoffeeApp.ViewModel
{
    public class CustomerViewModel:ViewModelBase
    {
        public CustomerViewModel(ICustomerDataProvider customerDataProvider)
        {
            _customerDataProvider = customerDataProvider;
        }
        
        public ObservableCollection<CustomerItemViewModel> Customers { get; } = new();
        public CustomerItemViewModel? SelectedCustomer { get => _selectedCustomer; 
            set { 
                _selectedCustomer = value; 
                //RaisePropertyChanged(nameof(SelectedCustomer)); //触发属性更改事件
                RaisePropertyChanged(); //触发属性更改事件
            } 
        }
        private readonly ICustomerDataProvider _customerDataProvider;
        private CustomerItemViewModel? _selectedCustomer;

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

        internal void Add()
        {
            var customer = new Customer { FirstName = "New" };
            var viewModel = new CustomerItemViewModel(customer); 
            Customers.Add(viewModel);
            SelectedCustomer = viewModel;
        }

       
    }
}
