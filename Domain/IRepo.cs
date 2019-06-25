using System;
using System.Collections.Generic;
using System.Text;
namespace Domain
{
    public interface IRepo
    {
        bool UsernameExist(string un);
        bool PasswordMatched(string un, string pw);
        void AddUser(BGUser r);
        List<Domain.BGLocation> GetAllLocations();
        List<Domain.BoardGame> GetALLBoardGames();
        void UpdateEmail(BGUser user);
        void UpdateLoction(BGUser user);
        void UpdateAllowEN(BGUser user);
        void UpdateAllowPN(BGUser user);
        void AddGames(UserCollection item);
        void UpdatePhoneNumber(BGUser user);
        bool CreateMeeting(Meeting meeting);
        //bool CreateInvitation(Domain.MeetingInvitation invitation);
        BGLocation GetLocationById(int locationName);
        BGUser GetDomainUserByUserName(string un);
        //void AddUser(string un, string pw, string fn, String phoneN);
        //DMAppUser GetUserByUserName(string un);
        List<Domain.Meeting> GetMeetings(Meeting meeting);
        void CreateMeetingRequest(MeetingRequest mr);
    }
}
