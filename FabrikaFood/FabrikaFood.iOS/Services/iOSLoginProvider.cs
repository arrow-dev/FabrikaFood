using FabrikaFood.Abstractions;
using FabrikaFood.iOS.Services;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using UIKit;


[assembly: Xamarin.Forms.Dependency(typeof(iOSLoginProvider))]
namespace FabrikaFood.iOS.Services
{
    public class iOSLoginProvider : ILoginProvider
    {
        public async Task LoginAsync(MobileServiceClient client)
        {
            await client.LoginAsync(RootView, "facebook");
        }

        public UIViewController RootView => UIApplication.SharedApplication.KeyWindow.RootViewController;
    }
}