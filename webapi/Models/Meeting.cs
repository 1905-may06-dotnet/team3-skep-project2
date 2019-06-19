using System;
using System.Collections.Generic;

namespace webapi.Models
{
    public partial class Meeting
    {
        public Meeting()
        {
            MeetingInvitation = new HashSet<MeetingInvitation>();
            Rating = new HashSet<Rating>();
            UserMeeting = new HashSet<UserMeeting>();
        }

        public int Mid { get; set; }
        public int Lid { get; set; }
        public int Gid { get; set; }
        public int HostUid { get; set; }
        public DateTime DateAndTime { get; set; }

        public virtual BoardGame G { get; set; }
        public virtual BGUser HostU { get; set; }
        public virtual BGLocation L { get; set; }
        public virtual ICollection<MeetingInvitation> MeetingInvitation { get; set; }
        public virtual ICollection<Rating> Rating { get; set; }
        public virtual ICollection<UserMeeting> UserMeeting { get; set; }
    }
}
