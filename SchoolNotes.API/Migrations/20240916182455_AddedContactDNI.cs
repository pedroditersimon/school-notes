using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolNotes.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedContactDNI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseSession_Teacher_TeacherID",
                table: "CourseSession");

            migrationBuilder.AlterColumn<Guid>(
                name: "TeacherID",
                table: "CourseSession",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<string>(
                name: "DNI",
                table: "Contact",
                type: "text",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSession_Teacher_TeacherID",
                table: "CourseSession",
                column: "TeacherID",
                principalTable: "Teacher",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseSession_Teacher_TeacherID",
                table: "CourseSession");

            migrationBuilder.DropColumn(
                name: "DNI",
                table: "Contact");

            migrationBuilder.AlterColumn<Guid>(
                name: "TeacherID",
                table: "CourseSession",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "CourseSession",
                keyColumn: "ID",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 16, 23, 53, 16, 548, DateTimeKind.Utc).AddTicks(4915), new DateTime(2024, 9, 16, 21, 53, 16, 548, DateTimeKind.Utc).AddTicks(4907) });

            migrationBuilder.UpdateData(
                table: "CourseSession",
                keyColumn: "ID",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 17, 23, 53, 16, 548, DateTimeKind.Utc).AddTicks(4924), new DateTime(2024, 9, 17, 21, 53, 16, 548, DateTimeKind.Utc).AddTicks(4923) });

            migrationBuilder.UpdateData(
                table: "CourseSession",
                keyColumn: "ID",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"),
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 18, 23, 53, 16, 548, DateTimeKind.Utc).AddTicks(4927), new DateTime(2024, 9, 18, 21, 53, 16, 548, DateTimeKind.Utc).AddTicks(4926) });

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSession_Teacher_TeacherID",
                table: "CourseSession",
                column: "TeacherID",
                principalTable: "Teacher",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
