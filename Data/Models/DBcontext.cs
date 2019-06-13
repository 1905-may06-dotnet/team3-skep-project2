using System;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    class DBcontext : DbContext
    {
        public virtual DbSet<BGUser> BGUser { get; set; }
        public virtual DbSet<BoardGame> BoardGame { get; set; }
        public virtual DbSet<BGLocation> BGLocation { get; set; }
        public virtual DbSet<Genres> Genres { get; set; }
        public virtual DbSet<Meeting> Meeting { get; set; }
        public virtual DbSet<MeetingInvitation> MeetingInvitation { get; set; }
        public virtual DbSet<MeetingRequest> MeetingRequest { get; set; }
        public virtual DbSet<Rating> Rating { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer($"Server=evanh2019dbserver.database.windows.net;Database=PizzaBoxDb;Server=evanh2019dbserver.database.windows.net;Database=PizzaBoxDb;user id=evanhuang10;Password=Password123;");
        }
    }
}
