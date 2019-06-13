using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    class BGUser
    {

        public int UID { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

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
