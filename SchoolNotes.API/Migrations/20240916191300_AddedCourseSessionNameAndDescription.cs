using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolNotes.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedCourseSessionNameAndDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "CourseSession",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CourseSession",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "CourseSession",
                keyColumn: "ID",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                columns: new[] { "Description", "EndTime", "Name", "StartTime" },
                values: new object[] { null, new DateTime(2024, 9, 17, 21, 13, 0, 163, DateTimeKind.Utc).AddTicks(260), null, new DateTime(2024, 9, 17, 19, 13, 0, 163, DateTimeKind.Utc).AddTicks(254) });

            migrationBuilder.UpdateData(
                table: "CourseSession",
                keyColumn: "ID",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "Description", "EndTime", "Name", "StartTime" },
                values: new object[] { null, new DateTime(2024, 9, 18, 21, 13, 0, 163, DateTimeKind.Utc).AddTicks(265), null, new DateTime(2024, 9, 18, 19, 13, 0, 163, DateTimeKind.Utc).AddTicks(264) });

            migrationBuilder.UpdateData(
                table: "CourseSession",
                keyColumn: "ID",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"),
                columns: new[] { "Description", "EndTime", "Name", "StartTime" },
                values: new object[] { null, new DateTime(2024, 9, 19, 21, 13, 0, 163, DateTimeKind.Utc).AddTicks(268), null, new DateTime(2024, 9, 19, 19, 13, 0, 163, DateTimeKind.Utc).AddTicks(268) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "CourseSession");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "CourseSession");

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
    }
}
