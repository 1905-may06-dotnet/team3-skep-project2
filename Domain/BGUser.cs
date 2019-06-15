﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class BGUser
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
        public List<Rating> Ratings { get; set; }
        public List<Friend> HasFriends { get; set; }
        public List<Friend> IsFriendTo { get; set; }
        public List<FriendInvitation> FriendInvitationsAsSender { get; set; }
        public List<FriendInvitation> FriendInvitationsAsReceiver { get; set; }
        public List<UserMeeting> UserMeetings { get; set; }
        public List<Meeting> MeetingsHost { get; set; }
        public List<MeetingInvitation> MeetingInvitationsAsSender { get; set; }
        public List<MeetingInvitation> MeetingInvitationsAsReceiver { get; set; }
        public List<MeetingRequest> MeetingRequestsAsSender { get; set; }
        public List<MeetingRequest> MeetingRequestsAsReceiver { get; set; }
        public BGUser()
        { }
        public BGUser(string un, string pw, string em, string pn, DateTime dob, bool apn, bool aen)
        {
            Username = un;
            Password = pw;
            Email = em;
            PhoneNumber = pn;
            DateOfBirth = dob;
            AllowPN = apn;
            AllowEN = aen;
        }
    }
}