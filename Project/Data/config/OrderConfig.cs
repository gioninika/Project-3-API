using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Models;

namespace Project.Data.config
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.HasOne(x => x.ShopingCart).WithMany(x => x.Orders)
                .HasForeignKey(x => x.ShopingCartId).HasConstraintName("FK_Order_ShoppingCart_ShopingCartId");
        }
    }
}
