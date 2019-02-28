using System;
using System.Windows.Input;

namespace Simple_MVVM.ViewModels
{
    class SimpleCommand : ICommand
    {
        private readonly Action _action;

        public SimpleCommand(Action action)
        {
            _action = action;
        }
        event EventHandler ICommand.CanExecuteChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        bool ICommand.CanExecute(object parameter)
        {
            return true;
        }

        void ICommand.Execute(object parameter)
        {
            _action();
        }
    }
}
