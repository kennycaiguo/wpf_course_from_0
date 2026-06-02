using System.Windows.Input;

namespace WiredbrainCoffeeApp.Command
{
    public class DelegateCommand : ICommand
    {
        private readonly Action<object?> _exectue;
        private readonly Func<object?, bool>? _canExecute;

        public DelegateCommand(Action<object?> exectue,Func<object?,bool>? canExecute =null) 
        {
            ArgumentNullException.ThrowIfNull(exectue);
            _exectue = exectue;
            _canExecute = canExecute;
        }
        public event EventHandler? CanExecuteChanged;
        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        public bool CanExecute(object? parameter) => _canExecute is null || _canExecute(parameter);

        public void Execute(object? parameter)=> _exectue(parameter);
        
    }
}
