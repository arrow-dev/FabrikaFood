using FabrikaFood.ViewModels;
using Xamarin.Forms;

namespace FabrikaFood.Pages
{
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();
            BindingContext = new MenuPageViewModel();
        }
    }
}
