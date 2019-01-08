﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Firebase.Storage;
//using Firebase.Xamarin.Database;
using Firebase.Database.Query;
using Firebase.Database;
using MatchandMeet.Services.FirebaseAuth;
using Xamarin.Forms;

namespace MatchandMeet.Helpers
{
    public class FirebaseImgUpload 
    {
        FirebaseClient client;
        FirebaseStorage storage;
        IFirebaseAuthService _firebaseAuthService;

        public FirebaseImgUpload()
        {
            client = new FirebaseClient("https://bim493project.firebaseio.com/");
            storage = new FirebaseStorage("bim493project.appspot.com");
            _firebaseAuthService = DependencyService.Get<IFirebaseAuthService>();

            //var getData =  client.Child(_firebaseAuthService.GetUserId()).OrderByKey().OnceAsync<User>();
        }

        public async Task<bool> SaveUserRequest(Stream imgStream, User req)
        {

          //var postData = await client.Child(_firebaseAuthService.GetUserId()).PostAsync<User>(req);

            var imgUrl = await storage.Child("Image")
                 .Child("MaM")
                 .Child(_firebaseAuthService.GetUserId())
                 .PutAsync(imgStream);

            req.ImageUrl = imgUrl;

            var updateData = client.Child("users/" + _firebaseAuthService.GetUserId()).PutAsync<User>(req);

            return true;
        }
    }
}
