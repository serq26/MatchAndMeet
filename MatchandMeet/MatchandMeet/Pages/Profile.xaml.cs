﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Media;
using System.IO;
using MatchandMeet.Helpers;
using System.Diagnostics;
using MatchandMeet.MasterDetailPage;

namespace MatchandMeet
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Profile : ContentPage 
	{
     
        Stream imgStr;

		public Profile ()
		{
			InitializeComponent ();
                       
		}

       

       async private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            var imgData = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions());

            if (imgData != null)
            {

                Image.Source = ImageSource.FromStream(() => imgStr);
                imgStr = imgData.GetStream();
            }

            //await dbfire.saveImage(imgData.GetStream());
            Image.Source = ImageSource.FromStream(imgData.GetStream);

            Add_Image.IsVisible = false;
            Add_Img_Text.IsVisible = false;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            var fire = new FirebaseImgUpload();
            var txt = EntryName.Text;
            var age = EntryAge.Text;
            var city = picker.SelectedItem.ToString();
            await fire.SaveUserRequest(imgStr, new User { Name = txt , Age = age, City = city });

            var answer = await DisplayAlert("Match&Meet", "You have been registered!", "OK","Cancel");
            if(answer)
            {
                await Navigation.PushAsync(new MasterDetailPage1Detail());
                Navigation.RemovePage(this);
            }
           
        }



        void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                //monkeyNameLabel.Text = (string)picker.ItemsSource[selectedIndex];
            }
        }

        
    }
}