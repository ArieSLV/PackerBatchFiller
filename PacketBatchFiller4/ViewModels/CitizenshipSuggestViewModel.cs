 using System.Windows.Controls;

namespace PacketBatchFiller4
{
    /// <summary>
    /// ViewModel юзерконтрола для поиска и выбора Гражданства
    /// </summary>
    public class CitizenshipSuggestViewModel : SuggestModuleViewModel<Citizenship>
    {
        public CitizenshipSuggestViewModel(UserControl userControl) : base(userControl)
        {

        }
    }
}
