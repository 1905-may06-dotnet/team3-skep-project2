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
                    LocationName = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    Address = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    City = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    State = table.Column<string>(unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BGLocation_ID", x => x.LID);
                });

            migrationBuilder.CreateTable(
                name: "BoardGame",
                columns: table => new
                {
                    GID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BGName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Mechanics = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    MaxPlayerCount = table.Column<int>(nullable: false),
                    MinPlayerCount = table.Column<int>(nullable: false),
                    BGG_ID = table.Column<int>(nullable: true),
                    ThumbnailURL = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    BGGRating = table.Column<double>(nullable: true),
                    PlayTime = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardGame_ID", x => x.GID);
                });

            migrationBuilder.CreateTable(
                name: "BGUser",
                columns: table => new
                {
                    UID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    PASSWORD = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    Email = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    PhoneNumber = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    DoB = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    AllowEN = table.Column<bool>(nullable: false),
                    AllowPN = table.Column<bool>(nullable: false),
                    LID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_ID", x => x.UID);
                    table.ForeignKey(
                        name: "FK_PreferedLocation_ID",
                        column: x => x.LID,
                        principalTable: "BGLocation",
                        principalColumn: "LID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Friend",
                columns: table => new
                {
                    FID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UID1 = table.Column<int>(nullable: false),
                    UID2 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friend_ID", x => x.FID);
                    table.ForeignKey(
                        name: "FK_FriendUser1_ID",
                        column: x => x.UID1,
                        principalTable: "BGUser",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FriendUser2_ID",
                        column: x => x.UID2,
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
                    SenderUID = table.Column<int>(nullable: false),
                    ReceiverUID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendInvitation_ID", x => x.FIID);
                    table.ForeignKey(
                        name: "FK_FIReceiver_ID",
                        column: x => x.ReceiverUID,
                        principalTable: "BGUser",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FISender_ID",
                        column: x => x.SenderUID,
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
                    LID = table.Column<int>(nullable: false),
                    GID = table.Column<int>(nullable: false),
                    HostUID = table.Column<int>(nullable: false),
                    DateAndTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meeting_ID", x => x.MID);
                    table.ForeignKey(
                        name: "FK_MeetingBoardGame_ID",
                        column: x => x.GID,
                        principalTable: "BoardGame",
                        principalColumn: "GID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HostUser_ID",
                        column: x => x.HostUID,
                        principalTable: "BGUser",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MeetingLocation_ID",
                        column: x => x.LID,
                        principalTable: "BGLocation",
                        principalColumn: "LID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MeetingRequest",
                columns: table => new
                {
                    MRID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LID = table.Column<int>(nullable: false),
                    GID = table.Column<int>(nullable: false),
                    InitiatorUID = table.Column<int>(nullable: false),
                    ReceiverUID = table.Column<int>(nullable: false),
                    DateAndTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingRequest_ID", x => x.MRID);
                    table.ForeignKey(
                        name: "FK_MRBoardGame_ID",
                        column: x => x.GID,
                        principalTable: "BoardGame",
                        principalColumn: "GID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MRInitiator_ID",
                        column: x => x.InitiatorUID,
                        principalTable: "BGUser",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MRLocaiton_ID",
                        column: x => x.LID,
                        principalTable: "BGLocation",
                        principalColumn: "LID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MRReceiver_ID",
                        column: x => x.ReceiverUID,
                        principalTable: "BGUser",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserCollection",
                columns: table => new
                {
                    UCID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UID = table.Column<int>(nullable: false),
                    GID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCollection_ID", x => x.UCID);
                    table.ForeignKey(
                        name: "FK_UCBoardGame_ID",
                        column: x => x.GID,
                        principalTable: "BoardGame",
                        principalColumn: "GID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UCUser_ID",
                        column: x => x.UID,
                        principalTable: "BGUser",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MeetingInvitation",
                columns: table => new
                {
                    MIID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InitiatorUID = table.Column<int>(nullable: false),
                    ReceiverUID = table.Column<int>(nullable: false),
                    MID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingInvitation_ID", x => x.MIID);
                    table.ForeignKey(
                        name: "FK_MIInitiator_ID",
                        column: x => x.InitiatorUID,
                        principalTable: "BGUser",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MIMeeting_ID",
                        column: x => x.MID,
                        principalTable: "Meeting",
                        principalColumn: "MID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MIReceiver_ID",
                        column: x => x.ReceiverUID,
                        principalTable: "BGUser",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    RID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RatingUID = table.Column<int>(nullable: false),
                    SurveyTakerUID = table.Column<int>(nullable: false),
                    MID = table.Column<int>(nullable: false),
                    Rating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating_ID", x => x.RID);
                    table.ForeignKey(
                        name: "FK_RatingMeeting_ID",
                        column: x => x.MID,
                        principalTable: "Meeting",
                        principalColumn: "MID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RatingUID_ID",
                        column: x => x.RatingUID,
                        principalTable: "BGUser",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SurveyTakerUID_ID",
                        column: x => x.SurveyTakerUID,
                        principalTable: "BGUser",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserMeeting",
                columns: table => new
                {
                    UMID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UID = table.Column<int>(nullable: false),
                    MID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMeeting_ID", x => x.UMID);
                    table.ForeignKey(
                        name: "FK_UMMeeting_ID",
                        column: x => x.MID,
                        principalTable: "Meeting",
                        principalColumn: "MID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UMUser_ID",
                        column: x => x.UID,
                        principalTable: "BGUser",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BGUser_LID",
                table: "BGUser",
                column: "LID");

            migrationBuilder.CreateIndex(
                name: "IX_Friend_UID1",
                table: "Friend",
                column: "UID1");

            migrationBuilder.CreateIndex(
                name: "IX_Friend_UID2",
                table: "Friend",
                column: "UID2");

            migrationBuilder.CreateIndex(
                name: "IX_FriendInvitation_ReceiverUID",
                table: "FriendInvitation",
                column: "ReceiverUID");

            migrationBuilder.CreateIndex(
                name: "IX_FriendInvitation_SenderUID",
                table: "FriendInvitation",
                column: "SenderUID");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_GID",
                table: "Meeting",
                column: "GID");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_HostUID",
                table: "Meeting",
                column: "HostUID");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_LID",
                table: "Meeting",
                column: "LID");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingInvitation_InitiatorUID",
                table: "MeetingInvitation",
                column: "InitiatorUID");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingInvitation_MID",
                table: "MeetingInvitation",
                column: "MID");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingInvitation_ReceiverUID",
                table: "MeetingInvitation",
                column: "ReceiverUID");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingRequest_GID",
                table: "MeetingRequest",
                column: "GID");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingRequest_InitiatorUID",
                table: "MeetingRequest",
                column: "InitiatorUID");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingRequest_LID",
                table: "MeetingRequest",
                column: "LID");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingRequest_ReceiverUID",
                table: "MeetingRequest",
                column: "ReceiverUID");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_MID",
                table: "Rating",
                column: "MID");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_RatingUID",
                table: "Rating",
                column: "RatingUID");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_SurveyTakerUID",
                table: "Rating",
                column: "SurveyTakerUID");

            migrationBuilder.CreateIndex(
                name: "IX_UserCollection_GID",
                table: "UserCollection",
                column: "GID");

            migrationBuilder.CreateIndex(
                name: "IX_UserCollection_UID",
                table: "UserCollection",
                column: "UID");

            migrationBuilder.CreateIndex(
                name: "IX_UserMeeting_MID",
                table: "UserMeeting",
                column: "MID");

            migrationBuilder.CreateIndex(
                name: "IX_UserMeeting_UID",
                table: "UserMeeting",
                column: "UID");
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
                name: "BoardGame");

            migrationBuilder.DropTable(
                name: "BGUser");

            migrationBuilder.DropTable(
                name: "BGLocation");
        }
    }
}
