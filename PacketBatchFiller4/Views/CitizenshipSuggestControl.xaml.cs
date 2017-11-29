using System.Windows.Controls;

namespace PacketBatchFiller4
{
    public partial class CitizenshipSuggestControl : UserControl
    {
        public CitizenshipSuggestControl()
        {
            InitializeComponent();

            DataContext = new CitizenshipSuggestViewModel(this);
        }
    }
}
