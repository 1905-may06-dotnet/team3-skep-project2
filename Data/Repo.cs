using System;
using System.Collections.Generic;
using System.Text;
using Data.Models;
using System.Linq;

namespace Data
{
    public class Repo
    {
        public bool UsernameExist(string un)
        {
            bool Exist = DbInstance.Instance.BGUser.Any(r => r.Username == un);
            return Exist;
        }
        public bool PasswordMatched(string un, string pw)
        {
            return pw == DbInstance.Instance.BGUser.Where<BGUser>(r => r.Username == un).FirstOrDefault().Password;
        }

        public void AddUser(BGUser user)
        {
            DbInstance.Instance.BGUser.Add(user);
            DbInstance.Instance.SaveChanges();
        }
        public Data.Models.BGUser GetUserByUserName(string un)
        {
            return DbInstance.Instance.BGUser.Where<BGUser>(r => r.Username == un).FirstOrDefault();
        }
        public Data.Models.BGUser GetUserFriendList(string un)
        {
            return DbInstance.Instance.BGUser.Where<BGUser>(r => r.Username == un).FirstOrDefault();
        }
        public void AddFriend(string un1, string un2)
        {
            //Data.Models.Friend friend1 = new Data.Models.Friend(GetUserByUserName(un1).UID, GetUserByUserName(un2).UID);
            //Data.Models.Friend friend2 = new Data.Models.Friend(GetUserByUserName(un2).UID, GetUserByUserName(un1).UID);
            //DbInstance.Instance.Friend.Add(friend1);
            //DbInstance.Instance.SaveChanges();
            //DbInstance.Instance.Friend.Add(friend2);
            //DbInstance.Instance.SaveChanges();
            Data.Models.Friend friend = new Friend();
            DbInstance.Instance.Friend.Add(friend);
            DbInstance.Instance.SaveChanges();
            int fid = DbInstance.Instance.Friend.Max<Friend>(x=>x.FID);
            GetUserByUserName(un1).HasFriends.Add(GetFriendByFID(fid));
            GetUserByUserName(un2).IsFriendTo.Add(GetFriendByFID(fid));
            DbInstance.Instance.SaveChanges();
        }
        public Friend GetFriendByFID(int fid)
        {
            return DbInstance.Instance.Friend.Where<Friend>(r => r.FID == fid).FirstOrDefault();
        }
        //public List<BGUser> GetFriends()
        //{

        //}

        //void AddUser(DMAppUser r);
        //void AddUser(string un, string pw, string fn, String phoneN);
        //DMAppUser GetUserByUserName(string un);
    }
}
