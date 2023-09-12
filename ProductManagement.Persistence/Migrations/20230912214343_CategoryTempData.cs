using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductManagement.Persistence.Migrations
{
    public partial class CategoryTempData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "IsActive", "LastUpdatedDate", "Name", "UpdatedBy" },
                values: new object[] { "1cd7b23b-cb2e-4602-bcbf-edd148bde44b", "This category will hold products characterised as electronics.", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Electronics", null });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "IsActive", "LastUpdatedDate", "Name", "UpdatedBy" },
                values: new object[] { "2cd7b23b-cb2e-4602-bcbf-edd148bde44b", "This category will hold products characterised as books", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Books", null });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "IsActive", "LastUpdatedDate", "Name", "UpdatedBy" },
                values: new object[] { "3cd7b23b-cb2e-4602-bcbf-edd148bde44b", "This category will hold products characterised as clothes", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clothes", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "1cd7b23b-cb2e-4602-bcbf-edd148bde44b");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "2cd7b23b-cb2e-4602-bcbf-edd148bde44b");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "3cd7b23b-cb2e-4602-bcbf-edd148bde44b");
        }
    }
}
