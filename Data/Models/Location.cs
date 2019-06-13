using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    public class Location
    {
        [Key]
        public int LID { get; set; }
        public string LocationName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public IList<BGUser> UserList { get; set; }
        public IList<Meeting> MeetingList { get; set; }
        public IList<MeetingRequest> MeetingRequestList { get; set; }
    }
}
