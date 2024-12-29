using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class RemovePriceFromMemberTypeModelAndAddingPriceAndPriceWithoutTaxAndTaxAndMemberTypeToSectionModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "MemberTypes");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Section",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "MemberTypeId",
                table: "Section",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "PriceWithoutTax",
                table: "Section",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Tax",
                table: "Section",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Section_MemberTypeId",
                table: "Section",
                column: "MemberTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Section_MemberTypes_MemberTypeId",
                table: "Section",
                column: "MemberTypeId",
                principalTable: "MemberTypes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Section_MemberTypes_MemberTypeId",
                table: "Section");

            migrationBuilder.DropIndex(
                name: "IX_Section_MemberTypeId",
                table: "Section");

            migrationBuilder.DropColumn(
                name: "MemberTypeId",
                table: "Section");

            migrationBuilder.DropColumn(
                name: "PriceWithoutTax",
                table: "Section");

            migrationBuilder.DropColumn(
                name: "Tax",
                table: "Section");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Section",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "MemberTypes",
                type: "integer",
                nullable: true);
        }
    }
}
