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
        public BGLocation Location { get; set; }
        public List<UserCollection> UserCollections { get; set; }
        public List<Rating> Ratings { get; set; }
        public List<Friend> Friends { get; set; }
        public List<FriendInvitation> FriendInvitationsAsSender { get; set; }
        public List<FriendInvitation> FriendInvitationsAsReceiver { get; set; }
        public List<UserMeeting> UserMeetings { get; set; }
        public List<Meeting> MeetingsHost { get; set; }
        public List<MeetingInvitation> MeetingInvitationsAsSender { get; set; }
        public List<MeetingInvitation> MeetingInvitationsAsReceiver { get; set; }
        public List<MeetingRequest> MeetingRequestsAsSender { get; set; }
        public List<MeetingRequest> MeetingRequestsAsReceiver { get; set; }
    }
}
