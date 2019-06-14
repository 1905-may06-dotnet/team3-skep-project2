using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Meeting
    {
        public int MID { get; set; }
        public DateTime MeetingTime { get; set; }
        public List<UserMeeting> UserMeetings { get; set; }
        public List<MeetingInvitation> MeetingInvitation { get; set; }
        public List<Rating> RatingList { get; set; }

    }
}
