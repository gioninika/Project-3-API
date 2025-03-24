using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class _3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
