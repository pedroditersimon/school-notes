using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolNotes.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedContactSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Contact",
                keyColumn: "ID",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "DNI",
                value: "00000001");

            migrationBuilder.UpdateData(
                table: "Contact",
                keyColumn: "ID",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "DNI",
                value: "00000002");

            migrationBuilder.UpdateData(
                table: "Contact",
                keyColumn: "ID",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "DNI",
                value: "00000003");

            migrationBuilder.UpdateData(
                table: "CourseSession",
                keyColumn: "ID",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 17, 20, 35, 6, 174, DateTimeKind.Utc).AddTicks(2004), new DateTime(2024, 9, 17, 18, 35, 6, 174, DateTimeKind.Utc).AddTicks(1996) });

            migrationBuilder.UpdateData(
                table: "CourseSession",
                keyColumn: "ID",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 18, 20, 35, 6, 174, DateTimeKind.Utc).AddTicks(2009), new DateTime(2024, 9, 18, 18, 35, 6, 174, DateTimeKind.Utc).AddTicks(2008) });

            migrationBuilder.UpdateData(
                table: "CourseSession",
                keyColumn: "ID",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"),
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 19, 20, 35, 6, 174, DateTimeKind.Utc).AddTicks(2012), new DateTime(2024, 9, 19, 18, 35, 6, 174, DateTimeKind.Utc).AddTicks(2011) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Contact",
                keyColumn: "ID",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "DNI",
                value: null);

            migrationBuilder.UpdateData(
                table: "Contact",
                keyColumn: "ID",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "DNI",
                value: null);

            migrationBuilder.UpdateData(
                table: "Contact",
                keyColumn: "ID",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "DNI",
                value: null);

            migrationBuilder.UpdateData(
                table: "CourseSession",
                keyColumn: "ID",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 17, 20, 24, 53, 904, DateTimeKind.Utc).AddTicks(8628), new DateTime(2024, 9, 17, 18, 24, 53, 904, DateTimeKind.Utc).AddTicks(8620) });

            migrationBuilder.UpdateData(
                table: "CourseSession",
                keyColumn: "ID",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 18, 20, 24, 53, 904, DateTimeKind.Utc).AddTicks(8634), new DateTime(2024, 9, 18, 18, 24, 53, 904, DateTimeKind.Utc).AddTicks(8633) });

            migrationBuilder.UpdateData(
                table: "CourseSession",
                keyColumn: "ID",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"),
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 19, 20, 24, 53, 904, DateTimeKind.Utc).AddTicks(8637), new DateTime(2024, 9, 19, 18, 24, 53, 904, DateTimeKind.Utc).AddTicks(8636) });
        }
    }
}
