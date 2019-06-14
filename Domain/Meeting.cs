using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Meeting
    {
        public int MID { get; set; }
        public DateTime MeetingTime { get; set; }
        public IList<UserMeeting> UserMeetings { get; set; }
        public IList<MeetingInvitation> MeetingInvitation { get; set; }
        public IList<Rating> RatingList { get; set; }

    }
}
