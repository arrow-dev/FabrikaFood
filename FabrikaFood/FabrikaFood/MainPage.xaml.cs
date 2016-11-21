using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Linq;
using Xamarin.Forms;
using MenuItem = FabrikaFood.Models.MenuItem;

namespace FabrikaFood
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {

            MobileServiceClient client = new MobileServiceClient("http://fabrikafood.azurewebsites.net");
            var menuItems = await client.GetTable<MenuItem>().ReadAsync();
            message.Text = menuItems.First().Title;
        }
    }
}
