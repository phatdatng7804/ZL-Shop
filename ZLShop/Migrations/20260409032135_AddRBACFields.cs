using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZLShop.Migrations
{
    /// <inheritdoc />
    public partial class AddRBACFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Permissions",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 4, 9, 3, 21, 33, 543, DateTimeKind.Utc).AddTicks(9895), new DateTime(2026, 4, 9, 3, 21, 33, 543, DateTimeKind.Utc).AddTicks(9897) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 4, 9, 3, 21, 33, 543, DateTimeKind.Utc).AddTicks(9899), new DateTime(2026, 4, 9, 3, 21, 33, 543, DateTimeKind.Utc).AddTicks(9899) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 4, 9, 3, 21, 33, 543, DateTimeKind.Utc).AddTicks(9900), new DateTime(2026, 4, 9, 3, 21, 33, 543, DateTimeKind.Utc).AddTicks(9900) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Permissions");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 4, 3, 19, 18, 30, 82, DateTimeKind.Utc).AddTicks(3732), new DateTime(2026, 4, 3, 19, 18, 30, 82, DateTimeKind.Utc).AddTicks(3735) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 4, 3, 19, 18, 30, 82, DateTimeKind.Utc).AddTicks(3737), new DateTime(2026, 4, 3, 19, 18, 30, 82, DateTimeKind.Utc).AddTicks(3738) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 4, 3, 19, 18, 30, 82, DateTimeKind.Utc).AddTicks(3738), new DateTime(2026, 4, 3, 19, 18, 30, 82, DateTimeKind.Utc).AddTicks(3739) });
        }
    }
}
