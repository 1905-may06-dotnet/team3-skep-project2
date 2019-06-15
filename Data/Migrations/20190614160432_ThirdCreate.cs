using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class ThirdCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BGUserUID1",
                table: "Friend",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Friend_BGUserUID1",
                table: "Friend",
                column: "BGUserUID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Friend_BGUser_BGUserUID1",
                table: "Friend",
                column: "BGUserUID1",
                principalTable: "BGUser",
                principalColumn: "UID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friend_BGUser_BGUserUID1",
                table: "Friend");

            migrationBuilder.DropIndex(
                name: "IX_Friend_BGUserUID1",
                table: "Friend");

            migrationBuilder.DropColumn(
                name: "BGUserUID1",
                table: "Friend");
        }
    }
}
