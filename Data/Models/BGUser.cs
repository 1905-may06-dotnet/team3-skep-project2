using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public partial class BGUser
    {
        public BGUser()
        {
            //initialization of lists
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
            MeetingMenber = new HashSet<MeetingMenber>();

            UserCollections = new List<BoardGame>();
            UserCollections = new List<BoardGame>();
            HasFriends = new List<Friend>();
            FriendInvitationsAsSender = new List<FriendInvitation>();
            FriendInvitationsAsReceiver = new List<FriendInvitation>();
            MeetingsJoined = new List<Meeting>();
            MeetingsHost = new List<Meeting>();
            MeetingInvitationsAsSender = new List<MeetingInvitation>();
            MeetingInvitationsAsReceiver = new List<MeetingInvitation>();
            MeetingRequestsAsSender = new List<MeetingRequest>();
            MeetingRequestsAsReceiver = new List<MeetingRequest>();
            Ratings = new List<Rating>();
        }

        public int Uid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Guid Salt {get;set;}
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DoB { get; set; }
        public bool AllowEN { get; set; }
        public bool AllowPN { get; set; }
        public int? Lid { get; set; }
        public BGUser(string un, string pw,Guid salt, string em, string pn, DateTime dob, bool apn, bool aen)
        {
            Username = un;
            Password = pw;
            Salt = salt;
            Email = em;
            PhoneNumber = pn;
            DoB = dob;
            AllowPN = apn;
            AllowEN = aen;
            UserCollections = new List<BoardGame>();
            HasFriends = new List<Friend>();
            FriendInvitationsAsSender = new List<FriendInvitation>();
            FriendInvitationsAsReceiver = new List<FriendInvitation>();
            MeetingsJoined = new List<Meeting>();
            MeetingsHost = new List<Meeting>();
            MeetingInvitationsAsSender = new List<MeetingInvitation>();
            MeetingInvitationsAsReceiver = new List<MeetingInvitation>();
            MeetingRequestsAsSender = new List<MeetingRequest>();
            MeetingRequestsAsReceiver = new List<MeetingRequest>();
            Ratings = new List<Rating>();
    }
        //list that needed for creating data base relationships
        public virtual BGLocation PreferedLocation { get; set; }
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
        public virtual ICollection<MeetingMenber> MeetingMenber { get; set; }

        //list that we actually need to use
        [NotMapped]
        public List<BoardGame> UserCollections { get; set; }
        [NotMapped]
        public List<Friend> HasFriends { get; set; }
        [NotMapped]
        public List<FriendInvitation> FriendInvitationsAsSender { get; set; }
        [NotMapped]
        public List<FriendInvitation> FriendInvitationsAsReceiver { get; set; }
        [NotMapped]
        public List<Meeting> MeetingsJoined { get; set; }
        [NotMapped]
        public List<Meeting> MeetingsHost { get; set; }
        [NotMapped]
        public List<MeetingInvitation> MeetingInvitationsAsSender { get; set; }
        [NotMapped]
        public List<MeetingInvitation> MeetingInvitationsAsReceiver { get; set; }
        [NotMapped]
        public List<MeetingRequest> MeetingRequestsAsSender { get; set; }
        [NotMapped]
        public List<MeetingRequest> MeetingRequestsAsReceiver { get; set; }
        [NotMapped]
        public List<Rating> Ratings { get; set; }
    }
}
