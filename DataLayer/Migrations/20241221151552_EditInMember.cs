using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class EditInMember : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobTelephone",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "nationalId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "UploadedAt",
                table: "ImegesMemberAndMemRefs");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Members",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "transformationId",
                table: "Members",
                newName: "TransformationId");

            migrationBuilder.RenameColumn(
                name: "suspended",
                table: "Members",
                newName: "Suspended");

            migrationBuilder.RenameColumn(
                name: "sex",
                table: "Members",
                newName: "Sex");

            migrationBuilder.RenameColumn(
                name: "sectionId",
                table: "Members",
                newName: "SectionId");

            migrationBuilder.RenameColumn(
                name: "remark",
                table: "Members",
                newName: "Remark");

            migrationBuilder.RenameColumn(
                name: "religion",
                table: "Members",
                newName: "Religion");

            migrationBuilder.RenameColumn(
                name: "qualificationId",
                table: "Members",
                newName: "QualificationId");

            migrationBuilder.RenameColumn(
                name: "nationalityId",
                table: "Members",
                newName: "NationalityId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Members",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "joinDate",
                table: "Members",
                newName: "JoinDate");

            migrationBuilder.RenameColumn(
                name: "jobId",
                table: "Members",
                newName: "JobId");

            migrationBuilder.RenameColumn(
                name: "jobAddress",
                table: "Members",
                newName: "JobAddress");

            migrationBuilder.RenameColumn(
                name: "cityId",
                table: "Members",
                newName: "CityId");

            migrationBuilder.RenameColumn(
                name: "birthPlace",
                table: "Members",
                newName: "BirthPlace");

            migrationBuilder.RenameColumn(
                name: "birthDate",
                table: "Members",
                newName: "BirthDate");

            migrationBuilder.RenameColumn(
                name: "areaId",
                table: "Members",
                newName: "AreaId");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "Members",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Members",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "memberCodeId",
                table: "Members",
                newName: "MemberCode");

            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "ImegesMemberAndMemRefs",
                newName: "ImageExtension");

            migrationBuilder.AlterColumn<int>(
                name: "MemberCode",
                table: "Members",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Members",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "TransformationId",
                table: "Members",
                newName: "transformationId");

            migrationBuilder.RenameColumn(
                name: "Suspended",
                table: "Members",
                newName: "suspended");

            migrationBuilder.RenameColumn(
                name: "Sex",
                table: "Members",
                newName: "sex");

            migrationBuilder.RenameColumn(
                name: "SectionId",
                table: "Members",
                newName: "sectionId");

            migrationBuilder.RenameColumn(
                name: "Remark",
                table: "Members",
                newName: "remark");

            migrationBuilder.RenameColumn(
                name: "Religion",
                table: "Members",
                newName: "religion");

            migrationBuilder.RenameColumn(
                name: "QualificationId",
                table: "Members",
                newName: "qualificationId");

            migrationBuilder.RenameColumn(
                name: "NationalityId",
                table: "Members",
                newName: "nationalityId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Members",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "JoinDate",
                table: "Members",
                newName: "joinDate");

            migrationBuilder.RenameColumn(
                name: "JobId",
                table: "Members",
                newName: "jobId");

            migrationBuilder.RenameColumn(
                name: "JobAddress",
                table: "Members",
                newName: "jobAddress");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "Members",
                newName: "cityId");

            migrationBuilder.RenameColumn(
                name: "BirthPlace",
                table: "Members",
                newName: "birthPlace");

            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "Members",
                newName: "birthDate");

            migrationBuilder.RenameColumn(
                name: "AreaId",
                table: "Members",
                newName: "areaId");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Members",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Members",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "MemberCode",
                table: "Members",
                newName: "memberCodeId");

            migrationBuilder.RenameColumn(
                name: "ImageExtension",
                table: "ImegesMemberAndMemRefs",
                newName: "FileName");

            migrationBuilder.AlterColumn<int>(
                name: "memberCodeId",
                table: "Members",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "JobTelephone",
                table: "Members",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Members",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "nationalId",
                table: "Members",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UploadedAt",
                table: "ImegesMemberAndMemRefs",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
