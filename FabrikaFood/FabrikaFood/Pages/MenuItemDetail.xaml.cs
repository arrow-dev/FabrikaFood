
using FabrikaFood.ViewModels;
using Xamarin.Forms;

namespace FabrikaFood.Pages
{
    public partial class MenuItemDetail : ContentPage
    {
        public MenuItemDetail(Models.MenuItem menuItem = null)
        {
            InitializeComponent();
            BindingContext = new MenuItemDetailViewModel(menuItem);
        }
    }
}
