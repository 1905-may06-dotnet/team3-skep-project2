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

        public static Domain.BGUser Map(Data.Models.BGUser user)
        {
            Domain.BGUser bguser = new Domain.BGUser();
            bguser.UID = user.Uid;
            bguser.AllowEN = user.AllowEN;
            bguser.AllowPN = user.AllowPN;
            bguser.DateOfBirth = user.DoB;
            bguser.Username = user.Username;
            bguser.Email = user.Email;
            bguser.Password = user.Password;
            bguser.Salt = user.Salt;
            bguser.PhoneNumber = user.PhoneNumber; 
            bguser.Lid = (int)user.Lid; 
            return bguser;
            //PhoneNumber = user.PhoneNumber,
            //Lid=(int)user.Lid
            //Location = Map(user.PreferedLocation),
            //UserCollections = user.UserCollections.Select(x => Map(x)).ToList(),
            //Ratings = user.Ratings.Select(x => Map(x)).ToList(),
            //FriendInvitationsAsSender = user.FriendInvitationsAsSender.Select(x => Map(x)).ToList(),
            //FriendInvitationsAsReceiver = user.FriendInvitationsAsReceiver.Select(x => Map(x)).ToList(),
            //MeetingsJoined = user.MeetingsJoined.Select(x => Map(x)).ToList(),
            //MeetingsHost = user.MeetingsHost.Select(x => Map(x)).ToList(),
            //MeetingInvitationsAsSender = user.MeetingInvitationsAsSender.Select(x => Map(x)).ToList(),
            //MeetingInvitationsAsReceiver = user.MeetingInvitationsAsReceiver.Select(x => Map(x)).ToList(),
            //MeetingRequestsAsReceiver = user.MeetingRequestsAsReceiver.Select(x => Map(x)).ToList(),
            //MeetingRequestsAsSender = user.MeetingRequestsAsSender.Select(x => Map(x)).ToList()
        }

        public static Data.Models.BGUser Map(Domain.BGUser user) 
        {
            Data.Models.BGUser bguser = new Models.BGUser();
            bguser.Uid = user.UID;
            bguser.AllowEN = user.AllowEN;
            bguser.AllowPN = user.AllowPN;
            bguser.DoB = user.DateOfBirth;
            bguser.Username = user.Username;
            bguser.Email = user.Email;
            bguser.Password = user.Password;
            bguser.Salt = user.Salt;
            bguser.PhoneNumber = user.PhoneNumber; 
            bguser.Lid = (int)user.Lid; 
            return bguser;
            //PreferedLocation = Map(user.Location),
            //UserCollections = user.UserCollections.Select(x => Map(x)).ToList(),
            //Ratings = user.Ratings.Select(x => Map(x)).ToList(),
            //FriendInvitationsAsSender = user.FriendInvitationsAsSender.Select(x => Map(x)).ToList(),
            //FriendInvitationsAsReceiver = user.FriendInvitationsAsReceiver.Select(x => Map(x)).ToList(),
            //MeetingsJoined = user.MeetingsJoined.Select(x => Map(x)).ToList(),
            //MeetingsHost = user.MeetingsHost.Select(x => Map(x)).ToList(),
            //MeetingInvitationsAsSender = user.MeetingInvitationsAsSender.Select(x => Map(x)).ToList(),
            //MeetingInvitationsAsReceiver = user.MeetingInvitationsAsReceiver.Select(x => Map(x)).ToList(),
            //MeetingRequestsAsReceiver = user.MeetingRequestsAsReceiver.Select(x => Map(x)).ToList(),
            //MeetingRequestsAsSender = user.MeetingRequestsAsSender.Select(x => Map(x)).ToList()
        }

        public static Domain.BoardGame Map(Data.Models.BoardGame board) => new Domain.BoardGame
        {
            BGName = board.Bgname,
            Mechanics = board.Mechanics,
            GID = board.Gid,
            MaxPlayerCount = board.MaxPlayerCount,
            MinPlayerCount = board.MinPlayerCount,
            BggId=(int)board.BggId,
            ThumbnailUrl = board.ThumbnailUrl,
            Bggrating = (int)board.Bggrating,
            PlayTime = (int)board.PlayTime,
            //UserCollections = board.UserCollections.Select(x => Map(x)).ToList(),
            //MeetingRequestList = board.MeetingRequestList.Select(x => Map(x)).ToList(),
            //Meetings = board.Meetings.Select(x => Map(x)).ToList()
        };

        public static Data.Models.BoardGame Map(Domain.BoardGame board) => new Data.Models.BoardGame
        {
            Bgname = board.BGName,
            Mechanics = board.Mechanics,
            Gid = board.GID,
            MaxPlayerCount = board.MaxPlayerCount,
            MinPlayerCount = board.MinPlayerCount,
            BggId = (int)board.BggId,
            ThumbnailUrl = board.ThumbnailUrl,
            Bggrating = (int)board.Bggrating,
            PlayTime = (int)board.PlayTime,
            //UserCollections = board.UserCollections.Select(x => Map(x)).ToList(),
            //MeetingRequestList = board.MeetingRequestList.Select(x => Map(x)).ToList(),
            //Meetings = board.Meetings.Select(x => Map(x)).ToList()
        };

        public static Domain.Friend Map(Data.Models.Friend friend) => new Domain.Friend
        {
            FID=friend.Fid,
            Uid1= friend.Uid1,
            Uid2 = friend.Uid2
        };

        public static Data.Models.Friend Map(Domain.Friend friend) => new Data.Models.Friend
        {
            Fid = friend.FID,
            Uid1 = friend.Uid1,
            Uid2 = friend.Uid2
        };

        public static Domain.FriendInvitation Map(Data.Models.FriendInvitation friend) => new Domain.FriendInvitation
        {
            FIID = friend.Fiid,
            SenderUid=friend.SenderUid,
            ReceiverUid=friend.ReceiverUid
        };

        public static Data.Models.FriendInvitation Map(Domain.FriendInvitation friend) => new Data.Models.FriendInvitation
        {
            Fiid = friend.FIID,
            SenderUid = friend.SenderUid,
            ReceiverUid = friend.ReceiverUid
        };
        public static Domain.Meeting Map(Data.Models.Meeting meeting) => new Domain.Meeting
        {
            MID=meeting.Mid,
            MeetingTime=meeting.DateAndTime,
            Lid=meeting.Lid,
            Gid= meeting.Gid,
            HostUid = meeting.HostUid,
            //MeetingMenbers = meeting.MeetingMenbers.Select(x => Map(x)).ToList(),
            //MeetingInvitations = meeting.MeetingInvitations.Select(x => Map(x)).ToList(),
            Ratings = meeting.Ratings.Select(x => Map(x)).ToList()
        };

        public static Data.Models.Meeting Map(Domain.Meeting meeting) => new Data.Models.Meeting
        {
            Mid = meeting.MID,
            DateAndTime = meeting.MeetingTime,
            Lid = meeting.Lid,
            Gid = meeting.Gid,
            HostUid = meeting.HostUid,
            //meetingmenbers = meeting.meetingmenbers.select(x => map(x)).tolist(),
            //meetinginvitations = meeting.meetinginvitations.select(x => map(x)).tolist(),
            Ratings = meeting.Ratings.Select(x => Map(x)).ToList()
        };

        public static Domain.MeetingInvitation Map(Data.Models.MeetingInvitation mi) => new Domain.MeetingInvitation
        {
            MID = mi.Miid,
            senderUID=mi.InitiatorUid,
            receiverUID=mi.ReceiverUid,
            mID=mi.Mid
        };

        public static Data.Models.MeetingInvitation Map(Domain.MeetingInvitation mi) => new Data.Models.MeetingInvitation
        {
            Miid = mi.MID,
             InitiatorUid= mi.senderUID,
             ReceiverUid= mi.receiverUID,
             Mid= mi.mID
        };

        public static Domain.MeetingRequest Map(Data.Models.MeetingRequest mr) => new Domain.MeetingRequest
        {
            MRID=mr.Mrid,
            MeetingTime=mr.DateAndTime,
            Lid = mr.Lid,
            Gid = mr.Gid,
            InitiatorUid = mr.InitiatorUid,
            ReceiverUid = mr.ReceiverUid
        };

        public static Data.Models.MeetingRequest Map(Domain.MeetingRequest mr) => new Data.Models.MeetingRequest
        {
            Mrid = mr.MRID,
            DateAndTime = mr.MeetingTime,
            Lid=mr.Lid,
            Gid=mr.Gid,
            InitiatorUid=mr.InitiatorUid,
            ReceiverUid=mr.ReceiverUid
        };

        public static Domain.Rating Map(Data.Models.Rating r) => new Domain.Rating
        {
            RID = r.Rid,
            RatingScore=r.RatingScore,
            RatingUid=r.RatingUid,
            SurveyTakerUid=r.SurveyTakerUid,
            Mid=r.Mid
        };
        
        public static Data.Models.Rating Map(Domain.Rating r) => new Data.Models.Rating
        {
            Rid = r.RID,
            RatingScore = r.RatingScore,
            RatingUid = r.RatingUid,
            SurveyTakerUid = r.SurveyTakerUid,
            Mid = r.Mid
        };

        public static Domain.UserCollection Map(Data.Models.UserCollection uc) => new Domain.UserCollection
        {
            UCID = uc.Ucid,
            Uid=uc.Uid,
            Gid=uc.Gid
        };

        public static Data.Models.UserCollection Map(Domain.UserCollection uc) => new Data.Models.UserCollection
        {
            Ucid = uc.UCID,
            Uid = uc.Uid,
            Gid = uc.Gid
        };

        public static Domain.MeetingMenber Map(Data.Models.MeetingMenber um) => new Domain.MeetingMenber
        {
            UMID = um.Umid,
            Uid=um.Uid,
            Mid=um.Mid
        };

        public static Data.Models.MeetingMenber Map(Domain.MeetingMenber um) => new Data.Models.MeetingMenber
        {
            Umid = um.UMID,
            Uid = um.Uid,
            Mid = um.Mid
        };
    }
}
