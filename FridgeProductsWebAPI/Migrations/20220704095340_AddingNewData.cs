using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FridgeProductsWebAPI.Migrations
{
    public partial class AddingNewData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Year",
                table: "fridge_model",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "fridge_model",
                columns: new[] { "FridgeModelId", "Name", "Year" },
                values: new object[] { new Guid("5d490a70-94ce-4d15-9494-5248280c2ce3"), "Model3", null });

            migrationBuilder.InsertData(
                table: "fridge",
                columns: new[] { "FridgeId", "FridgeModelId", "Name", "OwnerName" },
                values: new object[] { new Guid("91abbca8-664d-4b20-b5de-024705497d4a"), new Guid("5d490a70-94ce-4d15-9494-5248280c2ce3"), "Frigidaire", "Arthur" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "fridge",
                keyColumn: "FridgeId",
                keyValue: new Guid("91abbca8-664d-4b20-b5de-024705497d4a"));

            migrationBuilder.DeleteData(
                table: "fridge_model",
                keyColumn: "FridgeModelId",
                keyValue: new Guid("5d490a70-94ce-4d15-9494-5248280c2ce3"));

            migrationBuilder.AlterColumn<int>(
                name: "Year",
                table: "fridge_model",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
