using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddChangeLogAndIsDeletedAndEditTablePictures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "memberRefId",
                table: "MembersProfilePictures",
                newName: "MemberRefId");

            migrationBuilder.RenameColumn(
                name: "memberId",
                table: "MembersProfilePictures",
                newName: "MemberId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "Transformations",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreateBy",
                table: "Transformations",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteAt",
                table: "Transformations",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeleteBy",
                table: "Transformations",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Transformations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "Transformations",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdateBy",
                table: "Transformations",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "TransactionTypes",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreateBy",
                table: "TransactionTypes",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteAt",
                table: "TransactionTypes",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeleteBy",
                table: "TransactionTypes",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "TransactionTypes",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdateBy",
                table: "TransactionTypes",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "Section",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreateBy",
                table: "Section",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteAt",
                table: "Section",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeleteBy",
                table: "Section",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "Section",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdateBy",
                table: "Section",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "References",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreateBy",
                table: "References",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteAt",
                table: "References",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeleteBy",
                table: "References",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "References",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "References",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdateBy",
                table: "References",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "Qualifications",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreateBy",
                table: "Qualifications",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteAt",
                table: "Qualifications",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeleteBy",
                table: "Qualifications",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Qualifications",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "Qualifications",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdateBy",
                table: "Qualifications",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "Nationalities",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreateBy",
                table: "Nationalities",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteAt",
                table: "Nationalities",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeleteBy",
                table: "Nationalities",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Nationalities",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "Nationalities",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdateBy",
                table: "Nationalities",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "MemberTypes",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreateBy",
                table: "MemberTypes",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteAt",
                table: "MemberTypes",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeleteBy",
                table: "MemberTypes",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "MemberTypes",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdateBy",
                table: "MemberTypes",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteAt",
                table: "MembersProfilePictures",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeleteBy",
                table: "MembersProfilePictures",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "LateFees",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreateBy",
                table: "LateFees",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteAt",
                table: "LateFees",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeleteBy",
                table: "LateFees",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "LateFees",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdateBy",
                table: "LateFees",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "Jobs",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreateBy",
                table: "Jobs",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteAt",
                table: "Jobs",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeleteBy",
                table: "Jobs",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Jobs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "Jobs",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdateBy",
                table: "Jobs",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "Cities",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreateBy",
                table: "Cities",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteAt",
                table: "Cities",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeleteBy",
                table: "Cities",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Cities",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "Cities",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdateBy",
                table: "Cities",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "Areas",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreateBy",
                table: "Areas",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteAt",
                table: "Areas",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeleteBy",
                table: "Areas",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Areas",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "Areas",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdateBy",
                table: "Areas",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "Transformations");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "Transformations");

            migrationBuilder.DropColumn(
                name: "DeleteAt",
                table: "Transformations");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "Transformations");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Transformations");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "Transformations");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "Transformations");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "TransactionTypes");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "TransactionTypes");

            migrationBuilder.DropColumn(
                name: "DeleteAt",
                table: "TransactionTypes");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "TransactionTypes");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "TransactionTypes");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "TransactionTypes");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "Section");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "Section");

            migrationBuilder.DropColumn(
                name: "DeleteAt",
                table: "Section");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "Section");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "Section");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "Section");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "References");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "References");

            migrationBuilder.DropColumn(
                name: "DeleteAt",
                table: "References");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "References");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "References");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "References");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "References");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "Qualifications");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "Qualifications");

            migrationBuilder.DropColumn(
                name: "DeleteAt",
                table: "Qualifications");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "Qualifications");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Qualifications");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "Qualifications");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "Qualifications");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "Nationalities");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "Nationalities");

            migrationBuilder.DropColumn(
                name: "DeleteAt",
                table: "Nationalities");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "Nationalities");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Nationalities");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "Nationalities");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "Nationalities");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "MemberTypes");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "MemberTypes");

            migrationBuilder.DropColumn(
                name: "DeleteAt",
                table: "MemberTypes");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "MemberTypes");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "MemberTypes");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "MemberTypes");

            migrationBuilder.DropColumn(
                name: "DeleteAt",
                table: "MembersProfilePictures");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "MembersProfilePictures");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "LateFees");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "LateFees");

            migrationBuilder.DropColumn(
                name: "DeleteAt",
                table: "LateFees");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "LateFees");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "LateFees");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "LateFees");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "DeleteAt",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "DeleteAt",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "DeleteAt",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "Areas");

            migrationBuilder.RenameColumn(
                name: "MemberRefId",
                table: "MembersProfilePictures",
                newName: "memberRefId");

            migrationBuilder.RenameColumn(
                name: "MemberId",
                table: "MembersProfilePictures",
                newName: "memberId");
        }
    }
}
