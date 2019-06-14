using System;
using System.Collections.Generic;
using System.Text;
using Data.Models;
using System.Linq;

namespace Data
{
    public class Repo
    {
        bool UsernameExist(string un)
        {
                bool Exist = DbInstance.Instance.BGUser.Any(r => r.Username == un);
                return Exist;
        }
        bool PasswordMatched(string un, string pw)
        {
            return pw == DbInstance.Instance.BGUser.Where<BGUser>(r => r.Username == un).FirstOrDefault().Password;
        }

        public void AddUser(string un, string pw, string fn, String phoneN)
        {
            BGUser user = new BGUser(un, pw, fn, phoneN);
            DbInstance.Instance.BGUser.Add(user);
            DbInstance.Instance.SaveChanges();
        }
        //void AddUser(DMAppUser r);
        //void AddUser(string un, string pw, string fn, String phoneN);
        //DMAppUser GetUserByUserName(string un);

    }
}
