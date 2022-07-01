using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FridgeProductsWebAPI.Migrations
{
    public partial class AddingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "fridge_model",
                columns: new[] { "FridgeModelId", "Name", "Year" },
                values: new object[] { new Guid("4d490a70-94ce-4d15-9494-5248280c2ce3"), "Model2", 1994 });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "ProductId", "DefaultQuantity", "Name" },
                values: new object[] { new Guid("d9d4c053-49b6-410c-bc78-2d54a9991870"), 20, "Strawberry" });

            migrationBuilder.InsertData(
                table: "fridge",
                columns: new[] { "FridgeId", "FridgeModelId", "Name", "OwnerName" },
                values: new object[] { new Guid("90abbca8-664d-4b20-b5de-024705497d4a"), new Guid("4d490a70-94ce-4d15-9494-5248280c2ce3"), "Cool", "Michael" });

            migrationBuilder.InsertData(
                table: "fridge_products",
                columns: new[] { "FridgeProductId", "FridgeId", "ProductId", "Quantity" },
                values: new object[] { new Guid("96dba8c0-d178-41e7-938c-ed49778fb52a"), new Guid("90abbca8-664d-4b20-b5de-024705497d4a"), new Guid("d9d4c053-49b6-410c-bc78-2d54a9991870"), 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "fridge_products",
                keyColumn: "FridgeProductId",
                keyValue: new Guid("96dba8c0-d178-41e7-938c-ed49778fb52a"));

            migrationBuilder.DeleteData(
                table: "fridge",
                keyColumn: "FridgeId",
                keyValue: new Guid("90abbca8-664d-4b20-b5de-024705497d4a"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: new Guid("d9d4c053-49b6-410c-bc78-2d54a9991870"));

            migrationBuilder.DeleteData(
                table: "fridge_model",
                keyColumn: "FridgeModelId",
                keyValue: new Guid("4d490a70-94ce-4d15-9494-5248280c2ce3"));
        }
    }
}
