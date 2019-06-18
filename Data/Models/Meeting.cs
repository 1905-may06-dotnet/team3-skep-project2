using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Meeting
    {
        public Meeting()
        {
            MeetingInvitation = new List<MeetingInvitation>();
            Rating = new List<Rating>();
            MeetingMenber = new List<MeetingMenber>();
        }

        public int Mid { get; set; }
        public int Lid { get; set; }
        public int Gid { get; set; }
        public int HostUid { get; set; }
        public DateTime DateAndTime { get; set; }

        public virtual BoardGame G { get; set; }
        public virtual BGUser HostU { get; set; }
        public virtual BGLocation L { get; set; }
        public virtual List<MeetingInvitation> MeetingInvitation { get; set; }
        public virtual List<Rating> Rating { get; set; }
        public virtual List<MeetingMenber> MeetingMenber { get; set; }
    }
}
