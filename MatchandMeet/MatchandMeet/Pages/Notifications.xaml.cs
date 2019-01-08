using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MatchandMeet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Notifications : ContentPage
    {
        List<NotificationsModel> listItem = new List<NotificationsModel>();
        public Notifications()
        {
            
            InitializeComponent();
            ListItems(listItem);
            Notification.BindingContext = listItem;
        }
    
        public void ListItems(List<NotificationsModel> list)
        {
            list.Add(new NotificationsModel
            {
               notice = "Serhat liked you !"
            });

        }
       

    }
}