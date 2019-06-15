﻿using System;
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
            DbInstance.Instance.BGUser.Add(Data.Mapper.Map(user));
            DbInstance.Instance.SaveChanges();
        }
        public Data.Models.BGUser GetUserByUserName(string un)
        {
            return DbInstance.Instance.BGUser.Where<Models.BGUser>(r => r.Username == un).FirstOrDefault();
        }
        public Data.Models.BGUser GetUserFriendList(string un)
        {
            return DbInstance.Instance.BGUser.Where<Models.BGUser>(r => r.Username == un).FirstOrDefault();
        }
        public void AddFriend(string un1, string un2)
        {
            //Data.Models.Friend friend1 = new Data.Models.Friend(GetUserByUserName(un1).UID, GetUserByUserName(un2).UID);
            //Data.Models.Friend friend2 = new Data.Models.Friend(GetUserByUserName(un2).UID, GetUserByUserName(un1).UID);
            //DbInstance.Instance.Friend.Add(friend1);
            //DbInstance.Instance.SaveChanges();
            //DbInstance.Instance.Friend.Add(friend2);
            //DbInstance.Instance.SaveChanges();
            Data.Models.Friend friend = new Models.Friend();
            DbInstance.Instance.Friend.Add(friend);
            DbInstance.Instance.SaveChanges();
            int fid = DbInstance.Instance.Friend.Max<Models.Friend>(x=>x.FID);
            GetUserByUserName(un1).HasFriends.Add(GetFriendByFID(fid));
            GetUserByUserName(un2).IsFriendTo.Add(GetFriendByFID(fid));
            DbInstance.Instance.SaveChanges();
        }
        public Models.Friend GetFriendByFID(int fid)
        {
            return DbInstance.Instance.Friend.Where<Models.Friend>(r => r.FID == fid).FirstOrDefault();
        }
        //public List<BGUser> GetFriends()
        //{

        //}

        //void AddUser(DMAppUser r);
        //void AddUser(string un, string pw, string fn, String phoneN);
        //DMAppUser GetUserByUserName(string un);
    }
}