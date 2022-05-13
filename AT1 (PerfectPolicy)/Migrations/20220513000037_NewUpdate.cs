using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AT1__PerfectPolicy_.Migrations
{
    public partial class NewUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Quizs",
                keyColumn: "QuizID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 13, 10, 0, 37, 227, DateTimeKind.Local).AddTicks(3155));

            migrationBuilder.UpdateData(
                table: "Quizs",
                keyColumn: "QuizID",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 5, 13, 10, 0, 37, 228, DateTimeKind.Local).AddTicks(7231));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Quizs",
                keyColumn: "QuizID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 11, 12, 34, 17, 827, DateTimeKind.Local).AddTicks(8175));

            migrationBuilder.UpdateData(
                table: "Quizs",
                keyColumn: "QuizID",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 5, 11, 12, 34, 17, 828, DateTimeKind.Local).AddTicks(5550));
        }
    }
}
