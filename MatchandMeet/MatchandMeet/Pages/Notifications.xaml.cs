using MatchandMeet.Helpers;
using MatchandMeet.MasterDetailPage;
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
        List<Like> acceptedLikes;
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
            acceptedLikes = await helper.LoadAcceptedLikes();

            if (likes != null)
            {
                for (int i = 0; i < likes.Count; i++)
                {
                    User myUser = await helper.LoadUserRequest(likes[i].senderID);

                    listItem.Add(new NotificationsModel
                    {
                        notice = myUser.Name + " liked you!",
                        user = myUser
                    });
                } 
            }

            if (acceptedLikes != null)
            {
                for (int i = 0; i < acceptedLikes.Count; i++)
                {
                    User myUser = await helper.LoadUserRequest(acceptedLikes[i].receiverID);

                    listItem.Add(new NotificationsModel
                    {
                        notice = myUser.Name + " accepted your like!",
                        user = myUser
                    });
                }               
            }

            Notification.BindingContext = listItem;
        }

        private void TextCell_Tapped(object sender, EventArgs e)
        {
            TextCell t = (TextCell)sender;
            // t.CommandParameter.ToString();
            User user = (User)t.CommandParameter;
            Navigation.PushModalAsync(new MatchUp(user));

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