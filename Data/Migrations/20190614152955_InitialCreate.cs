using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BGLocation",
                columns: table => new
                {
                    LID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LocationName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BGLocation", x => x.LID);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Genre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Genre);
                });

            migrationBuilder.CreateTable(
                name: "BGUser",
                columns: table => new
                {
                    UID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    AllowPN = table.Column<bool>(nullable: false),
                    AllowEN = table.Column<bool>(nullable: false),
                    LocationLID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BGUser", x => x.UID);
                    table.ForeignKey(
                        name: "FK_BGUser_BGLocation_LocationLID",
                        column: x => x.LocationLID,
                        principalTable: "BGLocation",
                        principalColumn: "LID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BoardGame",
                columns: table => new
                {
                    GID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    genre = table.Column<string>(nullable: true),
                    BGName = table.Column<string>(nullable: true),
                    MaxPlayerCount = table.Column<int>(nullable: false),
                    MinPlayerCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardGame", x => x.GID);
                    table.ForeignKey(
                        name: "FK_BoardGame_Genres_genre",
                        column: x => x.genre,
                        principalTable: "Genres",
                        principalColumn: "Genre",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Friend",
                columns: table => new
                {
                    FID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BGUserUID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friend", x => x.FID);
                    table.ForeignKey(
                        name: "FK_Friend_BGUser_BGUserUID",
                        column: x => x.BGUserUID,
                        principalTable: "BGUser",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FriendInvitation",
                columns: table => new
                {
                    FIID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BGUserUID = table.Column<int>(nullable: true),
                    BGUserUID1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendInvitation", x => x.FIID);
                    table.ForeignKey(
                        name: "FK_FriendInvitation_BGUser_BGUserUID",
                        column: x => x.BGUserUID,
                        principalTable: "BGUser",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FriendInvitation_BGUser_BGUserUID1",
                        column: x => x.BGUserUID1,
                        principalTable: "BGUser",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Meeting",
                columns: table => new
                {
                    MID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MeetingTime = table.Column<DateTime>(nullable: false),
                    BGLocationLID = table.Column<int>(nullable: true),
                    BGUserUID = table.Column<int>(nullable: true),
                    BoardGameGID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meeting", x => x.MID);
                    table.ForeignKey(
                        name: "FK_Meeting_BGLocation_BGLocationLID",
                        column: x => x.BGLocationLID,
                        principalTable: "BGLocation",
                        principalColumn: "LID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Meeting_BGUser_BGUserUID",
                        column: x => x.BGUserUID,
                        principalTable: "BGUser",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Meeting_BoardGame_BoardGameGID",
                        column: x => x.BoardGameGID,
                        principalTable: "BoardGame",
                        principalColumn: "GID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MeetingRequest",
                columns: table => new
                {
                    MRID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MeetingTime = table.Column<DateTime>(nullable: false),
                    BGLocationLID = table.Column<int>(nullable: true),
                    BGUserUID = table.Column<int>(nullable: true),
                    BGUserUID1 = table.Column<int>(nullable: true),
                    BoardGameGID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingRequest", x => x.MRID);
                    table.ForeignKey(
                        name: "FK_MeetingRequest_BGLocation_BGLocationLID",
                        column: x => x.BGLocationLID,
                        principalTable: "BGLocation",
                        principalColumn: "LID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MeetingRequest_BGUser_BGUserUID",
                        column: x => x.BGUserUID,
                        principalTable: "BGUser",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MeetingRequest_BGUser_BGUserUID1",
                        column: x => x.BGUserUID1,
                        principalTable: "BGUser",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MeetingRequest_BoardGame_BoardGameGID",
                        column: x => x.BoardGameGID,
                        principalTable: "BoardGame",
                        principalColumn: "GID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserCollection",
                columns: table => new
                {
                    UCID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BGUserUID = table.Column<int>(nullable: true),
                    BoardGameGID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCollection", x => x.UCID);
                    table.ForeignKey(
                        name: "FK_UserCollection_BGUser_BGUserUID",
                        column: x => x.BGUserUID,
                        principalTable: "BGUser",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserCollection_BoardGame_BoardGameGID",
                        column: x => x.BoardGameGID,
                        principalTable: "BoardGame",
                        principalColumn: "GID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MeetingInvitation",
                columns: table => new
                {
                    MIID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BGUserUID = table.Column<int>(nullable: true),
                    BGUserUID1 = table.Column<int>(nullable: true),
                    MeetingMID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingInvitation", x => x.MIID);
                    table.ForeignKey(
                        name: "FK_MeetingInvitation_BGUser_BGUserUID",
                        column: x => x.BGUserUID,
                        principalTable: "BGUser",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MeetingInvitation_BGUser_BGUserUID1",
                        column: x => x.BGUserUID1,
                        principalTable: "BGUser",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MeetingInvitation_Meeting_MeetingMID",
                        column: x => x.MeetingMID,
                        principalTable: "Meeting",
                        principalColumn: "MID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    RID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserRating = table.Column<int>(nullable: false),
                    BGUserUID = table.Column<int>(nullable: true),
                    MeetingMID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.RID);
                    table.ForeignKey(
                        name: "FK_Rating_BGUser_BGUserUID",
                        column: x => x.BGUserUID,
                        principalTable: "BGUser",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rating_Meeting_MeetingMID",
                        column: x => x.MeetingMID,
                        principalTable: "Meeting",
                        principalColumn: "MID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserMeeting",
                columns: table => new
                {
                    UMID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BGUserUID = table.Column<int>(nullable: true),
                    MeetingMID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMeeting", x => x.UMID);
                    table.ForeignKey(
                        name: "FK_UserMeeting_BGUser_BGUserUID",
                        column: x => x.BGUserUID,
                        principalTable: "BGUser",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserMeeting_Meeting_MeetingMID",
                        column: x => x.MeetingMID,
                        principalTable: "Meeting",
                        principalColumn: "MID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BGUser_LocationLID",
                table: "BGUser",
                column: "LocationLID");

            migrationBuilder.CreateIndex(
                name: "IX_BoardGame_genre",
                table: "BoardGame",
                column: "genre");

            migrationBuilder.CreateIndex(
                name: "IX_Friend_BGUserUID",
                table: "Friend",
                column: "BGUserUID");

            migrationBuilder.CreateIndex(
                name: "IX_FriendInvitation_BGUserUID",
                table: "FriendInvitation",
                column: "BGUserUID");

            migrationBuilder.CreateIndex(
                name: "IX_FriendInvitation_BGUserUID1",
                table: "FriendInvitation",
                column: "BGUserUID1");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_BGLocationLID",
                table: "Meeting",
                column: "BGLocationLID");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_BGUserUID",
                table: "Meeting",
                column: "BGUserUID");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_BoardGameGID",
                table: "Meeting",
                column: "BoardGameGID");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingInvitation_BGUserUID",
                table: "MeetingInvitation",
                column: "BGUserUID");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingInvitation_BGUserUID1",
                table: "MeetingInvitation",
                column: "BGUserUID1");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingInvitation_MeetingMID",
                table: "MeetingInvitation",
                column: "MeetingMID");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingRequest_BGLocationLID",
                table: "MeetingRequest",
                column: "BGLocationLID");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingRequest_BGUserUID",
                table: "MeetingRequest",
                column: "BGUserUID");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingRequest_BGUserUID1",
                table: "MeetingRequest",
                column: "BGUserUID1");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingRequest_BoardGameGID",
                table: "MeetingRequest",
                column: "BoardGameGID");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_BGUserUID",
                table: "Rating",
                column: "BGUserUID");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_MeetingMID",
                table: "Rating",
                column: "MeetingMID");

            migrationBuilder.CreateIndex(
                name: "IX_UserCollection_BGUserUID",
                table: "UserCollection",
                column: "BGUserUID");

            migrationBuilder.CreateIndex(
                name: "IX_UserCollection_BoardGameGID",
                table: "UserCollection",
                column: "BoardGameGID");

            migrationBuilder.CreateIndex(
                name: "IX_UserMeeting_BGUserUID",
                table: "UserMeeting",
                column: "BGUserUID");

            migrationBuilder.CreateIndex(
                name: "IX_UserMeeting_MeetingMID",
                table: "UserMeeting",
                column: "MeetingMID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Friend");

            migrationBuilder.DropTable(
                name: "FriendInvitation");

            migrationBuilder.DropTable(
                name: "MeetingInvitation");

            migrationBuilder.DropTable(
                name: "MeetingRequest");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "UserCollection");

            migrationBuilder.DropTable(
                name: "UserMeeting");

            migrationBuilder.DropTable(
                name: "Meeting");

            migrationBuilder.DropTable(
                name: "BGUser");

            migrationBuilder.DropTable(
                name: "BoardGame");

            migrationBuilder.DropTable(
                name: "BGLocation");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
