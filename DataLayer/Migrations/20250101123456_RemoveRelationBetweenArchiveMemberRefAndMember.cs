using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class RemoveRelationBetweenArchiveMemberRefAndMember : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArchiveMembersRefs_Members_MemberCode",
                table: "ArchiveMembersRefs");

            migrationBuilder.DropIndex(
                name: "IX_ArchiveMembersRefs_MemberCode",
                table: "ArchiveMembersRefs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
