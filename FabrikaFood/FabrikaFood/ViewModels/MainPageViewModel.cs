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
        //Navigate to Menu page.
        public Command MenuCommand
            => menuCommand ?? (menuCommand = new Command(async () => await ExecuteMenuCommand()));

        async Task ExecuteMenuCommand()
        {
            if (IsBusy)
                return;
            IsBusy = true;
            //Setting IsBusy to true whenever a Command executes can be used with databinding to give the user visual feedback.

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