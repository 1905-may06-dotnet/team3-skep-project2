using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class BoardGame
    {
        public BoardGame()
        {
            Meeting = new List<Meeting>();
            MeetingRequest = new List<MeetingRequest>();
            UserCollection = new List<UserCollection>();
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

        public virtual List<Meeting> Meeting { get; set; }
        public virtual List<MeetingRequest> MeetingRequest { get; set; }
        public virtual List<UserCollection> UserCollection { get; set; }
    }
}
