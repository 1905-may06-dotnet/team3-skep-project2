using System;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    public class DBcontext : DbContext
    {
        public virtual DbSet<BGUser> BGUser { get; set; }
        public virtual DbSet<BoardGame> BoardGame { get; set; }
        public virtual DbSet<BGLocation> BGLocation { get; set; }
        public virtual DbSet<Genres> Genres { get; set; }
        public virtual DbSet<Meeting> Meeting { get; set; }
        public virtual DbSet<MeetingInvitation> MeetingInvitation { get; set; }
        public virtual DbSet<MeetingRequest> MeetingRequest { get; set; }
        public virtual DbSet<Rating> Rating { get; set; }
        public virtual DbSet<Friend> Friend { get; set; }
        public virtual DbSet<Friend> FriendInvitation { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer($"Server=skep.database.windows.net; Database=GSBGM; user id=skepadmin;Password=Password123;");
        }
    }
}
