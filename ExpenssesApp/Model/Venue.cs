﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ExpenssesApp.Helpers;
using ExpenssesApp.Model;
using Newtonsoft.Json;

namespace ExpenssesApp.Model
{
    public class VenueRoot
    {
        public Response response { get; set; }

        public static string GenerateUrl(double latitude , double longitude)
        {
            return string.Format(Constantes.Venue_search, latitude, longitude, Constantes.Client_id, Constantes.Client_secret, DateTime.Now.ToString("yyyyMMdd"));
        }
      
    }
   

  

    public class Location
    {
        public string address { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public int distance { get; set; }
        public string postalCode { get; set; }
        public string cc { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public IList<string> formattedAddress { get; set; }
        public string crossStreet { get; set; }
    }



    public class Category
    {
        public string id { get; set; }
        public string name { get; set; }
        public string pluralName { get; set; }
        public string shortName { get; set; }
        public bool primary { get; set; }
    }



public class Venue
{
    public string id { get; set; }
    public string name { get; set; }
    public Location location { get; set; }
    public IList<Category> categories { get; set; }
    public async static Task<List<Venue>> getVenues(double latitude, double longitude)
        {
            List<Venue> venues = new List<Venue>();
            var url = VenueRoot.GenerateUrl(latitude, longitude);


            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();

                var venueRoot = JsonConvert.DeserializeObject<VenueRoot>(json);
                venues = venueRoot.response.venues as List<Venue>;
            }
            return venues;
        }


    }

    public class Response
{
    public IList<Venue> venues { get; set; }
}


}
