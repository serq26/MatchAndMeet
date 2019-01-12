using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using MatchandMeet.Services.FirebaseAuth;
using MatchandMeet.Services.FirebaseDB;
using MatchandMeet.ViewModels.Base;

using Xamarin.Forms;

namespace MatchandMeet.ViewModels.Login
{
    public class SignUpViewModel: BaseViewModelBase
    {
        private ICommand _loginCommand;
        private ICommand _signupCommand;
        private String _username;
        private String _password;
        private IUserDialogs _userDialogService;

        private IFirebaseAuthService _firebaseService;
        private IFirebaseDBService _firebaseDBService;
        public SignUpViewModel(IUserDialogs userDialogsService)
        {
            _userDialogService = userDialogsService;
            _firebaseService = DependencyService.Get<IFirebaseAuthService>();
            _firebaseDBService = DependencyService.Get<IFirebaseDBService>();
        }

        public ICommand LoginCommand
        {
            get { return _loginCommand = _loginCommand ?? new DelegateCommandAsync(LoginCommandExecute); }
        }
        public ICommand SignUpCommand
        {
            get { return _signupCommand = _signupCommand ?? new DelegateCommandAsync(SignUpCommandExecute); }
        }
        private async Task LoginCommandExecute()
        {
            await NavigationService.NavigateToAsync<LoginViewModel>();
        }
        private async Task SignUpCommandExecute()
        {
            if (await _firebaseService.SignUp(Username, Password))
            {
                if (_firebaseDBService.CreateUser())
                {
                    await NavigationService.NavigateToAsync<ProfileViewModel>();
                }
                else
                {
                    _userDialogService.Toast("The entered user is not valid");
                }
                
            }
            else
            {
                _userDialogService.Toast("The entered user is not valid");
            }

        }
        public String Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                RaisePropertyChanged();
            }
        }

        public String Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                RaisePropertyChanged();
            }
        }
    }
}
