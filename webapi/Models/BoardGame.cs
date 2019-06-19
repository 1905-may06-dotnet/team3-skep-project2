using System;
using System.Collections.Generic;

namespace webapi.Models
{
    public partial class BoardGame
    {
        public BoardGame()
        {
            Meeting = new HashSet<Meeting>();
            MeetingRequest = new HashSet<MeetingRequest>();
            UserCollection = new HashSet<UserCollection>();
        }

        public int Gid { get; set; }
        public string Bgname { get; set; }
        public string Mechanics { get; set; }
        public int MaxPlayerCount { get; set; }
        public int MinPlayerCount { get; set; }
        public int? BggId { get; set; }
        public string ThumbnailUrl { get; set; }
        public double? Bggrating { get; set; }
        public int? PlayTime { get; set; }

        public virtual ICollection<Meeting> Meeting { get; set; }
        public virtual ICollection<MeetingRequest> MeetingRequest { get; set; }
        public virtual ICollection<UserCollection> UserCollection { get; set; }
    }
}
