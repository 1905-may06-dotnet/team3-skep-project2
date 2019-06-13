using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Models
{
    public class BGUser
    {
        [Key]
        public int UID { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool AllowPN { get; set; }
        public bool AllowEN { get; set; }
        public Location Location { get; set; }
        public IList<BoardGame> BoardGameList { get; set; }
        public IList<Rating> Ratings { get; set; }
        public IList<BGUser> Friends { get; set; }
        public IList<BGUser> FriendInvitations { get; set; }
        public IList<Meeting> MeetingsPaticipated { get; set; }
        public IList<Meeting> MeetingsHost { get; set; }
        public IList<MeetingInvitation> MeetingInvitations { get; set; }
        public IList<MeetingRequest> MeetingRequests { get; set; }

    }
}
