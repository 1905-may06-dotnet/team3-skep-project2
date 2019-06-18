using System;
using System.Collections.Generic;
using System.Text;
using Data.Models;
using System.Linq;
using Domain;

namespace Data
{
    public class Repo:IRepo
    {
        public bool UsernameExist(string un)
        {
            bool Exist = DbInstance.Instance.BGUser.Any(r => r.Username == un);
            return Exist;
        }

        public bool PasswordMatched(string un, string pw)
        {
            return pw == DbInstance.Instance.BGUser.Where<Models.BGUser>(r => r.Username == un).FirstOrDefault().Password;
        }

        public void AddUser(Domain.BGUser user)
        {
            //DbInstance.Instance.BGUser.Add(Data.Mapper.Map(user));
            //DbInstance.Instance.SaveChanges();
        }
        public void AddUser(Models.BGUser user)
        {
            DbInstance.Instance.BGUser.Add(user);
            DbInstance.Instance.SaveChanges();
        }
        public Data.Models.BGUser GetUserByUsername(string un)
        {
            return DbInstance.Instance.BGUser.Where<Models.BGUser>(r => r.Username == un).FirstOrDefault();
        }
        public Data.Models.BGUser GetUserFriendList(string un)
        {
            return DbInstance.Instance.BGUser.Where<Models.BGUser>(r => r.Username == un).FirstOrDefault();
        }
        public void AddFriend(string un1, string un2)
        {
            Models.Friend newFriend1 = new Models.Friend();
            newFriend1.Uid1 = GetUserByUsername(un1).Uid;
            newFriend1.Uid2 = GetUserByUsername(un2).Uid;
            DbInstance.Instance.Friend.Add(newFriend1);
            DbInstance.Instance.SaveChanges();
            Models.Friend newFriend2 = new Models.Friend();
            newFriend2.Uid1 = GetUserByUsername(un2).Uid;
            newFriend2.Uid2 = GetUserByUsername(un1).Uid;
            DbInstance.Instance.Friend.Add(newFriend2);
            DbInstance.Instance.SaveChanges();
        }
    }
}
