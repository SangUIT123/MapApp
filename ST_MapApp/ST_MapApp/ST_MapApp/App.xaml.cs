
using ST_MapApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ST_MapApp
{
    public partial class App : Application
    {
        public static double ScreenWidth { get; internal set; }
        public static double ScreenHeight { get; internal set; }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MapView());
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
