using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class addIsActiveInMember : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_MembersProfilePictures_MembersPicturesid",
                table: "Members");

            migrationBuilder.RenameColumn(
                name: "MembersPicturesid",
                table: "Members",
                newName: "MembersProfilePicturesid");

            migrationBuilder.RenameIndex(
                name: "IX_Members_MembersPicturesid",
                table: "Members",
                newName: "IX_Members_MembersProfilePicturesid");

            migrationBuilder.AlterColumn<bool>(
                name: "Suspended",
                table: "Members",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Members",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Members",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_MembersProfilePictures_MembersProfilePicturesid",
                table: "Members",
                column: "MembersProfilePicturesid",
                principalTable: "MembersProfilePictures",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_MembersProfilePictures_MembersProfilePicturesid",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Members");

            migrationBuilder.RenameColumn(
                name: "MembersProfilePicturesid",
                table: "Members",
                newName: "MembersPicturesid");

            migrationBuilder.RenameIndex(
                name: "IX_Members_MembersProfilePicturesid",
                table: "Members",
                newName: "IX_Members_MembersPicturesid");

            migrationBuilder.AlterColumn<bool>(
                name: "Suspended",
                table: "Members",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Members",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_MembersProfilePictures_MembersPicturesid",
                table: "Members",
                column: "MembersPicturesid",
                principalTable: "MembersProfilePictures",
                principalColumn: "id");
        }
    }
}
