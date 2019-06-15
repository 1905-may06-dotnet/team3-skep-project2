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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GID { get; set; }
        [ForeignKey("genre")]
        public Genres Genre { get; set; }
        public string BGName { get; set; }
        public int MaxPlayerCount { get; set; }
        public int MinPlayerCount { get; set; }
        public List<UserCollection> UserCollections { get; set; }
        public List<MeetingRequest> MeetingRequestList { get; set; }
        public List<Meeting> Meetings { get; set; }

    }
}
