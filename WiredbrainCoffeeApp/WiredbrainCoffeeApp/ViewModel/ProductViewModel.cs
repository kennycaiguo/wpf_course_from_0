using System.Collections.ObjectModel;
using WiredbrainCoffeeApp.Data;
using WiredbrainCoffeeApp.Model;

namespace WiredbrainCoffeeApp.ViewModel
{
    public class ProductViewModel: ViewModelBase
    {
        private readonly IProductDataProvider _productDataProvider;

        public ProductViewModel(IProductDataProvider productDataProvider)
        {
            _productDataProvider = productDataProvider;
        }

        public ObservableCollection<Product> Products { get; } = new();

        public override async Task LoadAsync()
        {
            if (Products.Any()) //如果产品数据已经加载，我们就跳出这个函数
            {
                return;
            }
            var products =await _productDataProvider.getAllAsync();
            if(products is not null)
            {
                foreach (var product in products) 
                {
                    Products.Add(product);
                }
            }
        }
    }
}
