using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Migrations
{
    public partial class TimeCardMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TimeCard",
                newName: "TimeCardId");

            migrationBuilder.AlterColumn<Guid>(
                name: "TimeCardId",
                table: "TimeCard",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TimeCardId",
                table: "TimeCard",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "TimeCard",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT");
        }
    }
}
