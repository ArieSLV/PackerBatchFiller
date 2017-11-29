using System.Windows;
using System.Windows.Input;

namespace PacketBatchFiller4
{
    class PersonWindowViewModel : BaseViewModel
    {
        public ICommand SomeCommand { get; set; }

        public PersonWindowViewModel(Window window)
        {
            SomeCommand = new CommandCanExecute(SomeMethod);
        }

        private void SomeMethod()
        {
            
        }
    }
}
