using MatchandMeet.Helpers;
using MatchandMeet.MasterDetailPage;
using MatchandMeet.Services.FirebaseDB;
using MatchandMeet.ViewModels;
using Plugin.Geolocator;
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
        IFirebaseDBService _firebaseDBService;
        List<User> loadedUsers;

        public MasterDetailPage1Detail()
        {
            InitializeComponent();

            GetLocation();
            LoadAllUserInfo();

            _firebaseDBService = DependencyService.Get<IFirebaseDBService>();
        }

        async void GetLocation()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;

            var position = await locator.GetPositionAsync(timeout: TimeSpan.FromSeconds(10000));
            string location = position.Longitude.ToString() + " " + position.Latitude.ToString();

            var fire = new FirebaseHelper();
            await fire.SaveUserLocation(location);
        }

        async void LoadAllUserInfo()
        {
            var fire = new FirebaseHelper();
            loadedUsers = await fire.LoadAllUserRequest();

            if (loadedUsers != null)
            {
                try
                {
                    UserName.Text = loadedUsers[0].Name + ", " + loadedUsers[0].Age;
                    UserImage.Source = loadedUsers[0].ImageUrl;

                    UserName2.Text = loadedUsers[1].Name + ", " + loadedUsers[1].Age;
                    UserImage2.Source = loadedUsers[1].ImageUrl;

                    UserName3.Text = loadedUsers[2].Name + ", " + loadedUsers[2].Age;
                    UserImage3.Source = loadedUsers[2].ImageUrl;

                    UserName4.Text = loadedUsers[3].Name + ", " + loadedUsers[3].Age;
                    UserImage4.Source = loadedUsers[3].ImageUrl;

                    UserName5.Text = loadedUsers[4].Name + ", " + loadedUsers[4].Age;
                    UserImage5.Source = loadedUsers[4].ImageUrl;

                    UserName6.Text = loadedUsers[5].Name + ", " + loadedUsers[5].Age;
                    UserImage6.Source = loadedUsers[5].ImageUrl;

                    UserName7.Text = loadedUsers[6].Name + ", " + loadedUsers[6].Age;
                    UserImage7.Source = loadedUsers[6].ImageUrl;

                    UserName8.Text = loadedUsers[7].Name + ", " + loadedUsers[7].Age;
                    UserImage8.Source = loadedUsers[7].ImageUrl;

                    UserName9.Text = loadedUsers[8].Name + ", " + loadedUsers[8].Age;
                    UserImage9.Source = loadedUsers[8].ImageUrl;

                    UserName10.Text = loadedUsers[9].Name + ", " + loadedUsers[9].Age;
                    UserImage10.Source = loadedUsers[9].ImageUrl;
                }
                catch (Exception)
                {

                }
            }
        }

        async private void ImageButton_Clicked(object sender, EventArgs e)
        {
            string id = await _firebaseDBService.CreateLike();

            if (id != null)
            {
                var helper = new FirebaseHelper();
                if (await helper.SaveLike(id, new Like { receiverID = loadedUsers[0].UserID }))
                {
                    Frame1.IsVisible = false;                    
                }
            }
        }

        async private void ImageButton1_Clicked(object sender, EventArgs e)
        {
            string id = await _firebaseDBService.CreateLike();

            if (id != null)
            {
                var helper = new FirebaseHelper();
                if (await helper.SaveLike(id, new Like { receiverID = loadedUsers[1].UserID }))
                {
                    Frame2.IsVisible = false;
                }
            }
        }

        async private void ImageButton2_Clicked(object sender, EventArgs e)
        {
            string id = await _firebaseDBService.CreateLike();

            if (id != null)
            {
                var helper = new FirebaseHelper();
                if (await helper.SaveLike(id, new Like { receiverID = loadedUsers[2].UserID }))
                {
                    Frame3.IsVisible = false;
                }
            }
        }

        async private void ImageButton3_Clicked(object sender, EventArgs e)
        {
            string id = await _firebaseDBService.CreateLike();

            if (id != null)
            {
                var helper = new FirebaseHelper();
                if (await helper.SaveLike(id, new Like { receiverID = loadedUsers[3].UserID }))
                {
                    Frame4.IsVisible = false;
                }
            }
        }

        async private void ImageButton4_Clicked(object sender, EventArgs e)
        {
            string id = await _firebaseDBService.CreateLike();

            if (id != null)
            {
                var helper = new FirebaseHelper();
                if (await helper.SaveLike(id, new Like { receiverID = loadedUsers[4].UserID }))
                {
                    Frame5.IsVisible = false;
                }
            }
        }

        async private void ImageButton5_Clicked(object sender, EventArgs e)
        {
            string id = await _firebaseDBService.CreateLike();

            if (id != null)
            {
                var helper = new FirebaseHelper();
                if (await helper.SaveLike(id, new Like { receiverID = loadedUsers[5].UserID }))
                {
                    Frame6.IsVisible = false;
                }
            }
        }

        async private void ImageButton6_Clicked(object sender, EventArgs e)
        {
            string id = await _firebaseDBService.CreateLike();

            if (id != null)
            {
                var helper = new FirebaseHelper();
                if (await helper.SaveLike(id, new Like { receiverID = loadedUsers[6].UserID }))
                {
                    Frame7.IsVisible = false;
                }
            }
        }

        async private void ImageButton7_Clicked(object sender, EventArgs e)
        {
            string id = await _firebaseDBService.CreateLike();

            if (id != null)
            {
                var helper = new FirebaseHelper();
                if (await helper.SaveLike(id, new Like { receiverID = loadedUsers[7].UserID }))
                {
                    Frame8.IsVisible = false;
                }
            }
        }

        async private void ImageButton8_Clicked(object sender, EventArgs e)
        {
            string id = await _firebaseDBService.CreateLike();

            if (id != null)
            {
                var helper = new FirebaseHelper();
                if (await helper.SaveLike(id, new Like { receiverID = loadedUsers[8].UserID }))
                {
                    Frame9.IsVisible = false;
                }
            }
        }

        async private void ImageButton9_Clicked(object sender, EventArgs e)
        {
            string id = await _firebaseDBService.CreateLike();

            if (id != null)
            {
                var helper = new FirebaseHelper();
                if (await helper.SaveLike(id, new Like { receiverID = loadedUsers[9].UserID }))
                {
                    Frame10.IsVisible = false;
                }
            }
        }
        private void Cancel_Clicked(object sender, EventArgs e)
        {
            Frame1.IsVisible = false;
        }

        private void Cancel1_Clicked(object sender, EventArgs e)
        {
            Frame2.IsVisible = false;
        }
        private void Cancel2_Clicked(object sender, EventArgs e)
        {
            Frame3.IsVisible = false;
        }
        private void Cancel3_Clicked(object sender, EventArgs e)
        {
            Frame4.IsVisible = false;
        }
        private void Cancel4_Clicked(object sender, EventArgs e)
        {
            Frame5.IsVisible = false;
        }
        private void Cancel5_Clicked(object sender, EventArgs e)
        {
            Frame6.IsVisible = false;
        }
        private void Cancel6_Clicked(object sender, EventArgs e)
        {
            Frame7.IsVisible = false;
        }
        private void Cancel7_Clicked(object sender, EventArgs e)
        {
            Frame8.IsVisible = false;
        }
        private void Cancel8_Clicked(object sender, EventArgs e)
        {
            Frame9.IsVisible = false;
        }
        private void Cancel9_Clicked(object sender, EventArgs e)
        {
            Frame10.IsVisible = false;
        }

    }
}