using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalTest.DataLayer.Migrations
{
    public partial class Admin_Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "ConfirmPassword", "CreatedOnDate", "Email", "IsAdmin", "IsDeleted", "ModifiedOnDate", "Name", "Password", "PhoneNumber", "Role" },
                values: new object[] { 6, "QWRtaW5AMTIzI3NlY3JldEBwYXNzd29yZCExaGFzaGluZ19rZXkk", new DateTimeOffset(new DateTime(2023, 6, 17, 18, 56, 21, 919, DateTimeKind.Unspecified).AddTicks(2767), new TimeSpan(0, 0, 0, 0, 0)), "admin1@admin.com", true, false, new DateTimeOffset(new DateTime(2023, 6, 17, 18, 56, 21, 919, DateTimeKind.Unspecified).AddTicks(2968), new TimeSpan(0, 0, 0, 0, 0)), "Admin1", "QWRtaW5AMTIzI3NlY3JldEBwYXNzd29yZCExaGFzaGluZ19rZXkk", "1234567894", "Admin" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "ConfirmPassword", "CreatedOnDate", "Email", "IsAdmin", "IsDeleted", "ModifiedOnDate", "Name", "Password", "PhoneNumber", "Role" },
                values: new object[] { 7, "QWRtaW5AMTIzI3NlY3JldEBwYXNzd29yZCExaGFzaGluZ19rZXkk", new DateTimeOffset(new DateTime(2023, 6, 17, 18, 56, 21, 919, DateTimeKind.Unspecified).AddTicks(3188), new TimeSpan(0, 0, 0, 0, 0)), "admin2@admin.com", true, false, new DateTimeOffset(new DateTime(2023, 6, 17, 18, 56, 21, 919, DateTimeKind.Unspecified).AddTicks(3198), new TimeSpan(0, 0, 0, 0, 0)), "Admin2", "QWRtaW5AMTIzI3NlY3JldEBwYXNzd29yZCExaGFzaGluZ19rZXkk", "1234567895", "Admin" });
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
