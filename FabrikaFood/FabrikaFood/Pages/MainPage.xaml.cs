using FabrikaFood.ViewModels;
using Xamarin.Forms;

namespace FabrikaFood.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }

        //private async void Button_Clicked(object sender, EventArgs e)
        //{
        //    var menuItems = await GetMenuAndComments();
        //}
        //public async Task<IEnumerable<MenuItem>> GetMenuAndComments()
        //{
        //    MobileServiceClient client = new MobileServiceClient("http://fabrikafood.azurewebsites.net", new MyHandler());
        //    return await client.GetTable<MenuItem>().WithParameters(new Dictionary<string, string> { {"expand", "comments"} }).ToListAsync();
        //}

        //public class MyHandler : DelegatingHandler
        //{
        //    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        //    {
        //        UriBuilder builder = new UriBuilder(request.RequestUri);

        //        builder.Query = builder.Query
        //            .Replace("expand", "$expand")
        //            .TrimStart('?');

        //        request.RequestUri = builder.Uri;

        //        return await base.SendAsync(request, cancellationToken);
        //    }
        //}
    }
}
