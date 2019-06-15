using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using Data.Models;
namespace Data
{
    public static class Mapper
    {
        public static Domain.BGLocation Map(Data.Models.BGLocation locations) => new Domain.BGLocation
        {
            LID = locations.LID,
            Address = locations.Address,
            City = locations.City,
            LocationName = locations.LocationName,
            State=locations.State,
            MeetingList= locations.MeetingList.Select(x=>Map(x)).ToList(),
            UserList = locations.UserList.Select(x => Map(x)).ToList(),
            MeetingRequestList = locations.MeetingRequestList.Select(x => Map(x)).ToList()
        };
        public static Data.Models.BGLocation Map(Domain.BGLocation locations) => new Data.Models.BGLocation
        {
            LID = locations.LID,
            Address = locations.Address,
            City = locations.City,
            LocationName = locations.LocationName,
            State = locations.State,
            MeetingList = locations.MeetingList.Select(x => Map(x)).ToList(),
            UserList = locations.UserList.Select(x => Map(x)).ToList(),
            MeetingRequestList = locations.MeetingRequestList.Select(x => Map(x)).ToList()
        };
        public static Domain.BGUser Map(Data.Models.BGUser User) => new Domain.BGUser
        {

            UID = User.UID,
            AllowEN = User.AllowEN,
            AllowPN = User.AllowPN,
            DateOfBirth = User.DateOfBirth,
            Email = User.Email,
            PhoneNumber = User.PhoneNumber,
            Location=Map(User.Location),
            UserCollections = User.UserCollections.Select(x => Map(x)).ToList(),
            Ratings = User.Ratings.Select(x => Map(x)).ToList(),
            HasFriends = User.HasFriends.Select(x => Map(x)).ToList(),
            IsFriendTo = User.IsFriendTo.Select(x => Map(x)).ToList(),
            FriendInvitationsAsSender = User.FriendInvitationsAsSender.Select(x => Map(x)).ToList(),
            FriendInvitationsAsReceiver = User.FriendInvitationsAsReceiver.Select(x => Map(x)).ToList(),
            UserMeetings = User.UserMeetings.Select(x => Map(x)).ToList(),
            MeetingsHost = User.MeetingsHost.Select(x => Map(x)).ToList(),
            MeetingInvitationsAsSender = User.MeetingInvitationsAsSender.Select(x => Map(x)).ToList(),
            MeetingInvitationsAsReceiver = User.MeetingInvitationsAsReceiver.Select(x => Map(x)).ToList(),
            MeetingRequestsAsReceiver = User.MeetingRequestsAsReceiver.Select(x => Map(x)).ToList(),
            MeetingRequestsAsSender = User.MeetingRequestsAsSender.Select(x => Map(x)).ToList()
        };
        public static Data.Models.BGUser Map(Domain.BGUser User) => new Data.Models.BGUser
        {
            UID = User.UID,
            AllowEN = User.AllowEN,
            AllowPN = User.AllowPN,
            DateOfBirth = User.DateOfBirth,
            Email = User.Email,
            PhoneNumber = User.PhoneNumber,
            Location = Map(User.Location),
            UserCollections = User.UserCollections.Select(x => Map(x)).ToList(),
            Ratings = User.Ratings.Select(x => Map(x)).ToList(),
            HasFriends = User.HasFriends.Select(x => Map(x)).ToList(),
            IsFriendTo = User.IsFriendTo.Select(x => Map(x)).ToList(),
            FriendInvitationsAsSender = User.FriendInvitationsAsSender.Select(x => Map(x)).ToList(),
            FriendInvitationsAsReceiver = User.FriendInvitationsAsReceiver.Select(x => Map(x)).ToList(),
            UserMeetings = User.UserMeetings.Select(x => Map(x)).ToList(),
            MeetingsHost = User.MeetingsHost.Select(x => Map(x)).ToList(),
            MeetingInvitationsAsSender = User.MeetingInvitationsAsSender.Select(x => Map(x)).ToList(),
            MeetingInvitationsAsReceiver = User.MeetingInvitationsAsReceiver.Select(x => Map(x)).ToList(),
            MeetingRequestsAsReceiver = User.MeetingRequestsAsReceiver.Select(x => Map(x)).ToList(),
            MeetingRequestsAsSender = User.MeetingRequestsAsSender.Select(x => Map(x)).ToList()
        };
        public static Domain.BoardGame Map(Data.Models.BoardGame board) => new Domain.BoardGame
        {
            BGName = board.BGName,
            Genre = Map(board.Genre),
            GID = board.GID,
            MaxPlayerCount = board.MaxPlayerCount,
            MinPlayerCount = board.MinPlayerCount,
            UserCollections= board.UserCollections.Select(x => Map(x)).ToList(),
            MeetingRequestList = board.MeetingRequestList.Select(x => Map(x)).ToList(),
            Meetings = board.Meetings.Select(x => Map(x)).ToList()
        };
        public static Data.Models.BoardGame Map(Domain.BoardGame board) => new Data.Models.BoardGame
        {
            BGName = board.BGName,
            Genre = Map(board.Genre),
            GID = board.GID,
            MaxPlayerCount = board.MaxPlayerCount,
            MinPlayerCount = board.MinPlayerCount,
            UserCollections = board.UserCollections.Select(x => Map(x)).ToList(),
            MeetingRequestList = board.MeetingRequestList.Select(x => Map(x)).ToList(),
            Meetings = board.Meetings.Select(x => Map(x)).ToList()
        };
        public static Domain.Friend Map(Data.Models.Friend friend) => new Domain.Friend
        {
            FID=friend.FID
        };
        public static Data.Models.Friend Map(Domain.Friend friend) => new Data.Models.Friend
        {
            FID = friend.FID           
        };
        public static Domain.FriendInvitation Map(Data.Models.FriendInvitation friend) => new Domain.FriendInvitation
        {
            FIID = friend.FIID
        };
        public static Data.Models.FriendInvitation Map(Domain.FriendInvitation friend) => new Data.Models.FriendInvitation
        {
            FIID = friend.FIID
        };
        public static Domain.Genres Map(Data.Models.Genres genres) => new Domain.Genres
        {
            Genre = genres.Genre
        };
        public static Data.Models.Genres Map(Domain.Genres genres) => new Data.Models.Genres
        {
            Genre = genres.Genre
        };
        public static Domain.Meeting Map(Data.Models.Meeting meeting) => new Domain.Meeting
        {
            MID=meeting.MID,
            MeetingTime=meeting.MeetingTime,
            UserMeetings = meeting.UserMeetings.Select(x => Map(x)).ToList(),
            MeetingInvitation = meeting.MeetingInvitation.Select(x => Map(x)).ToList(),
            RatingList = meeting.RatingList.Select(x => Map(x)).ToList()
        };
        public static Data.Models.Meeting Map(Domain.Meeting meeting) => new Data.Models.Meeting
        {
            MID = meeting.MID,
            MeetingTime = meeting.MeetingTime,
            UserMeetings = meeting.UserMeetings.Select(x => Map(x)).ToList(),
            MeetingInvitation = meeting.MeetingInvitation.Select(x => Map(x)).ToList(),
            RatingList = meeting.RatingList.Select(x => Map(x)).ToList()
        };
        public static Domain.MeetingInvitation Map(Data.Models.MeetingInvitation mi) => new Domain.MeetingInvitation
        {
            MID = mi.MIID,
            
        };
        public static Data.Models.MeetingInvitation Map(Domain.MeetingInvitation mi) => new Data.Models.MeetingInvitation
        {
            MIID = mi.MID,

        };
        public static Domain.MeetingRequest Map(Data.Models.MeetingRequest mr) => new Domain.MeetingRequest
        {
            MRID=mr.MRID,
            MeetingTime=mr.MeetingTime
        };
        public static Data.Models.MeetingRequest Map(Domain.MeetingRequest mr) => new Data.Models.MeetingRequest
        {
            MRID = mr.MRID,
            MeetingTime = mr.MeetingTime

        };
        public static Domain.Rating Map(Data.Models.Rating r) => new Domain.Rating
        {
            RID = r.RID,
            UserRating=r.UserRating
        };
        public static Data.Models.Rating Map(Domain.Rating r) => new Data.Models.Rating
        {
            RID = r.RID,
            UserRating = r.UserRating
        };
        public static Domain.UserCollection Map(Data.Models.UserCollection uc) => new Domain.UserCollection
        {
            UCID = uc.UCID
        };
        public static Data.Models.UserCollection Map(Domain.UserCollection uc) => new Data.Models.UserCollection
        {
            UCID = uc.UCID
        };
        public static Domain.UserMeeting Map(Data.Models.UserMeeting um) => new Domain.UserMeeting
        {
            UMID = um.UMID
        };
        public static Data.Models.UserMeeting Map(Domain.UserMeeting um) => new Data.Models.UserMeeting
        {
            UMID = um.UMID
        };
    }
}
