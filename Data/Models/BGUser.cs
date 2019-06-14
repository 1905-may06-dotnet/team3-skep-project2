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
        public IList<Rating> Ratings { get; set; }
        public IList<Friend> Friends { get; set; }
        public IList<FriendInvitation> FriendInvitationsAsSender { get; set; }
        public IList<FriendInvitation> FriendInvitationsAsReceiver { get; set; }
        public IList<UserMeeting> UserMeetings { get; set; }
        public IList<Meeting> MeetingsHost { get; set; }
        public IList<MeetingInvitation> MeetingInvitationsAsSender { get; set; }
        public IList<MeetingInvitation> MeetingInvitationsAsReceiver { get; set; }
        public IList<MeetingRequest> MeetingRequestsAsSender { get; set; }
        public IList<MeetingRequest> MeetingRequestsAsReceiver { get; set; }
    }
}
