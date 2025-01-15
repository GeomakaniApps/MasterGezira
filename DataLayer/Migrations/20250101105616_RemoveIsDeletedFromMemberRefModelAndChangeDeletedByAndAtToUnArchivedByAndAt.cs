using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class RemoveIsDeletedFromMemberRefModelAndChangeDeletedByAndAtToUnArchivedByAndAt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MembersRefs");

            migrationBuilder.RenameColumn(
                name: "DeleteBy",
                table: "MembersRefs",
                newName: "UnArchivedBy");

            migrationBuilder.RenameColumn(
                name: "DeleteAt",
                table: "MembersRefs",
                newName: "UnArchivedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UnArchivedBy",
                table: "MembersRefs",
                newName: "DeleteBy");

            migrationBuilder.RenameColumn(
                name: "UnArchivedAt",
                table: "MembersRefs",
                newName: "DeleteAt");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MembersRefs",
                type: "boolean",
                nullable: true);
        }
    }
}
