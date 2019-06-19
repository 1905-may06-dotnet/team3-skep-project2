using System;
using System.Collections.Generic;
using System.Text;
using Data.Models;
using System.Linq;
using Domain;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;


namespace Data
{
    public class Repo : IRepo
    {
        public virtual bool UsernameExist(string un)
        {
            bool Exist = DbInstance.Instance.BGUser.Any(r => r.Username == un);
            return Exist;
        }
        public virtual bool PasswordMatched(string un, string pw)
        {
            var user = DbInstance.Instance.BGUser.Where<Models.BGUser>(r => r.Username == un).FirstOrDefault();
            string Password =  user.Password;
            Guid g = user.Salt;
            string salt = g.ToString();
            byte[] saltToBytes = Encoding.ASCII.GetBytes(salt);
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: pw,
                salt: saltToBytes,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            return hashed == Password;
        }

        public virtual void AddUser(Domain.BGUser user)
        {
            DbInstance.Instance.BGUser.Add(Data.Mapper.Map(user));
            DbInstance.Instance.SaveChanges();
        }
        public virtual Data.Models.BGUser GetUserByUserName(string un)
        {
            return DbInstance.Instance.BGUser.Where<Models.BGUser>(r => r.Username == un).FirstOrDefault();
        }
        public virtual Data.Models.BGUser GetUserFriendList(string un)
        {
            return DbInstance.Instance.BGUser.Where<Models.BGUser>(r => r.Username == un).FirstOrDefault();
        }
        public virtual void AddFriend(string un1, string un2)
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
        public virtual Models.Friend GetFriendByFID(int fid)
        {
            return DbInstance.Instance.Friend.Where<Models.Friend>(r => r.FID == fid).FirstOrDefault();
        }
        #region ProfileAPI
        public virtual void UpdateUserName(string newName, string oldName)
        {
            if (GetUserByUserName(oldName) != null)
            {
                var user=GetUserByUserName(oldName);
                user.Username = newName;
                DbInstance.Instance.BGUser.Update(user);
             }
        }

        public virtual void UpdatePassword(string newPassword, string User)
        {
            if (GetUserByUserName(User) != null)
            {
                var user = GetUserByUserName(User);
                user.Password = newPassword;
                DbInstance.Instance.BGUser.Update(user);
                DbInstance.Instance.SaveChanges();
            }
        }
        public virtual void UpdateEmail(string newEmail, string User)
        {
            if (GetUserByUserName(User) != null)
            {
                var user = GetUserByUserName(User);
                user.Email = newEmail;
                DbInstance.Instance.BGUser.Update(user);
                DbInstance.Instance.SaveChanges();
            }
        }

        public virtual void UpdateLoction(Domain.BGLocation newLocation, string User)
        {
            if (GetUserByUserName(User) != null)
            {
                var user = GetUserByUserName(User);
                DbInstance.Instance.Attach(Mapper.Map(newLocation));
                DbInstance.Instance.BGUser.Update(user);
                DbInstance.Instance.SaveChanges();
            }
        }
        public virtual void UpdatePhoneNumber(string newNumber, string User)
        {
            if (GetUserByUserName(User) != null)
            {
                var user = GetUserByUserName(User);
                user.PhoneNumber = newNumber;
                DbInstance.Instance.BGUser.Update(user);
                DbInstance.Instance.SaveChanges();
            }
        }
        public virtual void AddGames(int BGGID, string User)
        {
            throw new NotImplementedException();
        }

        public virtual Domain.BGLocation GetLocationByName(string n){
            return Mapper.Map(DbInstance.Instance.BGLocation.Where<Models.BGLocation>(r=>r.LocationName==n).FirstOrDefault());
        }
        #endregion ProfileAPI
        #region MeetingAPI
        public bool CreateMeeting(Domain.Meeting meeting)
        {
            try
            {
                DbInstance.Instance.Meeting.Add(Mapper.Map(meeting));
                return true;
            }
            catch
            {
                return false;
            }
        }


        #endregion MeetingAPI
    }
}
