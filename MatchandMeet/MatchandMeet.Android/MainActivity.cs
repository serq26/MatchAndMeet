using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Firebase;
using Android.Content;
using Acr.UserDialogs;
using Android.Gms.Auth.Api.SignIn;
using Xamarin.Forms;
using MatchAndMeet.Droid.Services.FirebaseAuth;
using Plugin.Permissions;

namespace MatchandMeet.Droid
{
    [Activity(Label = "MatchandMeet", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static FirebaseApp app;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            InitFirebaseAuth();
            UserDialogs.Init(this);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Plugin.CurrentActivity.CrossCurrentActivity.Current.Init(this, savedInstanceState);


            LoadApplication(new App());
        }

        private void InitFirebaseAuth()
        {
            var options = new FirebaseOptions.Builder()
            .SetApplicationId("1:612011807928:android:c975122305aafc5f")
            .SetApiKey("AIzaSyBmDcNh9MwHtKX0mMM6QkWT6_PjeYEoEtg")
            .SetDatabaseUrl("https://bim493project.firebaseio.com/")
            //.SetApplicationId("1:115096532451:android:f8e4b7a510165d52")
            //.SetApiKey("AIzaSyBc8yaTHpT_XT5XZqwA3-ZoQpWrqrsCg9U")
            //.SetDatabaseUrl("https://matchandmeet-f2943.firebaseio.com")
            .Build();



            if (app == null)
                app = FirebaseApp.InitializeApp(this, options, "bim493project");

        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (requestCode == FirebaseAuthService.REQ_AUTH && resultCode == Result.Ok)
            {
                GoogleSignInAccount sg = (GoogleSignInAccount)data.GetParcelableExtra("result");
                MessagingCenter.Send(FirebaseAuthService.KEY_AUTH, FirebaseAuthService.KEY_AUTH, sg.IdToken);
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        //public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        //{
        //   PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        //}
    }
}