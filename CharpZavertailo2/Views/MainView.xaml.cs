using System.Windows.Controls;
using CharpZavertailo2.Tools.Navigation;
using CharpZavertailo2.ViewModels.Authentication;

namespace CharpZavertailo2.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl, INavigatable
    {
        public MainView()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
