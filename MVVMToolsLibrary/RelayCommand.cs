using System;
using System.Windows.Input;

namespace MVVMTools
{
    /// <summary>
    /// Definiert ein Command für ViewModels. Implemnetiert die ICommand-Schnittstelle
    /// </summary>
    public class RelayCommand : ICommand
    {

        private Action<object> _execute;
        private Predicate<object> _canExecute;

        #region Konstruktor
        public RelayCommand(Action<object> pExecute) : this(pExecute, null)
        { }
        public RelayCommand(Action<object> pExecute, Predicate<object> pCanExecute)
        {
            if (pExecute == null)
            {
                throw new ArgumentNullException("pExecute");
            }
            _execute = pExecute;
            _canExecute = pCanExecute;
        }
        #endregion

        #region ICommand
        public void Execute(object pParameter)
        {
            _execute(pParameter);
        }
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object pParameter)
        {
            if(_canExecute == null)
            {
                return true;
            }
            return _canExecute(pParameter);
        }
        #endregion

        public void RaiseCanExecuteChange()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
