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
        void UpdateUserName(string newName, string oldName);
        void UpdatePassword(string newPassword, string User);
        void UpdateEmail(string newEmail, string User);
        void UpdateLoction(BGLocation newLocation, string User);
        void AddGames(BoardGame game);
        void UpdatePhoneNumber(string newNumber, string User);
        bool CreateMeeting(Meeting meeting);
        //bool CreateInvitation(Domain.MeetingInvitation invitation);
        BGLocation GetLocationById(int locationName);
        BGUser GetDomainUserByUserName(string un);
        //void AddUser(string un, string pw, string fn, String phoneN);
        //DMAppUser GetUserByUserName(string un);
        List<Domain.Meeting> GetMeetingsByLocation(BGLocation search);
        List<Domain.Meeting> GetMeetingsByBG(BoardGame search);
    }
}
