using System.ComponentModel;

namespace PacketBatchFiller4
{
    /// <summary>
    /// Base View model
    /// </summary>
    public class BaseViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
