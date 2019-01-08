using MatchandMeet.Services.Navigation;
using MatchandMeet.ViewModels.Base;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MatchandMeet
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
#if DEBUG
            LiveReload.Init();
#endif


        }

        protected override void OnStart()
        {
            // Handle when your app starts
            base.OnStart();

            InitNavigation();
        }
        private Task InitNavigation()
        {
            var navigationService = ViewModelLocator.Instance.Resolve<INavigationService>();
            return navigationService.InitializeAsync();
        }


        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
