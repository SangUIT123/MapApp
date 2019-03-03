using Plugin.Geolocator;
using ST_MapApp;
using ST_MapApp.Models;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

using ST_MapApp.ViewModels;

namespace MapApp
{
    public class MapPage : ContentPage
    {
        private double Latitude;
        private double Longitude;        
        private SearchBar searchBar;
     
        public MapPage()
        {
            GetLocation();
            BindingContext = new MapViewModel();            
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
            
            searchBar = new SearchBar {
                SearchCommand = Binding()
            };

            
            Content = new StackLayout
            {
                Padding = new Thickness(5, 20, 5, 0),
                HorizontalOptions = LayoutOptions.Fill,
                Children = {
                    searchBar,                   
                    currentMap                    
                }
            };
            //Content = currentMap;
        }



        private void CurrentMap_focuesed(object sender, FocusEventArgs e)
        {
            throw new NotImplementedException();
        }

        //public void UnivercityInfoAndTech_clicked(object sender, EventArgs e)
        //{
        //    var selectedPin = (Pin)sender;
        //    DisplayAlert(selectedPin.Label, selectedPin.Address, "OK");
        //}
    }
}