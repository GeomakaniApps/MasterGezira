using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddMemberIdInImageMember : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "memberId",
                table: "ImegesMemberAndMemRefs",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "memberRefId",
                table: "ImegesMemberAndMemRefs",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "memberId",
                table: "ImegesMemberAndMemRefs");

            migrationBuilder.DropColumn(
                name: "memberRefId",
                table: "ImegesMemberAndMemRefs");
        }
    }
}
