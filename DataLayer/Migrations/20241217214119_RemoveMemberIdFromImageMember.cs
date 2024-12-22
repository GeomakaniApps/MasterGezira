using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class RemoveMemberIdFromImageMember : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImegesMemberAndMemRefs_Members_Memberid",
                table: "ImegesMemberAndMemRefs");

            migrationBuilder.DropIndex(
                name: "IX_ImegesMemberAndMemRefs_Memberid",
                table: "ImegesMemberAndMemRefs");

            migrationBuilder.DropColumn(
                name: "Memberid",
                table: "ImegesMemberAndMemRefs");

            migrationBuilder.DropColumn(
                name: "memberId",
                table: "ImegesMemberAndMemRefs");

            migrationBuilder.DropColumn(
                name: "memberRefId",
                table: "ImegesMemberAndMemRefs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Memberid",
                table: "ImegesMemberAndMemRefs",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "memberId",
                table: "ImegesMemberAndMemRefs",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "memberRefId",
                table: "ImegesMemberAndMemRefs",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImegesMemberAndMemRefs_Memberid",
                table: "ImegesMemberAndMemRefs",
                column: "Memberid");

            migrationBuilder.AddForeignKey(
                name: "FK_ImegesMemberAndMemRefs_Members_Memberid",
                table: "ImegesMemberAndMemRefs",
                column: "Memberid",
                principalTable: "Members",
                principalColumn: "id");
        }
    }
}
