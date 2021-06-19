using System;
using System.Collections.Generic;
using System.Text;
using FluentMigrator;

namespace Migrations
{
    [Migration(20210615081700)]
    public class _20210615081700_GenerateDB : Migration
    {
        public override void Down()
        {
            //Delete.ForeignKey("FK_GoodEntries_Goods");
            Delete.Table("GoodEntries");

            //Delete.ForeignKey("FK_GoodSales_Goods");
            Delete.Table("GoodSales");

            //Delete.ForeignKey("FK_Goods_GoodCategories");
            Delete.Table("Goods");

            Delete.Table("GoodCategories");
        }

        public override void Up()
        {

            Create.Table("GoodCategories")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Title").AsString().NotNullable();

            Create.Table("Goods")
                 .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                 .WithColumn("Code").AsString().NotNullable().WithDefaultValue(0)
                 .WithColumn("Title").AsString().NotNullable().WithDefaultValue("")
                 .WithColumn("Price").AsDecimal().NotNullable().WithDefaultValue(0)
                 .WithColumn("Count").AsInt32().NotNullable().WithDefaultValue(0)
                 .WithColumn("CategoryID").AsInt32().ForeignKey("FK_Goods_GoodCategories", "GoodCategories", "Id").OnDelete(System.Data.Rule.Cascade);

            Create.Table("GoodSales")
            .WithColumn("Id").AsInt64().PrimaryKey().Identity()
            .WithColumn("TotalPrice").AsDecimal().NotNullable().WithDefaultValue(0)
            .WithColumn("Count").AsInt32().NotNullable().WithDefaultValue(0)
            .WithColumn("Date").AsDateTime().NotNullable().WithDefaultValue(DateTime.Now)
            .WithColumn("GoodID").AsInt32().Nullable().ForeignKey("FK_GoodSales_Goods", "Goods", "Id").OnDelete(System.Data.Rule.SetNull);

            Create.Table("GoodEntries")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("TotalPrice").AsDecimal().NotNullable().WithDefaultValue(0)
            .WithColumn("Count").AsInt32().NotNullable().WithDefaultValue(0)
            .WithColumn("Date").AsDateTime().NotNullable().WithDefaultValue(DateTime.Now)
            .WithColumn("GoodID").AsInt32().Nullable().ForeignKey("FK_GoodEntries_Goods", "Goods", "Id").OnDelete(System.Data.Rule.SetNull);
        }
    }
}
