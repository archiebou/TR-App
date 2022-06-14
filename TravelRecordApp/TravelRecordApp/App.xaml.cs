using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
    public partial class App : Application
    {
        public static string DatabaseLocation = string.Empty;
        public App ()
        {
            AppInitialize();
        }

        public App(string databaseLocation)
        {
            AppInitialize();

            DatabaseLocation = databaseLocation;
        }

        private void AppInitialize() //Was added by me to avoid code duplication
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

