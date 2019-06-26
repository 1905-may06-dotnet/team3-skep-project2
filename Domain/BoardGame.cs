using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class BoardGame
    {
        public int GID { get; set; }
        public string Mechanics { get; set; }
        public string BGName { get; set; }
        public int MaxPlayerCount { get; set; }
        public int MinPlayerCount { get; set; }
        public int BggId { get; set; }
        public string ThumbnailUrl { get; set; }
        public double Bggrating { get; set; }
        public int PlayTime { get; set; }
        //public List<UserCollection> UserCollections { get; set; }
        //public List<MeetingRequest> MeetingRequestList { get; set; }
        //public List<Meeting> Meetings { get; set; }
    }
}
