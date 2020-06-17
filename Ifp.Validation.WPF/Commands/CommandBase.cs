using System;
using System.Windows.Input;

namespace Ifp.Validation.WPF.Commands
{
    abstract class CommandBase : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public virtual bool CanExecute(object parameter) => true;

        public abstract void Execute(object parameter);

        protected virtual void OnCanExecuteChanged()
        {
            var tmp = CanExecuteChanged;
            if (tmp == null) return;
            tmp(this, EventArgs.Empty);
        }
    }
}
