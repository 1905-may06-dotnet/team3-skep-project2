using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public partial class BGLocation
    {
        public BGLocation()
        {
            //what we acatually need
            BGUser = new List<BGUser>();
            Meeting = new List<Meeting>();
            MeetingRequest = new List<MeetingRequest>();
            //needed to create database relationship
            BGUser = new HashSet<BGUser>();
            Meeting = new HashSet<Meeting>();
            MeetingRequest = new HashSet<MeetingRequest>();
        }

        public int Lid { get; set; }
        public string LocationName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }


        //what we acatually need
        [NotMapped]
        public  List<BGUser> UserList { get; set; }
        [NotMapped]
        public  List<Meeting> MeetingList { get; set; }
        [NotMapped]
        public  List<MeetingRequest> MeetingRequestList { get; set; }
        //needed to create database relationship
        public virtual ICollection<BGUser> BGUser { get; set; }
        public virtual ICollection<Meeting> Meeting { get; set; }
        public virtual ICollection<MeetingRequest> MeetingRequest { get; set; }
    }
}
