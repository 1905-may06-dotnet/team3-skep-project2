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
        public static Data.Models.BGLocation Map(Domain.BGLocation dmLocations) => new Data.Models.BGLocation
        {
            Lid = dmLocations.LID,
            Address = dmLocations.Address,
            City = dmLocations.City,
            LocationName = dmLocations.LocationName,
            State = dmLocations.State,
            Meeting = dmLocations.MeetingList.Select(x => Map(x)).ToList(),
            BGUser = dmLocations.UserList.Select(x => Map(x)).ToList(),
            MeetingRequest = dmLocations.MeetingRequestList.Select(x => Map(x)).ToList()
        };

        public static Domain.BGLocation Map(Data.Models.BGLocation locations) => new Domain.BGLocation
        {
            LID = locations.Lid,
            Address = locations.Address,
            City = locations.City,
            LocationName = locations.LocationName,
            State=locations.State,
            MeetingList= locations.Meeting.Select(x=>Map(x)).ToList(),
            UserList = locations.BGUser.Select(x => Map(x)).ToList(),
            MeetingRequestList = locations.MeetingRequest.Select(x => Map(x)).ToList()
        };

        public static Domain.BGUser Map(Data.Models.BGUser user) => new Domain.BGUser
        {
            UID = user.Uid,
            AllowEN = user.AllowEN,
            AllowPN = user.AllowPN,
            DateOfBirth = user.DoB,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            Location = Map(user.PreferedLocation),
            UserCollections = user.UserCollection.Select(x => Map(x)).ToList(),
            Ratings = user.Rating.Select(x => Map(x)).ToList(),
            FriendInvitationsAsSender = user.FriendInvitationsAsSender.Select(x => Map(x)).ToList(),
            FriendInvitationsAsReceiver = user.FriendInvitationsAsReceiver.Select(x => Map(x)).ToList(),
            UserMeetings = user.UserMeetings.Select(x => Map(x)).ToList(),
            MeetingsHost = user.MeetingsHost.Select(x => Map(x)).ToList(),
            MeetingInvitationsAsSender = user.MeetingInvitationsAsSender.Select(x => Map(x)).ToList(),
            MeetingInvitationsAsReceiver = user.MeetingInvitationsAsReceiver.Select(x => Map(x)).ToList(),
            MeetingRequestsAsReceiver = user.MeetingRequestsAsReceiver.Select(x => Map(x)).ToList(),
            MeetingRequestsAsSender = user.MeetingRequestsAsSender.Select(x => Map(x)).ToList()
        };

        public static Data.Models.BGUser Map(Domain.BGUser user) => new Data.Models.BGUser
        {
            Uid = user.UID,
            AllowEN = user.AllowEN,
            AllowPN = user.AllowPN,
            DoB = user.DateOfBirth,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            PreferedLocation = Map(user.Location),
            UserCollections = user.UserCollections.Select(x => Map(x)).ToList(),
            Ratings = user.Ratings.Select(x => Map(x)).ToList(),
            FriendInvitationsAsSender = user.FriendInvitationsAsSender.Select(x => Map(x)).ToList(),
            FriendInvitationsAsReceiver = user.FriendInvitationsAsReceiver.Select(x => Map(x)).ToList(),
            UserMeetings = user.UserMeetings.Select(x => Map(x)).ToList(),
            MeetingsHost = user.MeetingsHost.Select(x => Map(x)).ToList(),
            MeetingInvitationsAsSender = user.MeetingInvitationsAsSender.Select(x => Map(x)).ToList(),
            MeetingInvitationsAsReceiver = user.MeetingInvitationsAsReceiver.Select(x => Map(x)).ToList(),
            MeetingRequestsAsReceiver = user.MeetingRequestsAsReceiver.Select(x => Map(x)).ToList(),
            MeetingRequestsAsSender = user.MeetingRequestsAsSender.Select(x => Map(x)).ToList()
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
