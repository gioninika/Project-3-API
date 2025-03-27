using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShoppingCart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCart", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    ShopingCartId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_ShoppingCart_ShopingCartId",
                        column: x => x.ShopingCartId,
                        principalTable: "ShoppingCart",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateOnly>(type: "date", nullable: false),
                    TotalAmount = table.Column<double>(type: "float", nullable: false),
                    ShopingCartId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_ShoppingCart_ShopingCartId",
                        column: x => x.ShopingCartId,
                        principalTable: "ShoppingCart",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    ShopingCartId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_ShoppingCart_ShopingCartId",
                        column: x => x.ShopingCartId,
                        principalTable: "ShoppingCart",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Description", "Name", "Price", "ShopingCartId", "Stock" },
                values: new object[,]
                {
                    { 1, "High-performance laptop", "Laptop", 1200.5, null, 10 },
                    { 2, "Latest model smartphone", "Smartphone", 899.99000000000001, null, 15 },
                    { 3, "Noise-canceling headphones", "Headphones", 199.99000000000001, null, 30 },
                    { 4, "Fitness tracking smartwatch", "Smartwatch", 249.99000000000001, null, 20 },
                    { 5, "RGB gaming mouse", "Gaming Mouse", 49.990000000000002, null, 50 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_ShopingCartId",
                table: "Customer",
                column: "ShopingCartId",
                unique: true,
                filter: "[ShopingCartId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ShopingCartId",
                table: "Order",
                column: "ShopingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ShopingCartId",
                table: "Product",
                column: "ShopingCartId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "ShoppingCart");
        }
    }
}
