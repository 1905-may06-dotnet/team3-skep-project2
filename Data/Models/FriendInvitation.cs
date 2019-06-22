using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class FriendInvitation
    {
        public int Fiid { get; set; }
        public int SenderUid { get; set; }
        public int ReceiverUid { get; set; }

        public virtual BGUser ReceiverU { get; set; }
        public virtual BGUser SenderU { get; set; }
    }
}
