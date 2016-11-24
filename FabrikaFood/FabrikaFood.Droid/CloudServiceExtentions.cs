using Android.Content;
using FabrikaFood.Services;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace FabrikaFood.Droid
{
    public static class CloudServiceExtentions
    {
        public static async Task Login(this AzureCloudService service, Context ctx)
        {
            var cloudService = App.GetCloudService();
            var client = new MobileServiceClient("http://fabrikafood.azurewebsites.net");
            var user = await client.LoginAsync(ctx, MobileServiceAuthenticationProvider.Facebook);

            cloudService.CurrentUser = user;
        }

        public static async Task Login(this AzureCloudService service, string authToken)
        {
            JObject tokenObject = CreateTokenObject(authToken);
            var cloudService = App.GetCloudService();
            var client = new MobileServiceClient("http://fabrikafood.azurewebsites.net");
            var user = await client.LoginAsync(MobileServiceAuthenticationProvider.Facebook, tokenObject);

            cloudService.CurrentUser = user;
        }

        private static JObject CreateTokenObject(string authToken)
        {
            var tokenObject = new JObject();
            tokenObject.Add("id_token", authToken);
            return tokenObject;

        }
    }
}