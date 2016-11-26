
using FabrikaFood.ViewModels;
using System;
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

        private void PostComment_Clicked(object sender, EventArgs e)
        {
            var clickedButton = (Button)sender;
            if (!Editor.IsVisible)
            {
                clickedButton.Text = "Cancel";
                Editor.IsVisible = true;
                PostButton.IsVisible = true;
            }
            else
            {
                clickedButton.Text = "Post Comment";
                Editor.IsVisible = false;
                PostButton.IsVisible = false;
            }
            
        }
        
    }
}
