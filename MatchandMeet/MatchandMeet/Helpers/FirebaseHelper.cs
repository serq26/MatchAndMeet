using System;
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
using System.Linq;
using MatchandMeet.ViewModels;

namespace MatchandMeet.Helpers
{
    public class FirebaseHelper
    {
        FirebaseClient client;
        FirebaseStorage storage;
        IFirebaseAuthService authService;

        public FirebaseHelper()
        {
            client = new FirebaseClient("https://bim493project.firebaseio.com/");
            storage = new FirebaseStorage("bim493project.appspot.com");
            //client = new FirebaseClient("https://matchandmeet-f2943.firebaseio.com");
            //storage = new FirebaseStorage("matchandmeet-f2943.appspot.com");

            authService = DependencyService.Get<IFirebaseAuthService>();
        }

        public async Task<bool> SaveUserRequest(Stream imgStream, User req)
        {
            var imgURL = "";

            try
            {
                imgURL = await storage.Child("Image")
                         .Child("MaM")
                         .Child(authService.GetUserId())
                         .PutAsync(imgStream);
            }
            catch (Exception)
            {              
            }

            req.ImageUrl = imgURL;
            req.UserID = authService.GetUserId();

            var updateData = client.Child("users/" + authService.GetUserId()).PutAsync<User>(req);

            return true;
        }

        public async Task<bool> SaveUserLocation(string location)
        {
            User myUser = await LoadUserRequest();
            myUser.Location = location;

            var updateData = client.Child("users/" + authService.GetUserId()).PutAsync<User>(myUser);

            return true;
        }

        public async Task<User> LoadUserRequest()
        {
            return await client.Child("users/" + authService.GetUserId()).OnceSingleAsync<User>();
        }

        public async Task<User> LoadUserRequest(string id)
        {
            return await client.Child("users/" + id).OnceSingleAsync<User>();
        }

        public async Task<List<User>> LoadAllUserRequest()
        {
            try
            {
                User myUser = await LoadUserRequest();

                var list = (await client
                                .Child("users/")
                                .OnceAsync<User>())
                                .Where(item => item.Key != authService.GetUserId() && item.Object.Gender != myUser.Gender)
                                .Select(item =>
                                            new User
                                            {
                                                UserID = item.Object.UserID,
                                                Name = item.Object.Name,
                                                Age = item.Object.Age,
                                                City = item.Object.City,
                                                ImageUrl = item.Object.ImageUrl
                                            })
                                .ToList();

                return list;
            }
            catch (Exception)
            {
                return null;
            }            
        }

        public async Task<bool> SaveLike(string id, Like like)
        {
            try
            {
                like.senderID = authService.GetUserId();

                await client.Child("likes/" + id).PutAsync<Like>(like);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<Like>> LoadLikes()
        {
            try
            {
                var list = (await client.Child("likes/")
                            .OnceAsync<Like>())
                            .Where(item => item.Object.receiverID == authService.GetUserId() && item.Object.accepted == false)
                            .Select(item => new Like {
                                likeID = item.Key,
                                accepted = item.Object.accepted,
                                receiverID = item.Object.receiverID,
                                senderID = item.Object.senderID
                            })
                            .ToList();

                return list;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> AcceptLike(User user)
        {
            try
            {
                Like acceptedLike = new Like();
                string myUserID = authService.GetUserId();

                List<Like> likes = await LoadLikes();

                if (likes != null)
                {
                    for (int i = 0; i < likes.Count; i++)
                    {
                        if (likes[i].senderID == user.UserID)
                        {
                            acceptedLike = likes[i];
                            break;
                        }
                    }

                    acceptedLike.accepted = true;

                    await client.Child("likes/" + acceptedLike.likeID).PatchAsync<Like>(acceptedLike);

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }



        
    }
}