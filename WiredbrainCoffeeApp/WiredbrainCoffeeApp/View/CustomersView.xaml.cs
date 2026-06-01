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
using WiredbrainCoffeeApp.Data;
using WiredbrainCoffeeApp.ViewModel;

namespace WiredbrainCoffeeApp.view
{
    /// <summary>
    /// CustomersView.xaml 的交互逻辑
    /// </summary>
    public partial class CustomersView : UserControl
    {
        private CustomerViewModel _viewModel;

        public CustomersView()
        {
            InitializeComponent();
            _viewModel = new CustomerViewModel(new CustomerDataProvider());
            DataContext = _viewModel;
            Loaded += CustomersView_Loaded;
        }

        private async void CustomersView_Loaded(object sender, RoutedEventArgs e)
        {
           await _viewModel.LoadAsync();
        }

        private void BtnMove_Click(object sender, RoutedEventArgs e)
        {
            //写法1，需要强制类型转换，不太好
            //var column = (int)customerListGrid.GetValue(Grid.ColumnProperty);
            //var col = column == 0 ? 2 : 0;
            //customerListGrid.SetValue(Grid.ColumnProperty, col);

            //写法2.使用Grid类的静态方法，不需要转换类型，比较好
            var column = Grid.GetColumn(customerListGrid);
            var col = column == 0 ? 2 : 0;
            Grid.SetColumn(customerListGrid, col);


        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Add(); //注意：操作事件需要使用视图模型，不要直接操作，否则mvvm就没有意义
        }
    }
}
