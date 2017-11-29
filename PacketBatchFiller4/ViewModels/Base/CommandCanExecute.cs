using System;
using System.Windows.Input;

namespace PacketBatchFiller4
{
    /// <summary>
    /// Command with always Can Execute
    /// </summary>
    public class CommandCanExecute : ICommand
    {
        private readonly Action _action;

        public CommandCanExecute(Action action)
        {
            _action = action;
        }

        public void Execute(object parameter)
        {
            _action();
        }

        public event EventHandler CanExecuteChanged = (sender, e) => { };
        public bool CanExecute(object parameter) => true;
    }
}
