using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class RemoveIsDeletedFromMemberModelAndChangeDeletedByAndAtToUnArchivedByAndAt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Members");

            migrationBuilder.RenameColumn(
                name: "DeleteBy",
                table: "Members",
                newName: "UnArchivedBy");

            migrationBuilder.RenameColumn(
                name: "DeleteAt",
                table: "Members",
                newName: "UnArchivedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UnArchivedBy",
                table: "Members",
                newName: "DeleteBy");

            migrationBuilder.RenameColumn(
                name: "UnArchivedAt",
                table: "Members",
                newName: "DeleteAt");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Members",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
