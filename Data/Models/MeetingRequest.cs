using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class MeetingRequest
    {
        public int Mrid { get; set; }
        public int Lid { get; set; }
        public int Gid { get; set; }
        public int InitiatorUid { get; set; }
        public int ReceiverUid { get; set; }
        public DateTime DateAndTime { get; set; }

        public virtual BoardGame G { get; set; }
        public virtual BGUser InitiatorU { get; set; }
        public virtual BGLocation L { get; set; }
        public virtual BGUser ReceiverU { get; set; }
    }
}
