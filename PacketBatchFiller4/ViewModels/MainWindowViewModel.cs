using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;

namespace PacketBatchFiller4
{
    public class MainWindowViewModel : BaseViewModel
    {
        public MainWindowViewModel(Window window)
        {
            TestCommand = new CommandCanExecute(TestExecute);
            
            RegisterMessenger();
        }

        private void TestExecute()
        {
            
        }

        #region Public properties

        public static PBF4Db DataBase => new PBF4Db();

        public ICommand TestCommand { get; set; }

        public Citizenship Citizenship { get; set; }



        #endregion

        #region Methods

        /// <summary>
        /// Регистрируем Messenger, принимающие свойства из других ViewModels
        /// </summary>
        private void RegisterMessenger()
        {
            
            Messenger.Default.Register<NotificationMessage>(this, message =>
            {

                //Регистрация сообщения от ViewModel Citizenship и присваиваем его 
                if (message.Notification == typeof(Citizenship).ToString())
                    Citizenship = (Citizenship)message.Sender;
            });
        }

        #endregion

    }
}
