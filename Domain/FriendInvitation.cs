using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class FriendInvitation
    {
        public int FIID { get; set; }
        public int SenderUid { get; set; }
        public int ReceiverUid { get; set; }
    }
}
