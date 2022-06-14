using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TravelRecordApp.Helpers;
using TravelRecordApp.Model;

namespace TravelRecordApp.Logic
{
	public class PlaceLogic
	{
		public async static Task<List<Place>> GetPlaces(double latitude, double longitude)
        {
			List<Place> places = new List<Place>();

			string url = PlacesRoot.GenerateURL(latitude, longitude);

			try
            {
				using (HttpClient client = new HttpClient())
				{
					client.DefaultRequestHeaders.Add("Accept", "application/json");
					client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", Constants.AUTHORIZATION);
					var response = await client.GetAsync(url);
					var json = await response.Content.ReadAsStringAsync();

					var placeRoot = JsonConvert.DeserializeObject<PlacesRoot>(json);

					places = placeRoot.results;
				}
			}
			catch (Exception ex)
            {
				Console.WriteLine(ex.Message);
            }

			return places;
        }
	}
}

