using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddFeesInSectionModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "JoinFee",
                table: "Section",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MaintenanceFee",
                table: "Section",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MembershipCardFee",
                table: "Section",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "NewReferenceFee",
                table: "Section",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PreviousYearsFee",
                table: "Section",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SeparateFee",
                table: "Section",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Swimming",
                table: "Section",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JoinFee",
                table: "Section");

            migrationBuilder.DropColumn(
                name: "MaintenanceFee",
                table: "Section");

            migrationBuilder.DropColumn(
                name: "MembershipCardFee",
                table: "Section");

            migrationBuilder.DropColumn(
                name: "NewReferenceFee",
                table: "Section");

            migrationBuilder.DropColumn(
                name: "PreviousYearsFee",
                table: "Section");

            migrationBuilder.DropColumn(
                name: "SeparateFee",
                table: "Section");

            migrationBuilder.DropColumn(
                name: "Swimming",
                table: "Section");
        }
    }
}
