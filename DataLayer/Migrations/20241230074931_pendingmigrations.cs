using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class pendingmigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "Price",
            //    table: "References");

            //migrationBuilder.DropColumn(
            //    name: "Price",
            //    table: "MemberTypes");

            //migrationBuilder.RenameColumn(
            //    name: "Price",
            //    table: "Section",
            //    newName: "ReferenceId");

            //migrationBuilder.RenameColumn(
            //    name: "id",
            //    table: "References",
            //    newName: "Id");

            //migrationBuilder.AddColumn<bool>(
            //    name: "Child",
            //    table: "Section",
            //    type: "boolean",
            //    nullable: true);

            //migrationBuilder.AddColumn<double>(
            //    name: "FirstTimeSubscriptionPrice",
            //    table: "Section",
            //    type: "double precision",
            //    nullable: false,
            //    defaultValue: 0.0);

            //migrationBuilder.AddColumn<int>(
            //    name: "MemberTypeId",
            //    table: "Section",
            //    type: "integer",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.AddColumn<double>(
            //    name: "RenewalSubscriptionPrice",
            //    table: "Section",
            //    type: "double precision",
            //    nullable: false,
            //    defaultValue: 0.0);

            //migrationBuilder.AddUniqueConstraint(
            //    name: "AK_Members_MemberCode",
            //    table: "Members",
            //    column: "MemberCode");

            //migrationBuilder.CreateTable(
            //    name: "LateFees",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "integer", nullable: false)
            //            .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            //        FineDate = table.Column<DateOnly>(type: "date", nullable: false),
            //        FineRate = table.Column<int>(type: "integer", nullable: false),
            //        IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_LateFees", x => x.Id);
            //    });

            migrationBuilder.CreateTable(
                name: "MembersRefs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: true),
                    SectionId = table.Column<int>(type: "integer", nullable: true),
                    MemberCode = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ReferenceId = table.Column<int>(type: "integer", nullable: false),
                    ChildrenOrder = table.Column<int>(type: "integer", nullable: false),
                    Sex = table.Column<string>(type: "text", nullable: true),
                    ImageId = table.Column<int>(type: "integer", nullable: true),
                    JoinDate = table.Column<DateOnly>(type: "date", nullable: true),
                    CreateBy = table.Column<int>(type: "integer", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdateBy = table.Column<int>(type: "integer", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeleteBy = table.Column<int>(type: "integer", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: true),
                    Suspended = table.Column<bool>(type: "boolean", nullable: true),
                    Remark = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembersRefs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MembersRefs_MembersProfilePictures_ImageId",
                        column: x => x.ImageId,
                        principalTable: "MembersProfilePictures",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_MembersRefs_Members_MemberCode",
                        column: x => x.MemberCode,
                        principalTable: "Members",
                        principalColumn: "MemberCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MembersRefs_References_ReferenceId",
                        column: x => x.ReferenceId,
                        principalTable: "References",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MembersRefs_Section_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Section",
                        principalColumn: "Id");
                });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Section_MemberTypeId",
            //    table: "Section",
            //    column: "MemberTypeId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Section_ReferenceId",
            //    table: "Section",
            //    column: "ReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_MembersRefs_ImageId",
                table: "MembersRefs",
                column: "ImageId",
                unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_MembersRefs_MemberCode",
            //    table: "MembersRefs",
            //    column: "MemberCode");

            //migrationBuilder.CreateIndex(
            //    name: "IX_MembersRefs_ReferenceId",
            //    table: "MembersRefs",
            //    column: "ReferenceId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_MembersRefs_SectionId",
            //    table: "MembersRefs",
            //    column: "SectionId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Section_MemberTypes_MemberTypeId",
            //    table: "Section",
            //    column: "MemberTypeId",
            //    principalTable: "MemberTypes",
            //    principalColumn: "id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Section_References_ReferenceId",
            //    table: "Section",
            //    column: "ReferenceId",
            //    principalTable: "References",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Section_MemberTypes_MemberTypeId",
                table: "Section");

            migrationBuilder.DropForeignKey(
                name: "FK_Section_References_ReferenceId",
                table: "Section");

            migrationBuilder.DropTable(
                name: "LateFees");

            migrationBuilder.DropTable(
                name: "MembersRefs");

            migrationBuilder.DropIndex(
                name: "IX_Section_MemberTypeId",
                table: "Section");

            migrationBuilder.DropIndex(
                name: "IX_Section_ReferenceId",
                table: "Section");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Members_MemberCode",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Child",
                table: "Section");

            migrationBuilder.DropColumn(
                name: "FirstTimeSubscriptionPrice",
                table: "Section");

            migrationBuilder.DropColumn(
                name: "MemberTypeId",
                table: "Section");

            migrationBuilder.DropColumn(
                name: "RenewalSubscriptionPrice",
                table: "Section");

            migrationBuilder.RenameColumn(
                name: "ReferenceId",
                table: "Section",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "References",
                newName: "id");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "References",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "MemberTypes",
                type: "integer",
                nullable: true);
        }
    }
}
