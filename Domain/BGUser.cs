using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class BGUser
    {
        public BGUser(string U,string Pass){
            this.Username = U;
            this.Password = Pass;
        }
        public BGUser(string U,string Pass,string Em, Guid salt, DateTime dob)
        {
            this.UID = 0;
            this.Username = U;
            this.Email = Em;
            this.Password = Pass;
            this.Salt = salt;
            this.DateOfBirth = dob;
            this.Location = new BGLocation();
        }
        public BGUser() { }
        public int UID { get; set; }
        public string Username { get; set; }
        public string New{get;set;}
        //MAP ME Please
        public Guid Token{get;set;}
        public string Password { get; set; }
        public Guid Salt {get;set;}
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool AllowPN { get; set; }
        public bool AllowEN { get; set; }
        public BGLocation Location { get; set; }
        public List<BoardGame> UserCollections { get; set; }
        public List<Rating> Ratings { get; set; }
        public List<Friend> HasFriends { get; set; }
        public List<FriendInvitation> FriendInvitationsAsSender { get; set; }
        public List<FriendInvitation> FriendInvitationsAsReceiver { get; set; }
        public List<Meeting> MeetingsJoined { get; set; }
        public List<Meeting> MeetingsHost { get; set; }
        public List<MeetingInvitation> MeetingInvitationsAsSender { get; set; }
        public List<MeetingInvitation> MeetingInvitationsAsReceiver { get; set; }
        public List<MeetingRequest> MeetingRequestsAsSender { get; set; }
        public List<MeetingRequest> MeetingRequestsAsReceiver { get; set; }
        public BGUser(string un, string pw, Guid salt, string em, string pn, DateTime dob, bool apn, bool aen)
        {
                Username = un;
                Password = pw;
                Salt = salt;
                Email = em;
                PhoneNumber = pn;
                DateOfBirth = dob;
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
    }
}
