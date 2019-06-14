using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Models
{
    public class Meeting
    {
        [Key]
        public int MID { get; set; }
        public DateTime MeetingTime { get; set; }
        public IList<UserMeeting> UserMeetings { get; set; }
        public IList<MeetingInvitation> MeetingInvitation { get; set; }
        public IList<Rating> RatingList { get; set; }
    }
}
