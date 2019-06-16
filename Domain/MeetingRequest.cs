using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    class MeetingRequest
    {
        public int mRID { get; set; }
        private int initiatorUID { get; set; }
        private int receiverUID { get; set; }
        private int gID {get; set;} // Game ID
        private int lID { get; set; } // Location ID
        public DateTime meetingTime { get; set; }
    }
}
