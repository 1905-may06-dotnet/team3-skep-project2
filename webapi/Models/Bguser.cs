using System;
using System.Collections.Generic;

namespace webapi.Models
{
    public partial class BGUser
    {
        public BGUser()
        {
            FriendInvitationReceiverU = new HashSet<FriendInvitation>();
            FriendInvitationSenderU = new HashSet<FriendInvitation>();
            FriendUid1Navigation = new HashSet<Friend>();
            FriendUid2Navigation = new HashSet<Friend>();
            Meeting = new HashSet<Meeting>();
            MeetingInvitationInitiatorU = new HashSet<MeetingInvitation>();
            MeetingInvitationReceiverU = new HashSet<MeetingInvitation>();
            MeetingRequestInitiatorU = new HashSet<MeetingRequest>();
            MeetingRequestReceiverU = new HashSet<MeetingRequest>();
            RatingRatingU = new HashSet<Rating>();
            RatingSurveyTakerU = new HashSet<Rating>();
            UserCollection = new HashSet<UserCollection>();
            UserMeeting = new HashSet<UserMeeting>();
        }

        public int Uid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string DoB { get; set; }
        public bool AllowEn { get; set; }
        public bool AllowPn { get; set; }
        public int? Lid { get; set; }

        public virtual BGLocation L { get; set; }
        public virtual ICollection<FriendInvitation> FriendInvitationReceiverU { get; set; }
        public virtual ICollection<FriendInvitation> FriendInvitationSenderU { get; set; }
        public virtual ICollection<Friend> FriendUid1Navigation { get; set; }
        public virtual ICollection<Friend> FriendUid2Navigation { get; set; }
        public virtual ICollection<Meeting> Meeting { get; set; }
        public virtual ICollection<MeetingInvitation> MeetingInvitationInitiatorU { get; set; }
        public virtual ICollection<MeetingInvitation> MeetingInvitationReceiverU { get; set; }
        public virtual ICollection<MeetingRequest> MeetingRequestInitiatorU { get; set; }
        public virtual ICollection<MeetingRequest> MeetingRequestReceiverU { get; set; }
        public virtual ICollection<Rating> RatingRatingU { get; set; }
        public virtual ICollection<Rating> RatingSurveyTakerU { get; set; }
        public virtual ICollection<UserCollection> UserCollection { get; set; }
        public virtual ICollection<UserMeeting> UserMeeting { get; set; }
    }
}
