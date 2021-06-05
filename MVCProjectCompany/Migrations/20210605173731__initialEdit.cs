using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCProjectCompany.Migrations
{
    public partial class _initialEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "bd360d56-3a33-42aa-88a1-f0d3ee0c5182");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a3374637-7f41-4fa9-b413-eeab4751ec5c", "AQAAAAEAACcQAAAAEBIa740J41A1jG4dkZQ5NrCdRBJ4vqUkmzNeXSCDdj6nH4KQE90MP1wC4QA8xkbHcQ==" });

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("4aa76a4c-c59d-409a-84c1-06e6487a137a"),
                columns: new[] { "DateAdded", "Title" },
                values: new object[] { new DateTime(2021, 6, 5, 17, 37, 31, 118, DateTimeKind.Utc).AddTicks(257), "Our contacts" });

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("63dc8fa6-07ae-4391-8916-e057f71239ce"),
                columns: new[] { "DateAdded", "Title" },
                values: new object[] { new DateTime(2021, 6, 5, 17, 37, 31, 117, DateTimeKind.Utc).AddTicks(7537), "Index" });

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("70bf165a-700a-4156-91c0-e83fce0a277f"),
                columns: new[] { "DateAdded", "Title" },
                values: new object[] { new DateTime(2021, 6, 5, 17, 37, 31, 118, DateTimeKind.Utc).AddTicks(172), "Our services" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "82cfe52f-8ba6-4bf4-ae21-00626b1de4d3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dc1ea233-62a3-4425-a69d-a05aded6ab4e", "AQAAAAEAACcQAAAAEDLeOZ32us97EI2cGT2hGfVyYsvoiO8VHfJ5Rxa8LIcihorKnvmtMqixFDBu66TxZw==" });

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("4aa76a4c-c59d-409a-84c1-06e6487a137a"),
                columns: new[] { "DateAdded", "Title" },
                values: new object[] { new DateTime(2021, 6, 5, 17, 29, 34, 416, DateTimeKind.Utc).AddTicks(9046), "Контакты" });

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("63dc8fa6-07ae-4391-8916-e057f71239ce"),
                columns: new[] { "DateAdded", "Title" },
                values: new object[] { new DateTime(2021, 6, 5, 17, 29, 34, 416, DateTimeKind.Utc).AddTicks(6360), "Главная" });

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("70bf165a-700a-4156-91c0-e83fce0a277f"),
                columns: new[] { "DateAdded", "Title" },
                values: new object[] { new DateTime(2021, 6, 5, 17, 29, 34, 416, DateTimeKind.Utc).AddTicks(8984), "Наши услуги" });
        }
    }
}
