using Android.Content;
using FabrikaFood.Abstractions;
using FabrikaFood.Droid.Services;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(DroidLoginProvider))]
namespace FabrikaFood.Droid.Services
{
    class DroidLoginProvider : ILoginProvider
    {
        Context context;

        public void Init(Context context)
        {
            this.context = context;
        }

        public async Task LoginAsync(MobileServiceClient client)
        {
            await client.LoginAsync(context, "facebook");
        }
    }
}