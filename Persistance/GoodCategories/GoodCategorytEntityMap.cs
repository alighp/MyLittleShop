using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyLittleShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLittleShop.Model
{
    public class GoodCategorytEntityMap : IEntityTypeConfiguration<GoodCategory>
    {
        public void Configure(EntityTypeBuilder<GoodCategory> builder)
        {
            builder.HasMany(_ => _.Goods).WithOne(_ => _.GoodCategory).HasForeignKey(_ => _.CategoryId);
            builder.Property(_ => _.Title).IsRequired();
        }
    }
}
