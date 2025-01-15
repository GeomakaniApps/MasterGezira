using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddArchiveMembersRefsModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArchiveMembersRefs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: true),
                    SectionId = table.Column<int>(type: "integer", nullable: true),
                    MemberCode = table.Column<int>(type: "integer", nullable: false),
                    MemberId = table.Column<int>(type: "integer", nullable: true),
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
                    Suspended = table.Column<bool>(type: "boolean", nullable: true),
                    Remark = table.Column<string>(type: "text", nullable: true),
                    DeletionReason = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchiveMembersRefs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArchiveMembersRefs_MembersProfilePictures_ImageId",
                        column: x => x.ImageId,
                        principalTable: "MembersProfilePictures",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_ArchiveMembersRefs_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ArchiveMembersRefs_References_ReferenceId",
                        column: x => x.ReferenceId,
                        principalTable: "References",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArchiveMembersRefs_Section_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Section",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArchiveMembersRefs_ImageId",
                table: "ArchiveMembersRefs",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_ArchiveMembersRefs_MemberId",
                table: "ArchiveMembersRefs",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_ArchiveMembersRefs_ReferenceId",
                table: "ArchiveMembersRefs",
                column: "ReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_ArchiveMembersRefs_SectionId",
                table: "ArchiveMembersRefs",
                column: "SectionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArchiveMembersRefs");
        }
    }
}
