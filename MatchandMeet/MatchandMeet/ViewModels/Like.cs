using System;
using System.Collections.Generic;
using System.Text;

namespace MatchandMeet.ViewModels
{
    public class Like
    {
        public string senderID { get; set; }
        public string receiverID { get; set; }
        public bool accepted { get; set; }
    }
}
