using Plugin.Geolocator;
using ST_MapApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace ST_MapApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapView : ContentPage
    {
        private double Latitude;
        private double Longitude;

        public MapView()
        {
            InitializeComponent();
            GetLocation();
        }
        public async void GetLocation()
        {
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;

                var position = await locator.GetPositionAsync();
                Latitude = position.Latitude;
                Longitude = position.Longitude;
            }
            catch (Exception ex)
            {

            }

            CreateMap();
        }
        public void CreateMap()
        {
            var currentMap = new CustomMap
            {
                HasScrollEnabled = true,
                HasZoomEnabled = true,
                MapType = MapType.Street,
                WidthRequest = App.ScreenWidth,
                HeightRequest = App.ScreenHeight
            };

            var pin = new CustomPin
            {
                Type = PinType.Place,
                Address = "Linh Trung, Thu Duc, Ho Chi Minh",
                Label = "University Infomation of Technology",
                Position = new Position(10.879683, 106.803269),
                Id = "Xamarin",
                Url = "http://xamarin.com/about/"
            };

            var pin1 = new CustomPin
            {
                Type = PinType.Place,
                Address = "Linh Trung, Thu Duc, Ho Chi Minh",
                Label = "University Infomation of Technology",
                Position = new Position(5.879683, 100.803269),
                Id = "Xamarin",
                Url = "http://xamarin.com/about/"
            };
            currentMap.CustomPins = new List<CustomPin> { pin, pin1 };
            foreach (var p in currentMap.CustomPins)
            {
                currentMap.Pins.Add(p);
            }

            currentMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(Latitude, Longitude),
                Distance.FromMiles(1.0)));

            var searchBar = new SearchBar();
            searchBar.TextChanged += SearchBar_textchanged;

            Content = new StackLayout
            {
                Children =
                {
                    searchBar,
                    currentMap                      
                }
              
            };
        }

        private void SearchBar_textchanged(object sender, TextChangedEventArgs e)
        {
            DisplayAlert("the value of seach bar is", e.NewTextValue,"cancel");
        }
    }
}