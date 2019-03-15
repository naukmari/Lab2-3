using System.Windows.Controls;
using CharpZavertailo2.Tools.Navigation;
using CharpZavertailo2.ViewModels.Authentication;

namespace CharpZavertailo2.Views
{
    /// <summary>
    /// Interaction logic for PersonFillInfoView.xaml
    /// </summary>
    public partial class PersonFillInfoView : UserControl, INavigatable
    {
        public PersonFillInfoView()
        {
           InitializeComponent();
           DataContext = new PersonFillInfoViewModel();
        }
    }
}
