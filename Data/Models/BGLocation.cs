using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class BGLocation
    {
        public BGLocation()
        {
            BGUser = new List<BGUser>();
            Meeting = new List<Meeting>();
            MeetingRequest = new List<MeetingRequest>();
        }

        public int Lid { get; set; }
        public string LocationName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public virtual List<BGUser> BGUser { get; set; }
        public virtual List<Meeting> Meeting { get; set; }
        public virtual List<MeetingRequest> MeetingRequest { get; set; }
    }
}
