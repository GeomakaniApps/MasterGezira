using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class DropMembersProfilePicturesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Areas_AreaId",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_Cities_CityId",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_Jobs_JobId",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_MemberTypes_MemberTypeId",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_MembersProfilePictures_MembersProfilePicturesid",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_Nationalities_NationalityId",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_Qualifications_QualificationId",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_Section_SectionId",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_Transformations_TransformationId",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_MembersAttachments_Members_MemberId",
                table: "MembersAttachments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Members",
                table: "Members");

            migrationBuilder.RenameTable(
                name: "Members",
                newName: "Member");

            migrationBuilder.RenameColumn(
                name: "MembersProfilePicturesid",
                table: "Member",
                newName: "MembersPicturesid");

            migrationBuilder.RenameIndex(
                name: "IX_Members_TransformationId",
                table: "Member",
                newName: "IX_Member_TransformationId");

            migrationBuilder.RenameIndex(
                name: "IX_Members_SectionId",
                table: "Member",
                newName: "IX_Member_SectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Members_QualificationId",
                table: "Member",
                newName: "IX_Member_QualificationId");

            migrationBuilder.RenameIndex(
                name: "IX_Members_NationalityId",
                table: "Member",
                newName: "IX_Member_NationalityId");

            migrationBuilder.RenameIndex(
                name: "IX_Members_MemberTypeId",
                table: "Member",
                newName: "IX_Member_MemberTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Members_MembersProfilePicturesid",
                table: "Member",
                newName: "IX_Member_MembersPicturesid");

            migrationBuilder.RenameIndex(
                name: "IX_Members_JobId",
                table: "Member",
                newName: "IX_Member_JobId");

            migrationBuilder.RenameIndex(
                name: "IX_Members_CityId",
                table: "Member",
                newName: "IX_Member_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Members_AreaId",
                table: "Member",
                newName: "IX_Member_AreaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Member",
                table: "Member",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Member_Areas_AreaId",
                table: "Member",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Member_Cities_CityId",
                table: "Member",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Member_Jobs_JobId",
                table: "Member",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Member_MemberTypes_MemberTypeId",
                table: "Member",
                column: "MemberTypeId",
                principalTable: "MemberTypes",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Member_MembersProfilePictures_MembersPicturesid",
                table: "Member",
                column: "MembersPicturesid",
                principalTable: "MembersProfilePictures",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Member_Nationalities_NationalityId",
                table: "Member",
                column: "NationalityId",
                principalTable: "Nationalities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Member_Qualifications_QualificationId",
                table: "Member",
                column: "QualificationId",
                principalTable: "Qualifications",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Member_Section_SectionId",
                table: "Member",
                column: "SectionId",
                principalTable: "Section",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Member_Transformations_TransformationId",
                table: "Member",
                column: "TransformationId",
                principalTable: "Transformations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MembersAttachments_Member_MemberId",
                table: "MembersAttachments",
                column: "MemberId",
                principalTable: "Member",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Member_Areas_AreaId",
                table: "Member");

            migrationBuilder.DropForeignKey(
                name: "FK_Member_Cities_CityId",
                table: "Member");

            migrationBuilder.DropForeignKey(
                name: "FK_Member_Jobs_JobId",
                table: "Member");

            migrationBuilder.DropForeignKey(
                name: "FK_Member_MemberTypes_MemberTypeId",
                table: "Member");

            migrationBuilder.DropForeignKey(
                name: "FK_Member_MembersProfilePictures_MembersPicturesid",
                table: "Member");

            migrationBuilder.DropForeignKey(
                name: "FK_Member_Nationalities_NationalityId",
                table: "Member");

            migrationBuilder.DropForeignKey(
                name: "FK_Member_Qualifications_QualificationId",
                table: "Member");

            migrationBuilder.DropForeignKey(
                name: "FK_Member_Section_SectionId",
                table: "Member");

            migrationBuilder.DropForeignKey(
                name: "FK_Member_Transformations_TransformationId",
                table: "Member");

            migrationBuilder.DropForeignKey(
                name: "FK_MembersAttachments_Member_MemberId",
                table: "MembersAttachments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Member",
                table: "Member");

            migrationBuilder.RenameTable(
                name: "Member",
                newName: "Members");

            migrationBuilder.RenameColumn(
                name: "MembersPicturesid",
                table: "Members",
                newName: "MembersProfilePicturesid");

            migrationBuilder.RenameIndex(
                name: "IX_Member_TransformationId",
                table: "Members",
                newName: "IX_Members_TransformationId");

            migrationBuilder.RenameIndex(
                name: "IX_Member_SectionId",
                table: "Members",
                newName: "IX_Members_SectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Member_QualificationId",
                table: "Members",
                newName: "IX_Members_QualificationId");

            migrationBuilder.RenameIndex(
                name: "IX_Member_NationalityId",
                table: "Members",
                newName: "IX_Members_NationalityId");

            migrationBuilder.RenameIndex(
                name: "IX_Member_MemberTypeId",
                table: "Members",
                newName: "IX_Members_MemberTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Member_MembersPicturesid",
                table: "Members",
                newName: "IX_Members_MembersProfilePicturesid");

            migrationBuilder.RenameIndex(
                name: "IX_Member_JobId",
                table: "Members",
                newName: "IX_Members_JobId");

            migrationBuilder.RenameIndex(
                name: "IX_Member_CityId",
                table: "Members",
                newName: "IX_Members_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Member_AreaId",
                table: "Members",
                newName: "IX_Members_AreaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Members",
                table: "Members",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Areas_AreaId",
                table: "Members",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Cities_CityId",
                table: "Members",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Jobs_JobId",
                table: "Members",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_MemberTypes_MemberTypeId",
                table: "Members",
                column: "MemberTypeId",
                principalTable: "MemberTypes",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_MembersProfilePictures_MembersProfilePicturesid",
                table: "Members",
                column: "MembersProfilePicturesid",
                principalTable: "MembersProfilePictures",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Nationalities_NationalityId",
                table: "Members",
                column: "NationalityId",
                principalTable: "Nationalities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Qualifications_QualificationId",
                table: "Members",
                column: "QualificationId",
                principalTable: "Qualifications",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Section_SectionId",
                table: "Members",
                column: "SectionId",
                principalTable: "Section",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Transformations_TransformationId",
                table: "Members",
                column: "TransformationId",
                principalTable: "Transformations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MembersAttachments_Members_MemberId",
                table: "MembersAttachments",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
