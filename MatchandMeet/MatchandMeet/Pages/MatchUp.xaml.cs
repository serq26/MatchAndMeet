using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;


using Plugin.Geolocator;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using MatchandMeet.Helpers;

namespace MatchandMeet.MasterDetailPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MatchUp : ContentPage
    {
        User selectedUser;
        double DEG_PER_RAD = (180.0 / Math.PI);
        public MatchUp(User user)
        {
            InitializeComponent();
            GetLocation();
            selectedUser = user;

            userName.Text = selectedUser.Name + ","+ selectedUser.Age;
          
            userImage.Source = selectedUser.ImageUrl;           
        }

        public async void GetLocation()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;

      

            var position = await locator.GetPositionAsync(timeout: TimeSpan.FromSeconds(10000));
            Location MyLocation = new Location(position.Longitude, position.Latitude);


            string[] locs = selectedUser.Location.Split(' ');
            Location selectedUserLocation = new Location(double.Parse(locs[0]), double.Parse(locs[1])); 

            double miles = Location.CalculateDistance(selectedUserLocation, MyLocation, DistanceUnits.Miles);


            distance.Text =((int)miles).ToString() + "m";

            GetDirection(MyLocation);



        }

        public double GetDirection(Location location)
        {
            Location sanFrancisco = new Location(39, 099912 - 94.581213);
            // Location boston = new Location(38.627089, -90.200203);
            Location boston = new Location(41.015137, 28.979530); // istanbul coordinates
            //Location location = sanFrancisco;


            double Lon = boston.Longitude - location.Longitude;
            double y = Math.Sin(Lon) * Math.Cos(boston.Latitude);
            double x = Math.Cos(location.Latitude) * Math.Sin(boston.Latitude) - Math.Sin(location.Latitude) * Math.Cos(boston.Latitude) * Math.Cos(Lon);
            double angle = DEG_PER_RAD * Math.Atan2(y, x);

            ImageArrow.Rotation = angle;

            return angle;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            AcceptLike();
        }

        public async void AcceptLike()
        {
            var helper = new FirebaseHelper();

            if (await helper.AcceptLike(selectedUser))
            {
                ImageArrow.IsVisible = true;
                acceptbutton.IsVisible = false;
            }
        }        

        //public async void OnButtonClicked(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
        //        if (status != PermissionStatus.Granted)
        //        {
        //            if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
        //            {
        //                await DisplayAlert("Need location", "Gunna need that location", "OK");
        //            }

        //            var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Location });
        //            status = results[Permission.Location];
        //        }

        //        if (status == PermissionStatus.Granted)
        //        {
        //            var results = await CrossGeolocator.Current.GetPositionAsync(TimeSpan.FromMilliseconds(10000));
        //            DistanceLabel.Text = "Lat: " + results.Latitude + " Long: " + results.Longitude;
        //        }
        //        else if (status != PermissionStatus.Unknown)
        //        {
        //            await DisplayAlert("Location Denied", "Can not continue, try again.", "OK");
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        DistanceLabel.Text = "Error: " + ex;
        //    }
        //}

    }
}