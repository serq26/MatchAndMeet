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

        public MatchUp(User user)
        {
            InitializeComponent();
            GetLocation();
            selectedUser = user;

            userName.Text = selectedUser.Name;
            userAge.Text = selectedUser.Age;
            userImage.Source = selectedUser.ImageUrl;           
        }
        
        public async void GetLocation()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;

            var position = await locator.GetPositionAsync(timeout: TimeSpan.FromSeconds(10000));

            LogitudeLabel.Text = position.Longitude.ToString();
            LatitudeLabel.Text = position.Latitude.ToString();

            Location MyLocation = new Location(position.Longitude, position.Latitude);
            Location boston = new Location(42.358056, -71.063611);
            Location sanFrancisco = new Location(37.783333, -122.416667);

            double miles = Location.CalculateDistance(boston, MyLocation, DistanceUnits.Miles);

            DistanceLabel.Text = miles.ToString();            
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