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
        //void AddUser(string un, string pw, string fn, String phoneN);
        //DMAppUser GetUserByUserName(string un);
    }
}
