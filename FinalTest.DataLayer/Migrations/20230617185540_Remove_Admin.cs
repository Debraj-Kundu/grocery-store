using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalTest.DataLayer.Migrations
{
    public partial class Remove_Admin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "ConfirmPassword", "CreatedOnDate", "Email", "IsAdmin", "IsDeleted", "ModifiedOnDate", "Name", "Password", "PhoneNumber", "Role" },
                values: new object[] { 6, "QWRtaW5AMTIzI3NlY3JldEBwYXNzd29yZCExaGFzaGluZ19rZXkk", new DateTimeOffset(new DateTime(2023, 6, 17, 18, 54, 23, 415, DateTimeKind.Unspecified).AddTicks(6342), new TimeSpan(0, 0, 0, 0, 0)), "admin1@admin.com", true, false, new DateTimeOffset(new DateTime(2023, 6, 17, 18, 54, 23, 415, DateTimeKind.Unspecified).AddTicks(6538), new TimeSpan(0, 0, 0, 0, 0)), "Admin1", "QWRtaW5AMTIzI3NlY3JldEBwYXNzd29yZCExaGFzaGluZ19rZXkk", "1234567894", "Admin" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "ConfirmPassword", "CreatedOnDate", "Email", "IsAdmin", "IsDeleted", "ModifiedOnDate", "Name", "Password", "PhoneNumber", "Role" },
                values: new object[] { 7, "QWRtaW5AMTIzI3NlY3JldEBwYXNzd29yZCExaGFzaGluZ19rZXkk", new DateTimeOffset(new DateTime(2023, 6, 17, 18, 54, 23, 415, DateTimeKind.Unspecified).AddTicks(6765), new TimeSpan(0, 0, 0, 0, 0)), "admin2@admin.com", true, false, new DateTimeOffset(new DateTime(2023, 6, 17, 18, 54, 23, 415, DateTimeKind.Unspecified).AddTicks(6775), new TimeSpan(0, 0, 0, 0, 0)), "Admin2", "QWRtaW5AMTIzI3NlY3JldEBwYXNzd29yZCExaGFzaGluZ19rZXkk", "1234567895", "Admin" });
        }
    }
}
