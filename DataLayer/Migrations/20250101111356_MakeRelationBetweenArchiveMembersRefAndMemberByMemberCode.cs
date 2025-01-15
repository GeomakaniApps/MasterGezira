using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class MakeRelationBetweenArchiveMembersRefAndMemberByMemberCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArchiveMembersRefs_Members_MemberId",
                table: "ArchiveMembersRefs");

            migrationBuilder.DropIndex(
                name: "IX_ArchiveMembersRefs_MemberId",
                table: "ArchiveMembersRefs");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "ArchiveMembersRefs");

            migrationBuilder.CreateIndex(
                name: "IX_ArchiveMembersRefs_MemberCode",
                table: "ArchiveMembersRefs",
                column: "MemberCode");

            migrationBuilder.AddForeignKey(
                name: "FK_ArchiveMembersRefs_Members_MemberCode",
                table: "ArchiveMembersRefs",
                column: "MemberCode",
                principalTable: "Members",
                principalColumn: "MemberCode",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArchiveMembersRefs_Members_MemberCode",
                table: "ArchiveMembersRefs");

            migrationBuilder.DropIndex(
                name: "IX_ArchiveMembersRefs_MemberCode",
                table: "ArchiveMembersRefs");

            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "ArchiveMembersRefs",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArchiveMembersRefs_MemberId",
                table: "ArchiveMembersRefs",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArchiveMembersRefs_Members_MemberId",
                table: "ArchiveMembersRefs",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");
        }
    }
}
