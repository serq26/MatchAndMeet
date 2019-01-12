using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Plugin.Geolocator;

namespace MatchandMeet
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MyCompass : ContentPage
	{

        double DEG_PER_RAD = (180.0 / Math.PI);
        public MyCompass ()
		{
			InitializeComponent ();
            GetLocation();
            //Compass.ReadingChanged += Compass_ReadingChanged1;
            //Compass.Start(SensorSpeed.UI);
           
        }

        //private async void Compass_ReadingChanged1(object sender, CompassChangedEventArgs e)
        //{

         
        //    //ImageArrow.Rotation = e.Reading.HeadingMagneticNorth;
        //}



        public double GetDirection(Location location)
        {
            Location sanFrancisco = new Location(39,099912 -94.581213);
           // Location boston = new Location(38.627089, -90.200203);
            Location boston = new Location(41.015137, 28.979530); // istanbul coordinates
            //Location location = sanFrancisco;


            double Lon = boston.Longitude - location.Longitude ;
            double y = Math.Sin(Lon) * Math.Cos(boston.Latitude);
            double x = Math.Cos(location.Latitude) * Math.Sin(boston.Latitude) - Math.Sin(location.Latitude) * Math.Cos(boston.Latitude) * Math.Cos(Lon);
            double angle = DEG_PER_RAD * Math.Atan2(y, x);

            ImageArrow.Rotation = angle;

            return angle;
        }

        public async void GetLocation()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;

            var position = await locator.GetPositionAsync(timeout: TimeSpan.FromSeconds(10000));
            Location MyLocation = new Location(position.Longitude, position.Latitude);

            Long.Text = MyLocation.Longitude.ToString();
            Lati.Text = MyLocation.Latitude.ToString();

            GetDirection(MyLocation);

          

        }

    }
}