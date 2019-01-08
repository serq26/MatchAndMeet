using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;


using Plugin.Geolocator;

namespace MatchandMeet.MasterDetailPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MatchUp : ContentPage
    {
        public MatchUp()
        {
            InitializeComponent();
           // GetLocation();
        }
        //public async void GetLocation()
        //{
        //    var locator = CrossGeolocator.Current;
        //    locator.DesiredAccuracy = 50;

        //    var position = await locator.GetPositionAsync(timeout: TimeSpan.FromSeconds(10000));

        //    LogitudeLabel.Text = position.Longitude.ToString();
        //    LatitudeLabel.Text = position.Latitude.ToString();

        //    Location MyLocation = new Location(position.Longitude, position.Latitude);
        //    Location boston = new Location(42.358056, -71.063611);
        //    Location sanFrancisco = new Location(37.783333, -122.416667);

        //    double miles = Location.CalculateDistance(boston, MyLocation, DistanceUnits.Miles);
          
        //    DistanceLabel.Text = miles.ToString();
        //}

        public async void OnButtonClicked(object sender, EventArgs e)
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

    }
}