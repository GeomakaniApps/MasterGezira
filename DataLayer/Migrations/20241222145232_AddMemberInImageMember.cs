using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddMemberInImageMember : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_ImegesMemberAndMemRefs_Imageid",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Members");

            migrationBuilder.RenameColumn(
                name: "Imageid",
                table: "Members",
                newName: "ImageId");

            migrationBuilder.RenameIndex(
                name: "IX_Members_Imageid",
                table: "Members",
                newName: "IX_Members_ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_ImegesMemberAndMemRefs_ImageId",
                table: "Members",
                column: "ImageId",
                principalTable: "ImegesMemberAndMemRefs",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_ImegesMemberAndMemRefs_ImageId",
                table: "Members");

            migrationBuilder.RenameColumn(
                name: "ImageId",
                table: "Members",
                newName: "Imageid");

            migrationBuilder.RenameIndex(
                name: "IX_Members_ImageId",
                table: "Members",
                newName: "IX_Members_Imageid");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Members",
                type: "integer",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_ImegesMemberAndMemRefs_Imageid",
                table: "Members",
                column: "Imageid",
                principalTable: "ImegesMemberAndMemRefs",
                principalColumn: "id");
        }
    }
}
