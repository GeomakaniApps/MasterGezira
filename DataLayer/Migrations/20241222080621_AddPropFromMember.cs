using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddPropFromMember : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Members",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AreaId",
                table: "Members",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "BirthDate",
                table: "Members",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BirthPlace",
                table: "Members",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Members",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "Members",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreateBy",
                table: "Members",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteAt",
                table: "Members",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeleteBy",
                table: "Members",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Members",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Imageid",
                table: "Members",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Members",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobAddress",
                table: "Members",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JobId",
                table: "Members",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JobTelephone",
                table: "Members",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "JoinDate",
                table: "Members",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaritalStatus",
                table: "Members",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MemberTypeId",
                table: "Members",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NationalityId",
                table: "Members",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhoneNumber",
                table: "Members",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QualificationId",
                table: "Members",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Religion",
                table: "Members",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Remark",
                table: "Members",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SectionId",
                table: "Members",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sex",
                table: "Members",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Suspended",
                table: "Members",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransformationId",
                table: "Members",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "Members",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdateBy",
                table: "Members",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Members",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Members_AreaId",
                table: "Members",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_CityId",
                table: "Members",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_Imageid",
                table: "Members",
                column: "Imageid");

            migrationBuilder.CreateIndex(
                name: "IX_Members_JobId",
                table: "Members",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_MemberTypeId",
                table: "Members",
                column: "MemberTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_NationalityId",
                table: "Members",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_QualificationId",
                table: "Members",
                column: "QualificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_SectionId",
                table: "Members",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_TransformationId",
                table: "Members",
                column: "TransformationId");

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
                name: "FK_Members_ImegesMemberAndMemRefs_Imageid",
                table: "Members",
                column: "Imageid",
                principalTable: "ImegesMemberAndMemRefs",
                principalColumn: "id");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Areas_AreaId",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_Cities_CityId",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_ImegesMemberAndMemRefs_Imageid",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_Jobs_JobId",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_MemberTypes_MemberTypeId",
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

            migrationBuilder.DropIndex(
                name: "IX_Members_AreaId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_CityId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_Imageid",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_JobId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_MemberTypeId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_NationalityId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_QualificationId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_SectionId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_TransformationId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "AreaId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "BirthPlace",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "DeleteAt",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Imageid",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "JobAddress",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "JobTelephone",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "JoinDate",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "MaritalStatus",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "MemberTypeId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "NationalityId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "QualificationId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Religion",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Remark",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Sex",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Suspended",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "TransformationId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Members");
        }
    }
}
