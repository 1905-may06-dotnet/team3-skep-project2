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
    public class Repo:IRepo
    {
        public virtual bool UsernameExist(string un)
        {
            bool Exist = DbInstance.Instance.BGUser.Any(r => r.Username == un);
            return Exist;
        }
        public bool BoardGameExist(string bgn)
        {
            bool Exist = DbInstance.Instance.BoardGame.Any(r => r.Bgname == bgn);
            return Exist;
        }
        public List<Domain.BGLocation> GetAllLocations()
        {
            List<Domain.BGLocation> locationList = new List<Domain.BGLocation>();
            foreach (var l in DbInstance.Instance.BGLocation.ToList())
            { locationList.Add(Mapper.Map(l)); }
            return locationList;
        }
        public List<Domain.BoardGame> GetALLBoardGames()
        {
            List<Domain.BoardGame> list = new List<Domain.BoardGame>();
            foreach (var bg in DbInstance.Instance.BoardGame.ToList())
            { list.Add(Mapper.Map(bg)); }
            return list;
        }
        public void AddBoardGameFromBGG(Models.BoardGame newBG)
        {
            DbInstance.Instance.BoardGame.Add(newBG);
            DbInstance.Instance.SaveChanges();
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
        public virtual void AddUser(Models.BGUser user)
        {
            DbInstance.Instance.BGUser.Add(user);
            DbInstance.Instance.SaveChanges();
        }
        public virtual Domain.BGUser GetDomainUserByUserName(string un)
        {
            var user= DbInstance.Instance.BGUser.Where<Models.BGUser>(r => r.Username == un).FirstOrDefault();
            return Data.Mapper.Map(user);
        }
        public virtual Data.Models.BGUser GetUserByUserName(string un)
        {
            var user = DbInstance.Instance.BGUser.Where<Models.BGUser>(r => r.Username == un).FirstOrDefault();
            return user;
        }
        public virtual Data.Models.BGUser GetUserFriendList(string un)
        {
            return DbInstance.Instance.BGUser.Where<Models.BGUser>(r => r.Username == un).FirstOrDefault();
        }
        public virtual void AddFriend(string un1, string un2)
        {
            //Models.Friend newFriend1 = new Models.Friend();
            //newFriend1.Uid1 = GetUserByUserName(un1).Uid;
            //newFriend1.Uid2 = GetUserByUserName(un2).Uid;
            //DbInstance.Instance.Friend.Add(newFriend1);
            //DbInstance.Instance.SaveChanges();
            //Models.Friend newFriend2 = new Models.Friend();
            //newFriend2.Uid1 = GetUserByUserName(un2).Uid;
            //newFriend2.Uid2 = GetUserByUserName(un1).Uid;
            //DbInstance.Instance.Friend.Add(newFriend2);
            //DbInstance.Instance.SaveChanges();
        }
        public virtual Models.Friend GetFriendByFID(int fid)
        {
            return DbInstance.Instance.Friend.Where<Models.Friend>(r => r.Fid == fid).FirstOrDefault();
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

        public virtual Domain.BGLocation GetLocationById(int n){
            return Mapper.Map(DbInstance.Instance.BGLocation.Where<Models.BGLocation>(r=>r.Lid==n).FirstOrDefault());
        }

        #endregion ProfileAPI
    }
}
