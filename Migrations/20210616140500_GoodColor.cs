using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Migrations
{
    [Migration(20210617104300)]
    public class _20210616140500_GoodColor : Migration
    {
        public override void Down()
        {
            Delete.Column("Color").FromTable("Goods");
        }

        public override void Up()
        {
            Alter.Table("Goods").AddColumn("ColorID").AsInt32()
                .NotNullable().WithDefaultValue(1);
        }
    }
}
