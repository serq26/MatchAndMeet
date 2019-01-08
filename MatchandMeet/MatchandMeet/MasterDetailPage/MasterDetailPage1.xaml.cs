using MatchandMeet.ViewModels;
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
    public partial class MasterDetailPage1 : Xamarin.Forms.MasterDetailPage
    {
        MasterDetailViewModel viewModel;//

        public MasterDetailPage1()
        {
            InitializeComponent();
            viewModel = BindingContext as MasterDetailViewModel;//

            if (viewModel != null) viewModel.OnAppearing(null);//

            NavigationPage.SetHasNavigationBar(this, false);
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterDetailPage1MenuItem;
            if (item == null)
                return;

            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;

            Detail = new NavigationPage(page);
            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }
    }
}