
using FabrikaFood.Abstractions;
using FabrikaFood.Services;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FabrikaFood
{
    public interface IAuthenticate
    {
        Task<bool> Authenticate();
    }

    public partial class App : Application
    {
        public static ICloudService CloudService { get; set; }

        public App()
        {
            CloudService = new AzureCloudService();
            MainPage = new NavigationPage(new Pages.MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
