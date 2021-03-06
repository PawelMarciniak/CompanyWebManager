﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyWebManager.Migrations
{
    public partial class SetDefaultValueInDateTransactions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>
            (
                table: "Transactions",
                name: "Date",
                defaultValue: DateTime.Now
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>
            (
                table: "Transactions",
                name: "Date",
                defaultValue: null
            );

        }
    }
}
