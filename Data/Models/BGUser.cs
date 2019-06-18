using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class BGUser
    {
        public BGUser()
        {
            FriendInvitationReceiverU = new List<FriendInvitation>();
            FriendInvitationSenderU = new List<FriendInvitation>();
            FriendUid1Navigation = new List<Friend>();
            FriendUid2Navigation = new List<Friend>();
            Meeting = new List<Meeting>();
            MeetingInvitationInitiatorU = new List<MeetingInvitation>();
            MeetingInvitationReceiverU = new List<MeetingInvitation>();
            MeetingRequestInitiatorU = new List<MeetingRequest>();
            MeetingRequestReceiverU = new List<MeetingRequest>();
            RatingRatingU = new List<Rating>();
            RatingSurveyTakerU = new List<Rating>();
            UserCollection = new List<UserCollection>();
            MeetingMenber = new List<MeetingMenber>();
        }

        public int Uid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Guid Salt { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DoB { get; set; }
        public bool AllowEN { get; set; }
        public bool AllowPN { get; set; }
        public int? Lid { get; set; }
        public BGUser(string un, string pw, string em, string pn, DateTime dob, bool apn, bool aen)
        {
            Username = un;
            Password = pw;
            Email = em;
            PhoneNumber = pn;
            DoB = dob;
            AllowPN = apn;
            AllowEN = aen;
        }
        public virtual BGLocation PreferedLocation { get; set; }
        public virtual List<FriendInvitation> FriendInvitationReceivers { get; set; }
        public virtual List<FriendInvitation> FriendInvitationSenders { get; set; }
        public virtual List<Friend> FriendUid1s { get; set; }
        public virtual List<Friend> FriendUid2s { get; set; }
        public virtual List<Meeting> Meetings { get; set; }
        public virtual List<MeetingInvitation> MeetingInvitationInitiators { get; set; }
        public virtual List<MeetingInvitation> MeetingInvitationReceivers { get; set; }
        public virtual List<MeetingRequest> MeetingRequestInitiatorU { get; set; }
        public virtual List<MeetingRequest> MeetingRequestReceiverU { get; set; }
        public virtual List<Rating> RatingRatings { get; set; }
        public virtual List<UserCollection> UserCollection { get; set; }
        public virtual List<MeetingMenber> MeetingMenber { get; set; }
    }
}
