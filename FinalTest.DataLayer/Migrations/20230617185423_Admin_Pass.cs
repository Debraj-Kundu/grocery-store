using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalTest.DataLayer.Migrations
{
    public partial class Admin_Pass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ConfirmPassword", "CreatedOnDate", "ModifiedOnDate", "Password" },
                values: new object[] { "QWRtaW5AMTIzI3NlY3JldEBwYXNzd29yZCExaGFzaGluZ19rZXkk", new DateTimeOffset(new DateTime(2023, 6, 17, 18, 54, 23, 415, DateTimeKind.Unspecified).AddTicks(6342), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 17, 18, 54, 23, 415, DateTimeKind.Unspecified).AddTicks(6538), new TimeSpan(0, 0, 0, 0, 0)), "QWRtaW5AMTIzI3NlY3JldEBwYXNzd29yZCExaGFzaGluZ19rZXkk" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ConfirmPassword", "CreatedOnDate", "ModifiedOnDate", "Password" },
                values: new object[] { "QWRtaW5AMTIzI3NlY3JldEBwYXNzd29yZCExaGFzaGluZ19rZXkk", new DateTimeOffset(new DateTime(2023, 6, 17, 18, 54, 23, 415, DateTimeKind.Unspecified).AddTicks(6765), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 17, 18, 54, 23, 415, DateTimeKind.Unspecified).AddTicks(6775), new TimeSpan(0, 0, 0, 0, 0)), "QWRtaW5AMTIzI3NlY3JldEBwYXNzd29yZCExaGFzaGluZ19rZXkk" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ConfirmPassword", "CreatedOnDate", "ModifiedOnDate", "Password" },
                values: new object[] { "Admin@123", new DateTimeOffset(new DateTime(2023, 6, 17, 18, 46, 2, 723, DateTimeKind.Unspecified).AddTicks(2858), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 17, 18, 46, 2, 723, DateTimeKind.Unspecified).AddTicks(3035), new TimeSpan(0, 0, 0, 0, 0)), "Admin@123" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ConfirmPassword", "CreatedOnDate", "ModifiedOnDate", "Password" },
                values: new object[] { "Admin@123", new DateTimeOffset(new DateTime(2023, 6, 17, 18, 46, 2, 723, DateTimeKind.Unspecified).AddTicks(3255), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 17, 18, 46, 2, 723, DateTimeKind.Unspecified).AddTicks(3261), new TimeSpan(0, 0, 0, 0, 0)), "Admin@123" });
        }
    }
}
