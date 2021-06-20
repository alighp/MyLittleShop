using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyLittleShop.Entities;

namespace MyLittleShop.Model
{
    public class GoodSaleEntityMap : IEntityTypeConfiguration<GoodSale>
    {
        public void Configure(EntityTypeBuilder<GoodSale> builder)
        {
            builder.HasOne(_ => _.Good).WithMany(_ => _.GoodSales).HasForeignKey(_ => _.GoodId);
        }
    }
}
