using FabrikaFood.Abstractions;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FabrikaFood.ViewModels
{
    public class MainPageViewModel: BaseViewModel
    {
        public MainPageViewModel()
        {
            Title = "Fabrika Food";
        }

        Command loginCommand;

        public Command LoginCommand
            => loginCommand ?? (loginCommand = new Command(async () => await ExecuteLoginCommand()));

        async Task ExecuteLoginCommand()
        {
            if (IsBusy)
                return;
            IsBusy = true;

            try
            {
                Application.Current.MainPage = new NavigationPage(new Pages.MenuPage());
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Login] Error = {ex.Message}");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}