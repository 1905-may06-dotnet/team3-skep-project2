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
        void UpdateUserName(string newName, string oldName);
        void UpdatePassword(string newPassword, string User);
        void UpdateEmail(string newEmail, string User);
        void UpdateLoction(BGLocation newLocation, string User);
        void AddGames(int BGGID, string User);
        void UpdatePhoneNumber(string newNumber, string User);
        BGLocation GetLocationByName(string locationName);
        bool CreateMeeting(Meeting meeting);
        bool CreateInvitation(Domain.MeetingInvitation invitation);
        BGLocation GetLocationById(int locationName);
        IEnumerable<Meeting> GetMeetingsByLocation(BGLocation search);

        //void AddUser(string un, string pw, string fn, String phoneN);
        //DMAppUser GetUserByUserName(string un);
    }
}
