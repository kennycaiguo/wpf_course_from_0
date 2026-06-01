using System.ComponentModel;
using System.Runtime.CompilerServices;



namespace WiredbrainCoffeeApp.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public ViewModelBase() { }

        public event PropertyChangedEventHandler? PropertyChanged;

        //触发上面的event的私有方法
        protected virtual void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
