using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MatchandMeet.Services.FirebaseAuth;
using MatchandMeet.ViewModels;
using MatchandMeet.ViewModels.Base;
using MatchandMeet.ViewModels.Login;

using MatchandMeet.Views.Login;

using Xamarin.Forms;

namespace MatchandMeet.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        protected readonly Dictionary<Type, Type> _mappings;

        protected Application CurrentApplication
        {
            get
            {
                return Application.Current;
            }
        }

        public NavigationService()
        {
            _mappings = new Dictionary<Type, Type>();

            CreatePageViewModelMappings();
        }

        public Task InitializeAsync()
        {
            var _firebaseService = DependencyService.Get<IFirebaseAuthService>();

            if (_firebaseService.IsUserSigned())
            {
                
                return NavigateToAsync<MasterDetailViewModel>();
            }
            else{
                return NavigateToAsync<LoginViewModel>(); 
            }
        }

        public Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModelBase
        {
            return NavigateToAsync(typeof(TViewModel), null);
        }

        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseViewModelBase
        {
            return NavigateToAsync(typeof(TViewModel), parameter);
        }

        public Task NavigateToAsync(Type viewModelType)
        {
            return NavigateToAsync(viewModelType, null);
        }

        protected virtual async Task NavigateToAsync(Type viewModelType, object parameter)
        {
            Page page = CreateAndBindPage(viewModelType, parameter);
            CurrentApplication.MainPage = page;

        }

        protected Type GetPageTypeForViewModel(Type viewModelType)
        {
            if (!_mappings.ContainsKey(viewModelType))
            {
                throw new KeyNotFoundException($"No map for ${viewModelType} was found on navigation mappings");
            }

            return _mappings[viewModelType];
        }

        protected Page CreateAndBindPage(Type viewModelType, object parameter)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);

            if (pageType == null)
            {
                throw new Exception($"Mapping type for {viewModelType} is not a page");
            }

            Page page = Activator.CreateInstance(pageType) as Page;
            BaseViewModelBase viewModel = ViewModelLocator.Instance.Resolve(viewModelType) as BaseViewModelBase;
            viewModel.Parameter = parameter;
            page.BindingContext = viewModel;

            page.Appearing += async (object sender, EventArgs e) =>
            {
                await viewModel.InitializeAsync(parameter);
            };

            return page;
        }
        private void CreatePageViewModelMappings()
        {
          
            _mappings.Add(typeof(MasterDetailViewModel), typeof(MasterDetailPage1));
            _mappings.Add(typeof(LoginViewModel), typeof(LoginView));
            _mappings.Add(typeof(SignUpViewModel), typeof(SignUpView));
          

        }

        public async Task NavigateBackAsync()
        {
            if (CurrentApplication.MainPage != null)
            {
                await CurrentApplication.MainPage.Navigation.PopAsync();
            }
        }
    }
}
