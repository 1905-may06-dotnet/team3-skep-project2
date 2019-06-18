using System;
using System.Collections.Generic;

namespace webapi.Models
{
    public partial class BGLocation
    {
        public BGLocation()
        {
            BGUser = new HashSet<BGUser>();
            Meeting = new HashSet<Meeting>();
            MeetingRequest = new HashSet<MeetingRequest>();
        }

        public int Lid { get; set; }
        public string LocationName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public virtual ICollection<BGUser> BGUser { get; set; }
        public virtual ICollection<Meeting> Meeting { get; set; }
        public virtual ICollection<MeetingRequest> MeetingRequest { get; set; }
    }
}
