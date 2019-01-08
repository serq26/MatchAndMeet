using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
namespace MatchandMeet
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MyCompass : ContentPage
	{
		public MyCompass ()
		{
			InitializeComponent ();
            Compass.ReadingChanged += Compass_ReadingChanged1;
            Compass.Start(SensorSpeed.UI);
		}

        private void Compass_ReadingChanged1(object sender, CompassChangedEventArgs e)
        {
            ImageArrow.Rotation = e.Reading.HeadingMagneticNorth;
        }

       

    }
}