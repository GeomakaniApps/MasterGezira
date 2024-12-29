using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class EditNameTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_ImegesMemberAndMemRefs_ImageId",
                table: "Members");

            migrationBuilder.DropTable(
                name: "AttachmentMemberAndMemRefs");

            migrationBuilder.DropTable(
                name: "ImegesMemberAndMemRefs");

            migrationBuilder.DropIndex(
                name: "IX_Members_ImageId",
                table: "Members");

            migrationBuilder.AddColumn<int>(
                name: "MembersPicturesid",
                table: "Members",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MembersAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: true),
                    Attachment = table.Column<byte[]>(type: "bytea", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    MemberId = table.Column<int>(type: "integer", nullable: false),
                    MemberRefId = table.Column<int>(type: "integer", nullable: false),
                    CreateBy = table.Column<int>(type: "integer", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeleteBy = table.Column<int>(type: "integer", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembersAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MembersAttachments_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MembersProfilePictures",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    memberId = table.Column<int>(type: "integer", nullable: true),
                    memberRefId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ImageExtension = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<byte[]>(type: "bytea", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateBy = table.Column<int>(type: "integer", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembersProfilePictures", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Members_MembersPicturesid",
                table: "Members",
                column: "MembersPicturesid");

            migrationBuilder.CreateIndex(
                name: "IX_MembersAttachments_MemberId",
                table: "MembersAttachments",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_MembersProfilePictures_MembersPicturesid",
                table: "Members",
                column: "MembersPicturesid",
                principalTable: "MembersProfilePictures",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_MembersProfilePictures_MembersPicturesid",
                table: "Members");

            migrationBuilder.DropTable(
                name: "MembersAttachments");

            migrationBuilder.DropTable(
                name: "MembersProfilePictures");

            migrationBuilder.DropIndex(
                name: "IX_Members_MembersPicturesid",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "MembersPicturesid",
                table: "Members");

            migrationBuilder.CreateTable(
                name: "AttachmentMemberAndMemRefs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MemberId = table.Column<int>(type: "integer", nullable: false),
                    Attachment = table.Column<byte[]>(type: "bytea", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreateBy = table.Column<int>(type: "integer", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeleteBy = table.Column<int>(type: "integer", nullable: true),
                    FileName = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    MemberRefId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentMemberAndMemRefs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttachmentMemberAndMemRefs_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImegesMemberAndMemRefs",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreateBy = table.Column<int>(type: "integer", nullable: true),
                    Image = table.Column<byte[]>(type: "bytea", nullable: true),
                    ImageExtension = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    memberId = table.Column<int>(type: "integer", nullable: true),
                    memberRefId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImegesMemberAndMemRefs", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Members_ImageId",
                table: "Members",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentMemberAndMemRefs_MemberId",
                table: "AttachmentMemberAndMemRefs",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_ImegesMemberAndMemRefs_ImageId",
                table: "Members",
                column: "ImageId",
                principalTable: "ImegesMemberAndMemRefs",
                principalColumn: "id");
        }
    }
}
