using System;
using System.Collections.Generic;
using System.Collections;
using Plugin.Geolocator;
using SQLite;
using TravelRecordApp.Logic;
using TravelRecordApp.Model;
using Xamarin.Forms;
using System.Linq;

namespace TravelRecordApp
{	
	public partial class NewTravelPage : ContentPage
	{	
		public NewTravelPage ()
		{
			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();

			var locator = CrossGeolocator.Current;
			var position = await locator.GetPositionAsync();

			IEnumerable<Place> places = await PlaceLogic.GetPlaces(position.Latitude, position.Longitude);
			placeListView.ItemsSource = places;
        }

        void toolbarItemSave_Clicked(System.Object sender, System.EventArgs e)
        {
			try
            {
				var selectedPlace = placeListView.SelectedItem as Place;
				var firstCategory = selectedPlace.categories.FirstOrDefault();
				Post post = new Post()
				{
					Experience = experienceEntry.Text,
					PlaceId = selectedPlace.id,
					PlaceName = selectedPlace.name,
					CategoryId = firstCategory.id,
					CategoryName = firstCategory.name,
					Address = selectedPlace.location.address,
					Distance = selectedPlace.distance,
					Latitude = selectedPlace.geocodes.main.latitude,
					Longitude = selectedPlace.geocodes.main.longitude
				};

				using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
				{
					conn.CreateTable<Post>();
					int rows = conn.Insert(post);

					if (rows > 0)
						DisplayAlert("Seccess", "Experience succesfully inserted", "OK");
					else
						DisplayAlert("Failure", "Experience failed to be inserted", "OK");
				}
			}
			catch (NullReferenceException nre)
            {

            }
			catch (Exception ex)
            {

            }
			
		}
	}
}

