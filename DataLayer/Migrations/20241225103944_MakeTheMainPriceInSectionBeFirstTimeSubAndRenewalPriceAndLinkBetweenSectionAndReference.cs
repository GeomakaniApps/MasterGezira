using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class MakeTheMainPriceInSectionBeFirstTimeSubAndRenewalPriceAndLinkBetweenSectionAndReference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Section");

            migrationBuilder.RenameColumn(
                name: "Tax",
                table: "Section",
                newName: "RenewalSubscriptionPrice");

            migrationBuilder.RenameColumn(
                name: "PriceWithoutTax",
                table: "Section",
                newName: "FirstTimeSubscriptionPrice");

            migrationBuilder.AddColumn<int>(
                name: "ReferenceId",
                table: "Section",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Section_ReferenceId",
                table: "Section",
                column: "ReferenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Section_References_ReferenceId",
                table: "Section",
                column: "ReferenceId",
                principalTable: "References",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Section_References_ReferenceId",
                table: "Section");

            migrationBuilder.DropIndex(
                name: "IX_Section_ReferenceId",
                table: "Section");

            migrationBuilder.DropColumn(
                name: "ReferenceId",
                table: "Section");

            migrationBuilder.RenameColumn(
                name: "RenewalSubscriptionPrice",
                table: "Section",
                newName: "Tax");

            migrationBuilder.RenameColumn(
                name: "FirstTimeSubscriptionPrice",
                table: "Section",
                newName: "PriceWithoutTax");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Section",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
