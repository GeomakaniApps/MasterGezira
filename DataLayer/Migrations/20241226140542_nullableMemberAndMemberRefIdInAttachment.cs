using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class nullableMemberAndMemberRefIdInAttachment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_MembersProfilePictures_MembersProfilePicturesid",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_MembersAttachments_Members_MemberId",
                table: "MembersAttachments");

            migrationBuilder.RenameColumn(
                name: "MembersProfilePicturesid",
                table: "Members",
                newName: "MembersProfilePicturesId");

            migrationBuilder.RenameIndex(
                name: "IX_Members_MembersProfilePicturesid",
                table: "Members",
                newName: "IX_Members_MembersProfilePicturesId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MembersAttachments",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "MemberRefId",
                table: "MembersAttachments",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "MemberId",
                table: "MembersAttachments",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_MembersProfilePictures_MembersProfilePicturesId",
                table: "Members",
                column: "MembersProfilePicturesId",
                principalTable: "MembersProfilePictures",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_MembersAttachments_Members_MemberId",
                table: "MembersAttachments",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_MembersProfilePictures_MembersProfilePicturesId",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_MembersAttachments_Members_MemberId",
                table: "MembersAttachments");

            migrationBuilder.RenameColumn(
                name: "MembersProfilePicturesId",
                table: "Members",
                newName: "MembersProfilePicturesid");

            migrationBuilder.RenameIndex(
                name: "IX_Members_MembersProfilePicturesId",
                table: "Members",
                newName: "IX_Members_MembersProfilePicturesid");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MembersAttachments",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MemberRefId",
                table: "MembersAttachments",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MemberId",
                table: "MembersAttachments",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_MembersProfilePictures_MembersProfilePicturesid",
                table: "Members",
                column: "MembersProfilePicturesid",
                principalTable: "MembersProfilePictures",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_MembersAttachments_Members_MemberId",
                table: "MembersAttachments",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
