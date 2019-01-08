using MatchandMeet.ViewModels.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace MatchandMeet.Views.Login
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginView : ContentPage
	{
        LoginViewModel viewModel;

        public LoginView ()
		{
			InitializeComponent ();

            viewModel = BindingContext as LoginViewModel;

            if (viewModel != null) viewModel.OnAppearing(null);
        }
	}

    //protected override void OnAppearing()
    //{
    //    viewModel = BindingContext as LoginViewModel;

    //    if (viewModel != null) viewModel.OnAppearing(null);
    //}
}