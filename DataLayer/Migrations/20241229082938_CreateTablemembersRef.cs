using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class CreateTablemembersRef : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Child",
                table: "Section",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Members_MemberCode",
                table: "Members",
                column: "MemberCode");

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
                        name: "FK_MembersRefs_ImegesMemberAndMemRefs_ImageId",
                        column: x => x.ImageId,
                        principalTable: "ImegesMemberAndMemRefs",
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
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MembersRefs_Section_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Section",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MembersRefs_ImageId",
                table: "MembersRefs",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_MembersRefs_MemberCode",
                table: "MembersRefs",
                column: "MemberCode");

            migrationBuilder.CreateIndex(
                name: "IX_MembersRefs_ReferenceId",
                table: "MembersRefs",
                column: "ReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_MembersRefs_SectionId",
                table: "MembersRefs",
                column: "SectionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MembersRefs");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Members_MemberCode",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Child",
                table: "Section");
        }
    }
}
