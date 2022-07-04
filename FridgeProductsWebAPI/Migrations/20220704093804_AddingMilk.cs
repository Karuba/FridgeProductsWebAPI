using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FridgeProductsWebAPI.Migrations
{
    public partial class AddingMilk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DefaultQuantity",
                table: "products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "ProductId", "DefaultQuantity", "Name" },
                values: new object[] { new Guid("e9d4c053-49b6-410c-bc78-2d54a9991870"), null, "Milk" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: new Guid("e9d4c053-49b6-410c-bc78-2d54a9991870"));

            migrationBuilder.AlterColumn<int>(
                name: "DefaultQuantity",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
