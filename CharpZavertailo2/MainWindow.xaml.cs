using System.Windows;
using System.Windows.Controls;
using CharpZavertailo2.Tools.Managers;
using CharpZavertailo2.Tools.Navigation;
using CharpZavertailo2.ViewModels;


namespace CharpZavertailo2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IContentOwner
    {
        public ContentControl ContentControl
        {
            get { return _contentControl; }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(); 
            NavigationManager.Instance.Initialize(new InitializationNavigationModel(this));
            NavigationManager.Instance.Navigate(ViewType.PersonFillInfo);
        }

      
    }
}
