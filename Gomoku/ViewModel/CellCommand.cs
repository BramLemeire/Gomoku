using Cells;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ViewModel
{
    class CellCommand : ICommand
    {
        private ICell<bool> canExecute;
        private Action execute;

        public CellCommand(ICell<bool> canExecute, Action execute)
        {
            this.canExecute = canExecute;
            this.execute = execute;
            this.canExecute.ValueChanged += () => CanExecuteChanged?.Invoke(this, new EventArgs());
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return canExecute.Value;
        }

        public void Execute(object parameter)
        {
            execute();
        }
    }

}
