
using Android.App;
using Android.Content;
using Android.OS;

namespace FabrikaFood.Droid
{
    [Activity(Label = "LoginActivity", MainLauncher = true, NoHistory=true)]
    public class LoginActivity : Activity
    {
        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();

            var service = App.GetCloudService();

            await service.Login(this);

            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }
    }
}