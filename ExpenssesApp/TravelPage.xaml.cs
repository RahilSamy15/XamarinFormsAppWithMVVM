using System;
using System.Collections.Generic;
using System.Linq;

using ExpenssesApp.Model;
using Plugin.Geolocator;
using SQLite;
using Xamarin.Forms;

namespace ExpenssesApp
{
    public partial class TravelPage : ContentPage
    {
        Post post;
        public TravelPage()
        {
            InitializeComponent();
            post = new Post();
            MonStack.BindingContext = post;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync();

            var venues = await Venue.getVenues(position.Latitude, position.Longitude);
            VenueListView.ItemsSource = venues;
        }
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            try { 
            var selectedVenue = VenueListView.SelectedItem as Venue;
            var firstCategory = selectedVenue.categories.FirstOrDefault();



                
            post.CategoryId = firstCategory.id;
            post.CategoryName = firstCategory.name;
            post.Address = selectedVenue.location.address;
            post.Distance = selectedVenue.location.distance;
            post.Latitude = selectedVenue.location.lat;
            post.Longitude = selectedVenue.location.lng;
            post.VenueName = selectedVenue.name;
            
           
               if(Post.InsertPost(post)>0)
                        DisplayAlert("Succes", "Votre exprience a bien été ajouter .", "OK");
                    else
                        DisplayAlert("Echouer", "L'ajout de votre experience a echouer veuillez reessayer .", "OK");
                
            }
            catch(NullReferenceException nre)
            {

            }
            catch(Exception ex) 
            {
            }
        }

    }
}
