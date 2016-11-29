using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace FabrikaFood.Pages
{
    public class MapPage : ContentPage
    {
        public MapPage()
        {
            var map = new Map(
                MapSpan.FromCenterAndRadius(
                        new Position(-43.532632, 172.637257), Distance.FromMiles(0.3)))
            {
                IsShowingUser = true,
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(map);
            Content = stack;

            var position = new Position(-43.532632, 172.637257); // Latitude, Longitude
            var pin = new Pin
            {
                Type = PinType.Place,
                Position = position,
                Label = "Fabrikam Food",
                Address = "273 High St Christchurch"
            };
            map.Pins.Add(pin);
        }
    }
}
