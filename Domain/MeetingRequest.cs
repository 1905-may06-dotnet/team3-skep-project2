using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class MeetingRequest
    {
        public int MRID { get; set; }
        public int Lid { get; set; }
        public int Gid { get; set; }
        public int InitiatorUid { get; set; }
        public int ReceiverUid { get; set; }
        public DateTime MeetingTime { get; set; }
    }
}
