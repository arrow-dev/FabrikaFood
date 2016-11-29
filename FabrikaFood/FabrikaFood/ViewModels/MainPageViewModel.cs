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
            Title = "Fabrikam Food";
        }

        Command menuCommand;

        public Command MenuCommand
            => menuCommand ?? (menuCommand = new Command(async () => await ExecuteMenuCommand()));

        async Task ExecuteMenuCommand()
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
                Debug.WriteLine($"{ex.Message}");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}