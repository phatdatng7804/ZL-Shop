using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZLShop.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Users",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Users",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 4, 12, 14, 36, 12, 793, DateTimeKind.Utc).AddTicks(9019), new DateTime(2026, 4, 12, 14, 36, 12, 793, DateTimeKind.Utc).AddTicks(9022) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 4, 12, 14, 36, 12, 793, DateTimeKind.Utc).AddTicks(9024), new DateTime(2026, 4, 12, 14, 36, 12, 793, DateTimeKind.Utc).AddTicks(9024) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 4, 12, 14, 36, 12, 793, DateTimeKind.Utc).AddTicks(9025), new DateTime(2026, 4, 12, 14, 36, 12, 793, DateTimeKind.Utc).AddTicks(9025) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Users");

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
    }
}
