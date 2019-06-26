using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public partial class Meeting
    {
        public Meeting()
        {
            //actually needed
            //MeetingInvitations = new List<MeetingInvitation>();
            Ratings = new List<Rating>();
            //MeetingMenbers = new List<BGUser>();
            //for creating database relationship
            MeetingInvitation = new HashSet<MeetingInvitation>();
            Rating = new HashSet<Rating>();
            MeetingMenber = new HashSet<MeetingMenber>();
        }

        public int Mid { get; set; }
        public int Lid { get; set; }
        public int Gid { get; set; }
        public int HostUid { get; set; }
        public DateTime DateAndTime { get; set; }

        public virtual BoardGame G { get; set; }
        public virtual BGUser HostU { get; set; }
        public virtual BGLocation L { get; set; }
        //[NotMapped]
        //public List<BGUser> MeetingMenbers { get; set; }
        //[NotMapped]
        //public List<MeetingInvitation> MeetingInvitations { get; set; }
        [NotMapped]
        public List<Rating> Ratings { get; set; }
        public virtual ICollection<MeetingInvitation> MeetingInvitation { get; set; }
        public virtual ICollection<Rating> Rating { get; set; }
        public virtual ICollection<MeetingMenber> MeetingMenber { get; set; }
    }
}
