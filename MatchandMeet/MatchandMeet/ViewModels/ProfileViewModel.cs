using Acr.UserDialogs;
using MatchandMeet.Services.FirebaseAuth;
using MatchandMeet.Services.FirebaseDB;
using MatchandMeet.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MatchandMeet.ViewModels
{
    public class ProfileViewModel : BaseViewModelBase
    {
        private IFirebaseAuthService _firebaseAuthService;
        private IFirebaseDBService _firebaseDatabaseService;
        private IUserDialogs _userDialogService;
        private IFirebaseAuthService _firebaseService;

        public ProfileViewModel(IUserDialogs userDialogServices)
        {
            _userDialogService = userDialogServices;
            _firebaseAuthService = DependencyService.Get<IFirebaseAuthService>();
            _firebaseDatabaseService = DependencyService.Get<IFirebaseDBService>();
            _firebaseDatabaseService.Connect();

        }
    }
}
