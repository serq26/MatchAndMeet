using System;
using System.Collections.Generic;
using System.Text;

namespace MatchandMeet
{
    public class NotificationsModel
    {
        public string notice { get; set; }
        public UserAndLike userAndLike { get; set; }
    }

    public class UserAndLike
    {
        public User user { get; set; }
        public bool likeState { get; set; }
    }
}
