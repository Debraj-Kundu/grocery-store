using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalTest.DataLayer.Migrations
{
    public partial class Admins : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "ConfirmPassword", "CreatedOnDate", "Email", "IsAdmin", "IsDeleted", "ModifiedOnDate", "Name", "Password", "PhoneNumber", "Role" },
                values: new object[] { 6, "Admin@123", new DateTimeOffset(new DateTime(2023, 6, 17, 18, 46, 2, 723, DateTimeKind.Unspecified).AddTicks(2858), new TimeSpan(0, 0, 0, 0, 0)), "admin1@admin.com", true, false, new DateTimeOffset(new DateTime(2023, 6, 17, 18, 46, 2, 723, DateTimeKind.Unspecified).AddTicks(3035), new TimeSpan(0, 0, 0, 0, 0)), "Admin1", "Admin@123", "1234567894", "Admin" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "ConfirmPassword", "CreatedOnDate", "Email", "IsAdmin", "IsDeleted", "ModifiedOnDate", "Name", "Password", "PhoneNumber", "Role" },
                values: new object[] { 7, "Admin@123", new DateTimeOffset(new DateTime(2023, 6, 17, 18, 46, 2, 723, DateTimeKind.Unspecified).AddTicks(3255), new TimeSpan(0, 0, 0, 0, 0)), "admin2@admin.com", true, false, new DateTimeOffset(new DateTime(2023, 6, 17, 18, 46, 2, 723, DateTimeKind.Unspecified).AddTicks(3261), new TimeSpan(0, 0, 0, 0, 0)), "Admin2", "Admin@123", "1234567895", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
