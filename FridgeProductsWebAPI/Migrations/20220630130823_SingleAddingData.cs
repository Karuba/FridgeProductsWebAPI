using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FridgeProductsWebAPI.Migrations
{
    public partial class SingleAddingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "fridge_products",
                columns: new[] { "FridgeProductId", "FridgeId", "ProductId", "Quantity" },
                values: new object[] { new Guid("97dba8c0-d178-41e7-938c-ed49778fb52a"), new Guid("90abbca8-664d-4b20-b5de-024705497d4a"), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "fridge_products",
                keyColumn: "FridgeProductId",
                keyValue: new Guid("97dba8c0-d178-41e7-938c-ed49778fb52a"));
        }
    }
}
