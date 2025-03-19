using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Models;

namespace Project.Data.config
{
    public class ShoppingCartConfig : IEntityTypeConfiguration<ShopingCart>
    {
        public void Configure(EntityTypeBuilder<ShopingCart> builder)
        {
            builder.ToTable("ShoppingCart");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
        }
    }
}
