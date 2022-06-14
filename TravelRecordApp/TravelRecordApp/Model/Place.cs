using System;
using System.Collections.Generic;
using TravelRecordApp.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TravelRecordApp.Model
{

    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Chain
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Main
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
    }

    public class Roof
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
    }

    public class Geocodes
    {
        public Main main { get; set; }
        public Roof roof { get; set; }
    }

    public class Location
    {
        public string address { get; set; }
        public string address_extended { get; set; }
        public string census_block { get; set; }
        public string country { get; set; }
        public string dma { get; set; }
        public string formatted_address { get; set; }
        public string locality { get; set; }
        public IList<string> neighborhood { get; set; }
        public string postcode { get; set; }
        public string region { get; set; }
        public string cross_street { get; set; }
    }

    public class Parent
    {
        [JsonProperty("fsq_id")]
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Child
    {
        [JsonProperty("fsq_id")]
        public string id { get; set; }
        public string name { get; set; }
    }

    public class RelatedPlaces
    {
        public Parent parent { get; set; }
        public IList<Child> children { get; set; }
    }

    public class Place
    {
        [JsonProperty("fsq_id")]
        public string id { get; set; }
        public IList<Category> categories { get; set; }
        public Location location { get; set; }
        public string name { get; set; }
        public int distance { get; set; }
        public Geocodes geocodes { get; set; }
    }

    public class PlacesRoot
    {
        public static string GenerateURL(double latitude, double longitude)
        {
            return string.Format(Constants.PLACE_SEARCH, latitude, longitude);
        }

        public List<Place> results { get; set; }
    }

}

