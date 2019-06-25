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
    }
}
