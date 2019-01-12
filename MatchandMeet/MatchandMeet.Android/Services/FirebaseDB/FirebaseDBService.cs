using System;
using Xamarin.Forms;
using Firebase.Database;
using MatchandMeet.Services.FirebaseDB;
using MatchandMeet.Droid;
using MatchAndMeet.Droid.Services.FirebaseAuth;
using MatchAndMeet.Droid.Services.FirebaseDB;
using System.Threading.Tasks;
using MatchandMeet.ViewModels;

[assembly: Dependency(typeof(FirebaseDBService))]
namespace MatchAndMeet.Droid.Services.FirebaseDB
{
    public class ValueEventListener : Java.Lang.Object, IValueEventListener
    {
        public void OnCancelled(DatabaseError error) { }

        public void OnDataChange(DataSnapshot snapshot) {
            if (snapshot.Value != null)
            {
                String message = snapshot.Value.ToString();
                MessagingCenter.Send(FirebaseDBService.KEY_MESSAGE, FirebaseDBService.KEY_MESSAGE, message);
            }
        }
    }

    public class FirebaseDBService : IFirebaseDBService
    {
        DatabaseReference databaseReference;
        FirebaseDatabase database;
        FirebaseAuthService authService = new FirebaseAuthService();
        public static String KEY_MESSAGE = "message";

        public void Connect()
        {
            database = FirebaseDatabase.GetInstance(MainActivity.app);
        }

        public void GetMessage()
        {
            var userId = authService.GetUserId();
            databaseReference = database.GetReference("messages/" + userId);
            databaseReference.AddValueEventListener(new ValueEventListener());            
        }

        public string GetMessageKey()
        {
            return KEY_MESSAGE;
        }

        public void SetMessage(string message)
        {
            var userId = authService.GetUserId();
            databaseReference = database.GetReference("messages/" + userId);
            databaseReference.SetValue(message);
        }

        public bool CreateUser()
        {
            try
            {
                Connect();
                var userId = authService.GetUserId();
                databaseReference = database.GetReference("users/" + userId);
                databaseReference.SetValue("");

                return true;
            }
            catch (Exception)
            {

                return false;
            }  
        }

        public async Task<string> CreateLike()
        {
            try
            {
                Connect();                
                Guid id = Guid.NewGuid();
                databaseReference = database.GetReference("likes/" + id);
                await databaseReference.SetValueAsync("");

                return id.ToString();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
