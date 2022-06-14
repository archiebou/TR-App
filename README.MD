This document has been updated on 2022-06-14
# This version is using foursquare Places API v3

## ***Sorry for any error in my English but is not my first language***

The only intend of this code is to show how I solved the compatibility issue of the Section 8 on the training "The Complete Xamarin Developer Course" at Udemy with the new API version 3.

The API version 3 is completely different. I am not found the Venue section. Pretty sure was replaced by Place and this is what I am using in this code.

This is the list of changes (hope none have been forgotten)

- In the foursquare developer website. We need to create an API Key to replace the use of ClientId and Client Secret.
   - Select "Project Settings" on the left menu.
   - Click on "Generate Additional API Key
   - On the "API Key Nickname" field enter any name you want. Just for reference, no need to be used in your project. And click "Next".
   - On the next screen you will the API Key generated. Copy that value in a safe place. You will not be able to see it back again.

One of the big changes in my source code vs the code at Udemy is because I renamed all "Venue" words in the code with "Place". This to be consistent with the new API objects.

## Code Changes (The most importants)

> Helpers > Constants.cs
```
using System;
namespace TravelRecordApp.Helpers
{
	public class Constants
	{
		public const string PLACE_SEARCH = "https://api.foursquare.com/v3/places/search?ll={0},{1}";
		public const string AUTHORIZATION = "<API Key Value>";
	}
}
```
- I removed the constants ``CLIENT_ID`` and ``CLIENT_SECRET``
- A new constant was created, ``AUTHORIZATION``. The value is the API Key generated in the foursquare developer website explained above.
- Because I am using Place instead of Venue, a new name was assigned to the url constant. ``PLACE_SEARCH``. You could copy the value to get the url for version 3.

> Logic > PlaceLogic.cs (renamed from VenueLogic.cs)
```
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
```
- Note: I am using a try/catch block mostly for debugging.
- The changes here is the addition of headers value
   - A new header has been added to specify the type of request structure [Accept, application/json]
   - Another header is added to include the API Key generator in the foursquare API website placed in the `AUTHORIZATION` constant.
  
## The other important changes is the Place model class (Venue model class on Udemy). For that I will let you free to see it in the code.


** Feel free to contact me if you have any question about my code or if you will invite a coffee ;)


> Archie Bou
> 
> archiebou@gmail.com
