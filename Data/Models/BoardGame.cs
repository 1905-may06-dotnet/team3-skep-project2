using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Models
{
    public class BoardGame
    {
        [Key]
        public int GID { get; set; }
        [ForeignKey("genre")]
        public Genres Genre { get; set; }
        public string BGName { get; set; }
        public int MaxPlayerCount { get; set; }
        public int MinPlayerCount { get; set; }
        public IList<BGUser> UserList { get; set; }
        public IList<MeetingRequest> MeetingRequestList { get; set; }
        public IList<Meeting> Meetings { get; set; }

    }
}
