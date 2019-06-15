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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MID { get; set; }
        public DateTime MeetingTime { get; set; }
        public List<UserMeeting> UserMeetings { get; set; }
        public List<MeetingInvitation> MeetingInvitation { get; set; }
        public List<Rating> RatingList { get; set; }
    }
}
