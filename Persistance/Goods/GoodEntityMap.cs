using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyLittleShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLittleShop.Model.EntityMaps
{
    public class GoodEntityMap : IEntityTypeConfiguration<Good>
    {
        public void Configure(EntityTypeBuilder<Good> builder)
        {
            builder.Property(_ => _.Code).IsRequired().HasMaxLength(20);
            builder.Property(_ => _.Title).IsRequired();
            builder.Property(_ => _.Price).IsRequired();
            builder.Property(_ => _.CategoryId).IsRequired();
        }
    }
}
