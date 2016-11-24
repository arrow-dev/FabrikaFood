using FabrikaFood.Services;
using Xamarin.Forms;

namespace FabrikaFood
{
    public partial class App : Application
    {
        public static AzureCloudService CloudService { get; set; }

        public App()
        {
            MainPage = new NavigationPage(new Pages.MainPage());
        }

        public static AzureCloudService GetCloudService()
        {
            if (CloudService == null)
            {
                CloudService = new AzureCloudService();
            }
            return CloudService;
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
