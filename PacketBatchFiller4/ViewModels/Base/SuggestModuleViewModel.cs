using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;

namespace PacketBatchFiller4
{
    public class SuggestModuleViewModel<TEntity> : BaseViewModel where TEntity : class, ISuggestable, new()
    {
        #region Private fields
        
        private readonly char[] _delimiterChars = { ' ', ',', '.', ':', ';' };

        #endregion

        #region Default constructor
        
        public SuggestModuleViewModel(UserControl userControl)
        {
            LoadReferenceBookFromContext();

            #region Commands registration

            SearchTextTextChanged = new CommandCanExecute(OnSearchTextTextChanged);
            
            #endregion

        }
        
        #endregion

        private void OnSearchTextTextChanged()
        {
            //Запоминаем какой Item выбран
            var tmpSelectedItem = SelectedItem;

            //Обнуляем счётчик отфильтрованных Item'ов
            FiltredItemsCounter = 0;

            CollectionViewSource.GetDefaultView(ItemsCollection).Filter = item =>
            {
                var tEntity = item as TEntity;

                if (tEntity?.GetEntityMainPropertyValue() != null)
                {
                    foreach (var filterWord in SearchText.ToLower().Split(_delimiterChars))
                    {
                        if (!tEntity.ToString().ToLower().Contains(filterWord.ToLower()))
                        {
                            return false;
                        }
                    }
                }
                FiltredItemsCounter += 1;

                if (FiltredItemsCounter == 1) SelectedItem = tEntity;

                return true;
            };

            //RemoveSelectedButtonVisibility = SetVisibilityVisibleBasedOnSuggestListBox(FiltredItemsCounter);

            if (FiltredItemsCounter == 1)
                Messenger.Default.Send(new NotificationMessage(SelectedItem, typeof(TEntity).ToString()));
            

            else if (FiltredItemsCounter > 1)
                SelectedItem = ItemsCollection.FirstOrDefault(item => item == tmpSelectedItem);
            else
                SelectedItem = null;


            if (SearchText.Length > 0)
            {
                //SuggestListBoxAndControlButtonsVisibility = Visibility.Visible;
            }
            else
            {
                //SuggestListBoxAndControlButtonsVisibility = Visibility.Collapsed;
                SelectedItem = null;
            }

            

            
        }

        #region Public properties

        public string SearchText { get; set; }

        public TEntity SelectedItem { get; set; }

        public TEntity TargetEntity { get; set; }

        public ObservableCollection<TEntity> ItemsCollection { get; set; }

        public int FiltredItemsCounter { get; set; }
        
        #endregion

        #region Commands

        public CommandCanExecute SearchTextTextChanged { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Загрузка данных из контекста
        /// </summary>
        protected void LoadReferenceBookFromContext()
        {
            using (var db = MainWindowViewModel.DataBase)
            {
                var collection = db.GetEntityObservableCollection<TEntity>().OrderBy(item => item.GetMainPropertyName());

                ItemsCollection = new ObservableCollection<TEntity>(collection);
            }
        }
        
        #endregion
    }
}
