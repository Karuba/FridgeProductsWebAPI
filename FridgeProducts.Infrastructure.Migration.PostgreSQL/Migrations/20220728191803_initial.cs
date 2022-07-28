using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FridgeProducts.Infrastructure.Migr.PostgreSQL.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "fridge_model",
                columns: table => new
                {
                    FridgeModelId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fridge_model", x => x.FridgeModelId);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    DefaultQuantity = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "fridge",
                columns: table => new
                {
                    FridgeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    OwnerName = table.Column<string>(type: "text", nullable: true),
                    FridgeModelId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fridge", x => x.FridgeId);
                    table.ForeignKey(
                        name: "FK_fridge_fridge_model_FridgeModelId",
                        column: x => x.FridgeModelId,
                        principalTable: "fridge_model",
                        principalColumn: "FridgeModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "fridge_products",
                columns: table => new
                {
                    FridgeProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    FridgeId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fridge_products", x => x.FridgeProductId);
                    table.ForeignKey(
                        name: "FK_fridge_products_fridge_FridgeId",
                        column: x => x.FridgeId,
                        principalTable: "fridge",
                        principalColumn: "FridgeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_fridge_products_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "fridge_model",
                columns: new[] { "FridgeModelId", "Name", "Year" },
                values: new object[,]
                {
                    { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Model1", 1990 },
                    { new Guid("4d490a70-94ce-4d15-9494-5248280c2ce3"), "Model2", 1994 },
                    { new Guid("5d490a70-94ce-4d15-9494-5248280c2ce3"), "Model3", null }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "ProductId", "DefaultQuantity", "Name" },
                values: new object[,]
                {
                    { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), 12, "Banana" },
                    { new Guid("d9d4c053-49b6-410c-bc78-2d54a9991870"), 20, "Strawberry" },
                    { new Guid("e9d4c053-49b6-410c-bc78-2d54a9991870"), null, "Milk" }
                });

            migrationBuilder.InsertData(
                table: "fridge",
                columns: new[] { "FridgeId", "FridgeModelId", "Name", "OwnerName" },
                values: new object[,]
                {
                    { new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Atlant", "Kirill" },
                    { new Guid("90abbca8-664d-4b20-b5de-024705497d4a"), new Guid("4d490a70-94ce-4d15-9494-5248280c2ce3"), "Cool", "Michael" },
                    { new Guid("91abbca8-664d-4b20-b5de-024705497d4a"), new Guid("5d490a70-94ce-4d15-9494-5248280c2ce3"), "Frigidaire", "Arthur" }
                });

            migrationBuilder.InsertData(
                table: "fridge_products",
                columns: new[] { "FridgeProductId", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), 12 },
                    { new Guid("96dba8c0-d178-41e7-938c-ed49778fb52a"), new Guid("90abbca8-664d-4b20-b5de-024705497d4a"), new Guid("d9d4c053-49b6-410c-bc78-2d54a9991870"), 0 },
                    { new Guid("97dba8c0-d178-41e7-938c-ed49778fb52a"), new Guid("90abbca8-664d-4b20-b5de-024705497d4a"), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_fridge_FridgeModelId",
                table: "fridge",
                column: "FridgeModelId");

            migrationBuilder.CreateIndex(
                name: "IX_fridge_products_FridgeId",
                table: "fridge_products",
                column: "FridgeId");

            migrationBuilder.CreateIndex(
                name: "IX_fridge_products_ProductId",
                table: "fridge_products",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fridge_products");

            migrationBuilder.DropTable(
                name: "fridge");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "fridge_model");
        }
    }
}
