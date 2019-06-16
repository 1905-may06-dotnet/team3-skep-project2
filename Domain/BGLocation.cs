using System;
using System.Collections.Generic;

using System.Text;

namespace Domain
{
    public class BGLocation
    {
        public int LID { get; set; }
        public string LocationName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public List<BGUser> UserList { get; set; }
        public List<Meeting> MeetingList { get; set; }
        public List<MeetingRequest> MeetingRequestList { get; set; }
    }
}
