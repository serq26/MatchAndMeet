using MatchandMeet.ViewModels;
using System;
using System.Threading.Tasks;

namespace MatchandMeet.Services.FirebaseDB
{
    public interface IFirebaseDBService
    {
        void Connect();
        void GetMessage();
        void SetMessage(String message);
        String GetMessageKey();
        bool CreateUser();
        Task<string> CreateLike();
    }
}
