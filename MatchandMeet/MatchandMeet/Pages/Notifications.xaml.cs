using MatchandMeet.Helpers;
using MatchandMeet.ViewModels;
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
        List<Like> likes;
        List<NotificationsModel> listItem = new List<NotificationsModel>();

        public Notifications()
        {            
            InitializeComponent();

            LoadLikesAsync();
        }
        
        private async void LoadLikesAsync()
        {
            var helper = new FirebaseHelper();
            likes = await helper.LoadLikes();

            if (likes != null)
            {
                for (int i = 0; i < likes.Capacity; i++)
                {
                    User myUser = await helper.LoadUserRequest(likes[i].senderID);

                    listItem.Add(new NotificationsModel
                    {
                        notice = myUser.Name + " liked you!"
                    });
                } 
                
                Notification.BindingContext = listItem;
            }
        }

        //public void ListItems(List<NotificationsModel> list)
        //{
        //    list.Add(new NotificationsModel
        //    {
        //        notice = likes[0].senderID + " liked you!"
        //    });
        //}      

    }
}