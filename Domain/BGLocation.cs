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
        public IList<BGUser> UserList { get; set; }
        public IList<Meeting> MeetingList { get; set; }
        public IList<MeetingRequest> MeetingRequestList { get; set; }
    }
}
