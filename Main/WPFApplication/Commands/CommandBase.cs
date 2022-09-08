using System;
using System.Windows.Input;

namespace WPFApplication.Commands
{
    public abstract class CommandBase : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public virtual bool CanExecute(object? parameter)
        {
            return true;
        }

        public abstract void Execute(object? parameter);

        protected void OnCanExecutesChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
