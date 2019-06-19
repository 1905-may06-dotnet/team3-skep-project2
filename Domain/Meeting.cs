using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Meeting
    {
        public int MID { get; set; }
        public int Lid { get; set; }
        public int Gid { get; set; }
        public int HostUid { get; set; }
        public DateTime MeetingTime { get; set; }

        public List<BGUser> MeetingMenbers { get; set; }
        public List<MeetingInvitation> MeetingInvitations { get; set; }
        public List<Rating> Ratings { get; set; }
        public Meeting()
        {
            MeetingInvitations = new List<MeetingInvitation>();
            Ratings = new List<Rating>();
            MeetingMenbers = new List<BGUser>();
        }

    }
}
