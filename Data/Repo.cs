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
        public bool BoardGameExist(string bgn)
        {
            bool Exist = DbInstance.Instance.BoardGame.Any(r => r.Bgname == bgn);
            return Exist;
        }
        public bool BoardGameExistByID(int gid)
        {
            bool Exist = DbInstance.Instance.BoardGame.Any(r => r.Gid == gid);
            return Exist;
        }
        public bool LocationExist(int lid)
        {
            bool Exist = DbInstance.Instance.BGLocation.Any(r => r.Lid == lid);
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
        public virtual void UpdateEmail(Domain.BGUser user)
        {
            if (GetUserByUserName(user.Username) != null)
            {
                var updateUser = GetUserByUserName(user.Username);
                updateUser.Email = user.Email;
                DbInstance.Instance.BGUser.Update(updateUser);
                DbInstance.Instance.SaveChanges();
            }
        }

        public virtual void UpdateLoction(Domain.BGUser user)
        {
            if (GetUserByUserName(user.Username) != null)
            {
                var updateUser = GetUserByUserName(user.Username);
                updateUser.Lid = user.Lid;
                DbInstance.Instance.BGUser.Update(updateUser);
                DbInstance.Instance.SaveChanges();
            }
        }
        public virtual void UpdatePhoneNumber(Domain.BGUser user)
        {
            if (GetUserByUserName(user.Username) != null)
            {
                var updateUser = GetUserByUserName(user.Username);
                updateUser.PhoneNumber = user.PhoneNumber;
                DbInstance.Instance.BGUser.Update(updateUser);
                DbInstance.Instance.SaveChanges();
            }
        }
        public virtual void UpdateAllowEN(Domain.BGUser user)
        {
            if (GetUserByUserName(user.Username) != null)
            {
                var updateUser = GetUserByUserName(user.Username);
                updateUser.AllowEN = user.AllowEN;
                DbInstance.Instance.BGUser.Update(updateUser);
                DbInstance.Instance.SaveChanges();
            }
        }
        public virtual void UpdateAllowPN(Domain.BGUser user)
        {
            if (GetUserByUserName(user.Username) != null)
            {
                var updateUser = GetUserByUserName(user.Username);
                updateUser.AllowPN = user.AllowPN;
                DbInstance.Instance.BGUser.Update(updateUser);
                DbInstance.Instance.SaveChanges();
            }
        }
        public virtual void AddGames(Domain.UserCollection item)
        {
            Models.UserCollection newItem = new Models.UserCollection();
            newItem.Uid = item.Uid;
            newItem.Gid = item.Gid;
            DbInstance.Instance.UserCollection.Add(newItem);
            DbInstance.Instance.SaveChanges();
        }

        public virtual Domain.BGLocation GetLocationById(int n){
            return Mapper.Map(DbInstance.Instance.BGLocation.Where<Models.BGLocation>(r=>r.Lid==n).FirstOrDefault());
        }
        #endregion ProfileAPI
        #region MeetingAPI
        public virtual bool CreateMeeting(Domain.Meeting meeting)
        {
            try
            {
                DbInstance.Instance.Meeting.Add(Mapper.Map(meeting));
                DbInstance.Instance.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public virtual bool CreateInvitation(Domain.MeetingInvitation invitation)
        {
            try
            {
                DbInstance.Instance.MeetingInvitation.Add(Mapper.Map(invitation));
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Models.BGLocation GetLocationByName(string locationName)
        {
            return DbInstance.Instance.BGLocation.Where<Data.Models.BGLocation>(l => l.LocationName == locationName).FirstOrDefault();
            
        }

        public virtual List<Domain.Meeting> GetMeetings(Domain.Meeting meeting)
        {
            if (LocationExist(meeting.Lid))
            {
                if (BoardGameExistByID(meeting.Gid))
                {
                    var slist = DbInstance.Instance.Meeting.Where<Data.Models.Meeting>(l => (int)l.Lid == meeting.Lid ).Where<Data.Models.Meeting>(l => (int)l.Gid == meeting.Gid).ToList();
                    var sMappedList = new List<Domain.Meeting>();
                    foreach (var i in slist)
                    {
                        sMappedList.Add(Mapper.Map(i));
                    }
                    return sMappedList;
                }
                else
                {
                    var list = DbInstance.Instance.Meeting.Where<Data.Models.Meeting>(l => (int)l.Lid == meeting.Lid).ToList();
                    var MappedList = new List<Domain.Meeting>();
                    foreach (var i in list)
                    {
                        MappedList.Add(Mapper.Map(i));
                    }
                    return MappedList;
                }
            }
            else
            {
                if (BoardGameExistByID(meeting.Gid))
                {
                    var list = DbInstance.Instance.Meeting.Where<Data.Models.Meeting>(l => (int)l.Gid == meeting.Gid).ToList();
                    var MappedList = new List<Domain.Meeting>();
                    foreach (var i in list)
                    {
                        MappedList.Add(Mapper.Map(i));
                    }
                    return MappedList;
                }
                else
                {
                    List<Domain.Meeting> meetingList = new List<Domain.Meeting>();
                    foreach (var m in DbInstance.Instance.Meeting.ToList())
                    { meetingList.Add(Mapper.Map(m)); }
                    return meetingList;
                }
            }        
        }





            #endregion MeetingAPI
        }
}
