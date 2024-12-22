using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class updateMemberTypeAndSection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_section",
                table: "section");

            migrationBuilder.DropPrimaryKey(
                name: "PK_memberTypes",
                table: "memberTypes");

            migrationBuilder.RenameTable(
                name: "section",
                newName: "Section");

            migrationBuilder.RenameTable(
                name: "memberTypes",
                newName: "MemberTypes");

            migrationBuilder.AddColumn<int>(
                name: "Discount",
                table: "Section",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Section",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Section",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MemberTypes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Section",
                table: "Section",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MemberTypes",
                table: "MemberTypes",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Section",
                table: "Section");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MemberTypes",
                table: "MemberTypes");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Section");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Section");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Section");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MemberTypes");

            migrationBuilder.RenameTable(
                name: "Section",
                newName: "section");

            migrationBuilder.RenameTable(
                name: "MemberTypes",
                newName: "memberTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_section",
                table: "section",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_memberTypes",
                table: "memberTypes",
                column: "id");
        }
    }
}
