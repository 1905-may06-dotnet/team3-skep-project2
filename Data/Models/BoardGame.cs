using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public partial class BoardGame
    {
        public BoardGame()
        {
            //what we acatually need
            Meetings = new List<Meeting>();
            MeetingRequestList = new List<MeetingRequest>();
            UserCollections = new List<UserCollection>();
            //needed to create database relationship
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
        //what we acatually need
        [NotMapped]
        public List<Meeting> Meetings { get; set; }
        [NotMapped]
        public  List<MeetingRequest> MeetingRequestList { get; set; }
        [NotMapped]
        public  List<UserCollection> UserCollections { get; set; }
        //needed to create database relationship
        public virtual ICollection<Meeting> Meeting { get; set; }
        public virtual ICollection<MeetingRequest> MeetingRequest { get; set; }
        public virtual ICollection<UserCollection> UserCollection { get; set; }
    }
}
