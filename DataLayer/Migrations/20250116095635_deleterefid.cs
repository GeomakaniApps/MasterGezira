using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class deleterefid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MembersRefs_ImageId",
                table: "MembersRefs");

            migrationBuilder.DropColumn(
                name: "MemberRefId",
                table: "MembersProfilePictures");

            migrationBuilder.CreateIndex(
                name: "IX_MembersRefs_ImageId",
                table: "MembersRefs",
                column: "ImageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MembersRefs_ImageId",
                table: "MembersRefs");

            migrationBuilder.AddColumn<int>(
                name: "MemberRefId",
                table: "MembersProfilePictures",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MembersRefs_ImageId",
                table: "MembersRefs",
                column: "ImageId",
                unique: true);
        }
    }
}
