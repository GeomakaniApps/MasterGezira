using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddArchiveMemberModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArchiveMemberId",
                table: "MembersAttachments",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ArchiveMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MemberCode = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    NationalId = table.Column<long>(type: "bigint", nullable: true),
                    MembersProfilePicturesId = table.Column<int>(type: "integer", nullable: true),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    JobId = table.Column<int>(type: "integer", nullable: true),
                    JobAddress = table.Column<string>(type: "text", nullable: true),
                    JobTelephone = table.Column<string>(type: "text", nullable: true),
                    MaritalStatus = table.Column<string>(type: "text", nullable: true),
                    NationalityId = table.Column<int>(type: "integer", nullable: true),
                    Religion = table.Column<string>(type: "text", nullable: true),
                    Sex = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Remark = table.Column<string>(type: "text", nullable: true),
                    MemberTypeId = table.Column<int>(type: "integer", nullable: true),
                    SectionId = table.Column<int>(type: "integer", nullable: true),
                    CityId = table.Column<int>(type: "integer", nullable: true),
                    AreaId = table.Column<int>(type: "integer", nullable: true),
                    QualificationId = table.Column<int>(type: "integer", nullable: true),
                    TransformationId = table.Column<int>(type: "integer", nullable: true),
                    BirthPlace = table.Column<string>(type: "text", nullable: true),
                    JoinDate = table.Column<DateOnly>(type: "date", nullable: true),
                    CreateBy = table.Column<int>(type: "integer", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdateBy = table.Column<int>(type: "integer", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeleteBy = table.Column<int>(type: "integer", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true),
                    Suspended = table.Column<bool>(type: "boolean", nullable: false),
                    DeletionReason = table.Column<string>(type: "text", nullable: false),
                    Archived = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchiveMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArchiveMembers_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ArchiveMembers_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ArchiveMembers_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ArchiveMembers_MemberTypes_MemberTypeId",
                        column: x => x.MemberTypeId,
                        principalTable: "MemberTypes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_ArchiveMembers_MembersProfilePictures_MembersProfilePicture~",
                        column: x => x.MembersProfilePicturesId,
                        principalTable: "MembersProfilePictures",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_ArchiveMembers_Nationalities_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Nationalities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ArchiveMembers_Qualifications_QualificationId",
                        column: x => x.QualificationId,
                        principalTable: "Qualifications",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_ArchiveMembers_Section_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Section",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ArchiveMembers_Transformations_TransformationId",
                        column: x => x.TransformationId,
                        principalTable: "Transformations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MembersAttachments_ArchiveMemberId",
                table: "MembersAttachments",
                column: "ArchiveMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_ArchiveMembers_AreaId",
                table: "ArchiveMembers",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_ArchiveMembers_CityId",
                table: "ArchiveMembers",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_ArchiveMembers_JobId",
                table: "ArchiveMembers",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_ArchiveMembers_MembersProfilePicturesId",
                table: "ArchiveMembers",
                column: "MembersProfilePicturesId");

            migrationBuilder.CreateIndex(
                name: "IX_ArchiveMembers_MemberTypeId",
                table: "ArchiveMembers",
                column: "MemberTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ArchiveMembers_NationalityId",
                table: "ArchiveMembers",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_ArchiveMembers_QualificationId",
                table: "ArchiveMembers",
                column: "QualificationId");

            migrationBuilder.CreateIndex(
                name: "IX_ArchiveMembers_SectionId",
                table: "ArchiveMembers",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_ArchiveMembers_TransformationId",
                table: "ArchiveMembers",
                column: "TransformationId");

            migrationBuilder.AddForeignKey(
                name: "FK_MembersAttachments_ArchiveMembers_ArchiveMemberId",
                table: "MembersAttachments",
                column: "ArchiveMemberId",
                principalTable: "ArchiveMembers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MembersAttachments_ArchiveMembers_ArchiveMemberId",
                table: "MembersAttachments");

            migrationBuilder.DropTable(
                name: "ArchiveMembers");

            migrationBuilder.DropIndex(
                name: "IX_MembersAttachments_ArchiveMemberId",
                table: "MembersAttachments");

            migrationBuilder.DropColumn(
                name: "ArchiveMemberId",
                table: "MembersAttachments");
        }
    }
}
