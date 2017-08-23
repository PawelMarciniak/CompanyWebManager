using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyWebManager.Migrations
{
    public partial class SetDefaultDateValueTransDesc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "TransactionDescriptions",
                nullable: false,
                defaultValue: DateTime.Now
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
