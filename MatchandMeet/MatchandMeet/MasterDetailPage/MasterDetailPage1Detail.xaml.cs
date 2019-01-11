using MatchandMeet.Helpers;
using MatchandMeet.MasterDetailPage;
using System;
using System.Collections.Generic;
using System.IO;
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
       
        List<User> loadedUsers;
        public MasterDetailPage1Detail()
        {
            InitializeComponent();
           
            LoadAllUserInfo();           
        }

        async void LoadAllUserInfo()
        {
            var fire = new FirebaseImgUpload();
            loadedUsers = await fire.LoadAllUserRequest();

            if (loadedUsers != null)
            {
                UserName.Text = loadedUsers[0].Name +","+ " " + loadedUsers[0].Age;
                UserImage.Source = loadedUsers[0].ImageUrl;

                UserName2.Text = loadedUsers[1].Name + "," + " " + loadedUsers[1].Age;
                UserImage2.Source = loadedUsers[1].ImageUrl;

                UserName3.Text = loadedUsers[2].Name + "," + " " + loadedUsers[2].Age;
                UserImage3.Source = loadedUsers[2].ImageUrl;

                UserName4.Text = loadedUsers[3].Name + "," + " " + loadedUsers[3].Age;
                UserImage4.Source = loadedUsers[3].ImageUrl;

                UserName5.Text = loadedUsers[4].Name + "," + " " + loadedUsers[4].Age;
                UserImage5.Source = loadedUsers[4].ImageUrl;
            }
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