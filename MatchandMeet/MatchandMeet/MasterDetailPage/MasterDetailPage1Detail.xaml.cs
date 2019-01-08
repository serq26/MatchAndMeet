using MatchandMeet.MasterDetailPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace MatchandMeet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailPage1Detail : ContentPage
    {
       
        public MasterDetailPage1Detail()
        {
            InitializeComponent();
            
        }
         private void Button_Clicked(object sender, EventArgs e)
        {
           
            //await Navigation.PushAsync(new MatchUp());
        }

        async private void ImageButton_Clicked(object sender, EventArgs e)
        {
            Frame1.IsVisible = false;
            await Navigation.PushAsync(new MatchUp());
        }
        private void ImageButton1_Clicked(object sender, EventArgs e)
        {

        }
    }
}