using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AMSRSE.DataViewer.Commands
{
    public class DelegateCommand : ICommand
    {
        #region Members

        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _execute;

        #endregion Members

        #region Events

        public event EventHandler CanExecuteChanged;

        #endregion Events

        #region Ctor

        public DelegateCommand(Action<object> execute) : this(execute, null)
        {

        }

        public DelegateCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        #endregion Ctor

        #region Methods

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
                return true;

            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion Methods
    }
}
