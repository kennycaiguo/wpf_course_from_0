using System.Globalization;
using System.Windows.Data;
using WiredbrainCoffeeApp.ViewModel;

namespace WiredbrainCoffeeApp.Converter
{
    public class NavigationSideToGridColumnConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var navigationSide = (NavigationSide)value;
            return navigationSide == NavigationSide.Left ? 0 :2;
        }

        //这个函数左右双向绑定的时候才需要，这里是单向绑定，我们不需要理会他
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
} 
