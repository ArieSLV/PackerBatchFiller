using System.Windows;


namespace PacketBatchFiller4
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            DataContext = new MainWindowViewModel(this);
        }
        
    }
}
