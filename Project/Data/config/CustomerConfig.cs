using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Models;

namespace Project.Data.config
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.HasOne(x => x.ShopingCart).WithOne(x => x.CustomerId)
                   .HasForeignKey<Customer>(x => x.ShopingCartId).HasConstraintName("FK_Customer_ShoppingCart_ShopingCartId");
        }
    }
}
