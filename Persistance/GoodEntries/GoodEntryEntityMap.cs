﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyLittleShop.Entities;

namespace MyLittleShop.Model
{
    public class GoodEntryEntityMap : IEntityTypeConfiguration<GoodEntry>
    {
        public void Configure(EntityTypeBuilder<GoodEntry> builder)
        {
            builder.HasOne(_ => _.Good).WithMany(_ => _.GoodEntries).HasForeignKey(_ => _.GoodId);
            builder.Property(_ => _.GoodId).IsRequired();
            builder.Property(_ => _.Count).IsRequired();
            builder.Property(_ => _.TotalPrice).IsRequired();
        }
    }
}
