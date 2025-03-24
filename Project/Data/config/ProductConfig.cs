using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Models;

namespace Project.Data.config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.HasData(new List<Product>()
            {
                new Product { Id = 1, Name = "Laptop", Description = "High-performance laptop", Price = 1200.50, Stock = 10, ShopingCartId = null },
                new Product { Id = 2, Name = "Smartphone", Description = "Latest model smartphone", Price = 899.99, Stock = 15, ShopingCartId = null },
                new Product { Id = 3, Name = "Headphones", Description = "Noise-canceling headphones", Price = 199.99, Stock = 30, ShopingCartId = null },
                new Product { Id = 4, Name = "Smartwatch", Description = "Fitness tracking smartwatch", Price = 249.99, Stock = 20, ShopingCartId = null },
                new Product { Id = 5, Name = "Gaming Mouse", Description = "RGB gaming mouse", Price = 49.99, Stock = 50, ShopingCartId = null }
            });
            builder.HasOne(x => x.ShopingCart).WithMany(x => x.Products)
                .HasForeignKey(x => x.ShopingCartId).HasConstraintName("FK_Product_ShoppingCart_ShopingCartId");
        }
    }
}
