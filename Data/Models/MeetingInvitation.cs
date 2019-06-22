using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class MeetingInvitation
    {
        public int Miid { get; set; }
        public int InitiatorUid { get; set; }
        public int ReceiverUid { get; set; }
        public int Mid { get; set; }

        public virtual BGUser InitiatorU { get; set; }
        public virtual Meeting M { get; set; }
        public virtual BGUser ReceiverU { get; set; }
    }
}
