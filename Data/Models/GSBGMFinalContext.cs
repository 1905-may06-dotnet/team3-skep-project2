using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.Models
{
    public partial class GSBGMFinalContext : DbContext
    {
        public GSBGMFinalContext()
        {
        }

        public GSBGMFinalContext(DbContextOptions<GSBGMFinalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BGLocation> BGLocation { get; set; }
        public virtual DbSet<BGUser> BGUser { get; set; }
        public virtual DbSet<BoardGame> BoardGame { get; set; }
        public virtual DbSet<Friend> Friend { get; set; }
        public virtual DbSet<FriendInvitation> FriendInvitation { get; set; }
        public virtual DbSet<Meeting> Meeting { get; set; }
        public virtual DbSet<MeetingInvitation> MeetingInvitation { get; set; }
        public virtual DbSet<MeetingRequest> MeetingRequest { get; set; }
        public virtual DbSet<Rating> Rating { get; set; }
        public virtual DbSet<UserCollection> UserCollection { get; set; }
        public virtual DbSet<MeetingMenber> UserMeeting { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:skep.database.windows.net,1433;Initial Catalog=GSBGMFinal;Persist Security Info=False;User ID=skepadmin;Password=Password123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<BGLocation>(entity =>
            {
                entity.HasKey(e => e.Lid)
                    .HasName("PK_BGLocation_ID");

                entity.ToTable("BGLocation");

                entity.Property(e => e.Lid).HasColumnName("LID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LocationName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BGUser>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK_User_ID");

                entity.ToTable("BGUser");

                entity.Property(e => e.Uid).HasColumnName("UID");

                entity.Property(e => e.AllowEN).HasColumnName("AllowEN");

                entity.Property(e => e.AllowPN).HasColumnName("AllowPN");

                entity.Property(e => e.DoB)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Lid).HasColumnName("LID");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("PASSWORD")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Salt)
                    .IsRequired()
                    .HasColumnName("Salt")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.L)
                    .WithMany(p => p.BGUser)
                    .HasForeignKey(d => d.Lid)
                    .HasConstraintName("FK_PreferedLocation_ID");
            });

            modelBuilder.Entity<BoardGame>(entity =>
            {
                entity.HasKey(e => e.Gid)
                    .HasName("PK_BoardGame_ID");

                entity.Property(e => e.Gid).HasColumnName("GID");

                entity.Property(e => e.BggId).HasColumnName("BGG_ID");

                entity.Property(e => e.Bggrating).HasColumnName("BGGRating");

                entity.Property(e => e.Bgname)
                    .IsRequired()
                    .HasColumnName("BGName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mechanics)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ThumbnailUrl)
                    .HasColumnName("ThumbnailURL")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Friend>(entity =>
            {
                entity.HasKey(e => e.Fid)
                    .HasName("PK_Friend_ID");

                entity.Property(e => e.Fid).HasColumnName("FID");

                entity.Property(e => e.Uid1).HasColumnName("UID1");

                entity.Property(e => e.Uid2).HasColumnName("UID2");

                entity.HasOne(d => d.Uid1Navigation)
                    .WithMany(p => p.FriendUid1Navigation)
                    .HasForeignKey(d => d.Uid1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FriendUser1_ID");

                entity.HasOne(d => d.Uid2Navigation)
                    .WithMany(p => p.FriendUid2Navigation)
                    .HasForeignKey(d => d.Uid2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FriendUser2_ID");
            });

            modelBuilder.Entity<FriendInvitation>(entity =>
            {
                entity.HasKey(e => e.Fiid)
                    .HasName("PK_FriendInvitation_ID");

                entity.Property(e => e.Fiid).HasColumnName("FIID");

                entity.Property(e => e.ReceiverUid).HasColumnName("ReceiverUID");

                entity.Property(e => e.SenderUid).HasColumnName("SenderUID");

                entity.HasOne(d => d.ReceiverU)
                    .WithMany(p => p.FriendInvitationReceiverU)
                    .HasForeignKey(d => d.ReceiverUid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FIReceiver_ID");

                entity.HasOne(d => d.SenderU)
                    .WithMany(p => p.FriendInvitationSenderU)
                    .HasForeignKey(d => d.SenderUid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FISender_ID");
            });

            modelBuilder.Entity<Meeting>(entity =>
            {
                entity.HasKey(e => e.Mid)
                    .HasName("PK_Meeting_ID");

                entity.Property(e => e.Mid).HasColumnName("MID");

                entity.Property(e => e.DateAndTime).HasColumnType("datetime");

                entity.Property(e => e.Gid).HasColumnName("GID");

                entity.Property(e => e.HostUid).HasColumnName("HostUID");

                entity.Property(e => e.Lid).HasColumnName("LID");

                entity.HasOne(d => d.G)
                    .WithMany(p => p.Meeting)
                    .HasForeignKey(d => d.Gid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MeetingBoardGame_ID");

                entity.HasOne(d => d.HostU)
                    .WithMany(p => p.Meeting)
                    .HasForeignKey(d => d.HostUid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HostUser_ID");

                entity.HasOne(d => d.L)
                    .WithMany(p => p.Meeting)
                    .HasForeignKey(d => d.Lid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MeetingLocation_ID");
            });

            modelBuilder.Entity<MeetingInvitation>(entity =>
            {
                entity.HasKey(e => e.Miid)
                    .HasName("PK_MeetingInvitation_ID");

                entity.Property(e => e.Miid).HasColumnName("MIID");

                entity.Property(e => e.InitiatorUid).HasColumnName("InitiatorUID");

                entity.Property(e => e.Mid).HasColumnName("MID");

                entity.Property(e => e.ReceiverUid).HasColumnName("ReceiverUID");

                entity.HasOne(d => d.InitiatorU)
                    .WithMany(p => p.MeetingInvitationInitiatorU)
                    .HasForeignKey(d => d.InitiatorUid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MIInitiator_ID");

                entity.HasOne(d => d.M)
                    .WithMany(p => p.MeetingInvitation)
                    .HasForeignKey(d => d.Mid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MIMeeting_ID");

                entity.HasOne(d => d.ReceiverU)
                    .WithMany(p => p.MeetingInvitationReceiverU)
                    .HasForeignKey(d => d.ReceiverUid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MIReceiver_ID");
            });

            modelBuilder.Entity<MeetingRequest>(entity =>
            {
                entity.HasKey(e => e.Mrid)
                    .HasName("PK_MeetingRequest_ID");

                entity.Property(e => e.Mrid).HasColumnName("MRID");

                entity.Property(e => e.DateAndTime).HasColumnType("datetime");

                entity.Property(e => e.Gid).HasColumnName("GID");

                entity.Property(e => e.InitiatorUid).HasColumnName("InitiatorUID");

                entity.Property(e => e.Lid).HasColumnName("LID");

                entity.Property(e => e.ReceiverUid).HasColumnName("ReceiverUID");

                entity.HasOne(d => d.G)
                    .WithMany(p => p.MeetingRequest)
                    .HasForeignKey(d => d.Gid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MRBoardGame_ID");

                entity.HasOne(d => d.InitiatorU)
                    .WithMany(p => p.MeetingRequestInitiatorU)
                    .HasForeignKey(d => d.InitiatorUid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MRInitiator_ID");

                entity.HasOne(d => d.L)
                    .WithMany(p => p.MeetingRequest)
                    .HasForeignKey(d => d.Lid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MRLocaiton_ID");

                entity.HasOne(d => d.ReceiverU)
                    .WithMany(p => p.MeetingRequestReceiverU)
                    .HasForeignKey(d => d.ReceiverUid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MRReceiver_ID");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.HasKey(e => e.Rid)
                    .HasName("PK_Rating_ID");

                entity.Property(e => e.Rid).HasColumnName("RID");

                entity.Property(e => e.Mid).HasColumnName("MID");

                entity.Property(e => e.Rating1).HasColumnName("Rating");

                entity.Property(e => e.RatingUid).HasColumnName("RatingUID");

                entity.Property(e => e.SurveyTakerUid).HasColumnName("SurveyTakerUID");

                entity.HasOne(d => d.M)
                    .WithMany(p => p.Rating)
                    .HasForeignKey(d => d.Mid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RatingMeeting_ID");

                entity.HasOne(d => d.RatingU)
                    .WithMany(p => p.RatingRatingU)
                    .HasForeignKey(d => d.RatingUid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RatingUID_ID");

                entity.HasOne(d => d.SurveyTakerU)
                    .WithMany(p => p.RatingSurveyTakerU)
                    .HasForeignKey(d => d.SurveyTakerUid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SurveyTakerUID_ID");
            });

            modelBuilder.Entity<UserCollection>(entity =>
            {
                entity.HasKey(e => e.Ucid)
                    .HasName("PK_UserCollection_ID");

                entity.Property(e => e.Ucid).HasColumnName("UCID");

                entity.Property(e => e.Gid).HasColumnName("GID");

                entity.Property(e => e.Uid).HasColumnName("UID");

                entity.HasOne(d => d.G)
                    .WithMany(p => p.UserCollection)
                    .HasForeignKey(d => d.Gid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UCBoardGame_ID");

                entity.HasOne(d => d.U)
                    .WithMany(p => p.UserCollection)
                    .HasForeignKey(d => d.Uid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UCUser_ID");
            });

            modelBuilder.Entity<MeetingMenber>(entity =>
            {
                entity.HasKey(e => e.Umid)
                    .HasName("PK_UserMeeting_ID");

                entity.Property(e => e.Umid).HasColumnName("UMID");

                entity.Property(e => e.Mid).HasColumnName("MID");

                entity.Property(e => e.Uid).HasColumnName("UID");

                entity.HasOne(d => d.M)
                    .WithMany(p => p.MeetingMenber)
                    .HasForeignKey(d => d.Mid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UMMeeting_ID");

                entity.HasOne(d => d.U)
                    .WithMany(p => p.MeetingMenber)
                    .HasForeignKey(d => d.Uid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UMUser_ID");
            });
        }
    }
}
