using System;
using System.Collections.Generic;
using ExpenssesApp.Model;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace ExpenssesApp
{
    public partial class MapPage : ContentPage
    {
        private bool HasLocationPermission = false;
        public MapPage()
        {
            InitializeComponent();
            GetPermissions();
        }
        private async void GetPermissions()
        {

            try {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.LocationWhenInUse);
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.LocationWhenInUse))
                    {
                        await DisplayAlert("Location requise ", "L'application a besoin de votre location .", "Confirmer");
                    }
                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.LocationWhenInUse);
                    if (results.ContainsKey(Permission.LocationWhenInUse))
                        status = results[Permission.LocationWhenInUse];
                }
                if (status == PermissionStatus.Granted)
                {
                    HasLocationPermission = true;
                    locationMap.IsShowingUser = true;
                }
                else
                {
                    await DisplayAlert("Localisation non autorise", "L'application n'a pas acces a la localisation ", "Ok");
                }
            }
            catch(Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }

        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (HasLocationPermission)
            {
                var locator = CrossGeolocator.Current;
                locator.PositionChanged += Locator_PositionChanged;
                await locator.StartListeningAsync(TimeSpan.Zero, 100);
            }
            getLoca();

            var posts=Post.GetList();

             AfficherMap(posts);
            
        }

        private void AfficherMap(List<Post> posts)
        {
            foreach (var post in posts)
            {
                try
                {
                    var postion = new Xamarin.Forms.Maps.Position(post.Latitude, post.Longitude);
                    var pin = new Pin()
                    {
                        Type = Xamarin.Forms.Maps.PinType.Place,
                        Position = postion,
                        Label = post.VenueName,
                        Address = post.Address
                    };
                    locationMap.Pins.Add(pin);
                }
                catch (NullReferenceException nre) { }
                catch (Exception ex) { }
            }
        }

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();
            await CrossGeolocator.Current.StopListeningAsync();
            CrossGeolocator.Current.PositionChanged -= Locator_PositionChanged;
        }


        void Locator_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            MoveMap(e.Position);
        }


        private async void getLoca() 
        {
           
             if (HasLocationPermission)
            {
                var locator = CrossGeolocator.Current;
                var position = await locator.GetPositionAsync();
                MoveMap(position);
            }
        }

        private void MoveMap(Plugin.Geolocator.Abstractions.Position postion) 
        {
            var center = new Xamarin.Forms.Maps.Position(postion.Latitude, postion.Longitude);
            var span = new Xamarin.Forms.Maps.MapSpan(center, 1, 1);
            locationMap.MoveToRegion(span);
        }
    }
}
